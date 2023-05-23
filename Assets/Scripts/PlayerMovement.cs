using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public LayerMask ground;
    public Transform groundCheck;
    public float moveSpeed, jumpForce;
    private float inputX;
    private SpriteRenderer body;
    private Animator anim;
    private string[] attackStrings = {"Attack1","Attack2", "Attack3"};
    public VariableJoystick joystick;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        body = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //input for movement
        inputX = joystick.Horizontal;
        FlipsSprite();
        WalkAnim();
    }

    public void Attack()
    {
        //gets random number from array and sets it to the animation
        var randNum = UnityEngine.Random.Range(0, attackStrings.Length);
        anim.SetTrigger(attackStrings[randNum]);
    }

    public void Jump()
    {
        //Jump input
        if (IsGrounded())
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    private void WalkAnim()
    {
        //Sets the walking animations
        if (inputX > 0 || inputX < 0)
            anim.SetBool("IsWalking", true);
        else anim.SetBool("IsWalking", false);
    }
    private void FlipsSprite()
    {
        //gets input and flips sprite
        if (inputX > 0) body.flipX = false;
        else if (inputX < 0) body.flipX = true;
    }
    void FixedUpdate()
    {
        //moves player
        transform.Translate(inputX * moveSpeed * Time.deltaTime, 0, 0);
    }

    bool IsGrounded()
    {
        //checks if grounded
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, ground);
    }
}
