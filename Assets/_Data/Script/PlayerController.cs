using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float moveSpd = 5f;
    public SpriteRenderer sr;
    public Vector2 moveInput;
    public Rigidbody2D rb;
    public Animator anim;
    /*    private bool isFacingRight = true;*/

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        anim.SetFloat("Speed",moveInput.sqrMagnitude);
    }
    void FixedUpdate()
    {   
        //Movement
        rb.MovePosition(rb.position + moveInput.normalized * moveSpd * Time.fixedDeltaTime);
        Flip();
    }
    void Flip() //function flip player
    {
        Vector3 mouse = Input.mousePosition;
        Vector3 vec3 = new Vector3(mouse.x, mouse.y, this.transform.position.y);
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(vec3);
        Vector3 forward = mouseWorld - this.transform.position;
        sr.transform.localScale = new Vector3(Mathf.Sign(forward.x), 1, 1);
    }
}
