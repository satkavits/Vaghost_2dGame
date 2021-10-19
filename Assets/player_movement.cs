using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{

    public CharacterController2D controller;

    float hmove = 0;
    bool jump = false;
    bool crouch = false;
    public float runspeed = 40;
    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hmove = Input.GetAxisRaw("Horizontal") * runspeed;

        animator.SetFloat("speed", Mathf.Abs(hmove));

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("jump", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            animator.SetBool("crouching", true);
        }
        else if(Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            animator.SetBool("crouching", false);
        }
    }

    void FixedUpdate() 
    {
        controller.Move(hmove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        animator.SetBool("jump", false);


    }
}
