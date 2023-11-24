using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float bulletSpd, speard;
    public int amount;
    public Transform shotPos;
    public GameObject bullet;
    public float timeBtwShoot = 2f;
    private float timeofLastShoot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(Time.time - timeofLastShoot >= timeBtwShoot)
            {
                Shot();
                timeofLastShoot = Time.time;
            }
        }
    }
    void Shot()
    {
        for(int i = 0; i < amount; i++)
        {
            GameObject b = Instantiate(bullet,shotPos.position,shotPos.rotation);
            Rigidbody2D brb = b.GetComponent<Rigidbody2D>();
            Vector2 dir = transform.rotation * Vector2.right;
            Vector2 pdir = Vector2.Perpendicular(dir)*Random.Range(-speard, speard);
            brb.velocity = (dir+pdir) * bulletSpd;
        }
    }
}
