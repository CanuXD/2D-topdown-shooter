using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherEnemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    private bool isFacingRight = true;
    public Transform arrowPos;

    private float timebtwShoot;
    public float startTimeBtwShoot; 
    private Transform player;
    public GameObject projectile;
    private Rigidbody2D rb;
    public int heath = 100;
    private Animator anim;

    void Awake()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        timebtwShoot = startTimeBtwShoot;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            rb.velocity = (player.position - transform.position).normalized * speed;
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            rb.velocity = (player.position - transform.position).normalized * -speed;
        }
        if (player.transform.position.x < transform.position.x && isFacingRight == true)
        {
            Flip();
        }
        if (player.transform.position.x > transform.position.x && isFacingRight == false)
        {
            Flip();
        }
        if(timebtwShoot <= 0)
        {
            Instantiate(projectile, arrowPos.position,Quaternion.identity);
            timebtwShoot = startTimeBtwShoot;
        }
        else
        {
            timebtwShoot -= Time.deltaTime;
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
            Debug.Log("Player");
        }
    }
    public void TakeDmg(int dmg)
    {
        heath -= dmg;
        if (heath <= 0)
        {
            Die();

        }
    }
    void Die()
    {
        anim.SetBool("isDead",true);
        Destroy(this.gameObject,0.2f);
    }
}
