using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float time;
    public int damage = 20;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject,time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            ArcherEnemy archerEnemy = other.GetComponent<ArcherEnemy>();
            if (enemy != null)
            {   
                Debug.Log(enemy.name);
                enemy.TakeDmg(damage);
            }
            if (archerEnemy != null)
            {
                Debug.Log(archerEnemy.name);
                archerEnemy.TakeDmg(damage);
            }
            Destroy(this.gameObject);
        }
    }
}
