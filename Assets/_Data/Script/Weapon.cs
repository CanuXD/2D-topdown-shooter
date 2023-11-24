using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Vector3 mousePosition;
    public Vector3 forward = Vector3.zero;
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
/*        Vector3 mouse = Input.mousePosition;
        Vector3 vec3 = new Vector3(mouse.x,mouse.y,player.transform.position.y);
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(vec3);
        forward = mouseWorld - player.transform.position;
        player.transform.localScale = new Vector3(Mathf.Sign(forward.x), 1, 1);*/
    }
}

