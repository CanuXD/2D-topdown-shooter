using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemy;
    // Start is called before the first frame update

    public void Spawn()
    {
        int rand = Random.Range(0, enemy.Length);
        Instantiate(enemy[rand],transform.position,Quaternion.identity);
        Debug.Log(enemy[rand].name);
    }
}
