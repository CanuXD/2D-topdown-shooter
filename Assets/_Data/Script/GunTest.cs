using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTest : MonoBehaviour
{
    public Vector3 mousePosition;
    public Vector3 forward = Vector3.zero;
    public float bulletSpd, speard;
    public int amount;
    public Transform shotPos;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        Vector2 wscale = transform.localScale;
        if (dir.x < 0)
        {
            wscale.y = -1;

        }
        else if (dir.x > 0)
        {
            wscale.y = 1;
        }
        transform.localScale = wscale;
        if (Input.GetMouseButtonDown(0))
        {
            Shot();
        }
    }
    void Shot()
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject b = Instantiate(bullet, shotPos.position, shotPos.rotation);
            Rigidbody2D brb = b.GetComponent<Rigidbody2D>();
            Vector2 dir = transform.rotation * Vector2.right;
            Vector2 pdir = Vector2.Perpendicular(dir) * Random.Range(-speard, speard);
            brb.velocity = (dir + pdir) * bulletSpd;
        }
    }
}
