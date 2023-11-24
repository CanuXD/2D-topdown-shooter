using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerController pc;
    public Animator anim;
    void Start()
    {
        pc = GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(pc.moveInput.sqrMagnitude);
        anim.SetFloat("Running", pc.moveInput.sqrMagnitude);
    }
}
