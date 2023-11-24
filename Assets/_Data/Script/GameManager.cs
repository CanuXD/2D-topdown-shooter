using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] spawnPoints;
    private float timebtwSpawn;
    public float startTimeBtwSpawn = 2f;

    // Start is called before the first frame update
    void Start()
    {
        timebtwSpawn = startTimeBtwSpawn;
        Spawner();
    }

    // Update is called once per frame
    void Update()
    {
        if (timebtwSpawn <= 0)
        {
            Spawner();
            timebtwSpawn = startTimeBtwSpawn;
        }
        else
        {
            timebtwSpawn -= Time.deltaTime;
        }

    }
    void Spawner()
    {
        foreach (GameObject spawnPoint in spawnPoints)
        {
            int rand = Random.Range(0,2);
            if(rand != 0)
            {
                spawnPoint.GetComponent<EnemySpawner>().Spawn();
            }
        }
 
    }
}
