using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemySpeed;
    private Transform player;
    private Rigidbody2D rb;
    public float dis;
    private bool isFacingRight = true;
    public int heath = 100;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position,player.position) > dis)
        {
            rb.velocity = (player.position - transform.position).normalized * enemySpeed;
        }
        if(player.transform.position.x < transform.position.x && isFacingRight == true) 
        {
            Flip();
        }
        if (player.transform.position.x > transform.position.x && isFacingRight == false)
        {
            Flip();
        }
    }
    void Flip()
    {
        Vector3 current = gameObject.transform.localScale;
        current.x *= -1;
        gameObject.transform.localScale = current;
        isFacingRight = !isFacingRight;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hit player");
        }
    }
    public void TakeDmg(int dmg)
    {
        heath -= dmg;
        if(heath <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        anim.SetBool("isDead",true);
        Destroy(this.gameObject, 0.2f);
    }
}
