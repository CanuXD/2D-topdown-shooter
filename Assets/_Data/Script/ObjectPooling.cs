using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{   
    private class Pool
    {
        public string name;
        public GameObject prefab;
        public int size;
    }
    private List<Pool> pools;
    public Dictionary<string,Queue<GameObject>> poolDictionary;
    public static ObjectPooling Instance;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        poolDictionary= new Dictionary<string, Queue<GameObject>>();
        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for(int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);   
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.name, objectPool);
        }
    }
    private GameObject spawnObjectPool(string name,Vector3 pos,Quaternion rot)
    {
        if (!poolDictionary.ContainsKey(name))
        {
            Debug.Log("Empty");
            return null;
        }
        GameObject objectToSpawn = poolDictionary[name].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = pos;
        objectToSpawn.transform.rotation = rot;
        poolDictionary[name].Enqueue(objectToSpawn);
        return objectToSpawn;
    }
}
