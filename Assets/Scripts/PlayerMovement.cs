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
        //Set AirSpeed in animator
        anim.SetFloat("AirSpeedY", rb.velocity.y);
        //Sets Grounded bool to animator
        anim.SetBool("Grounded", IsGrounded());
        //KeyboardInputsForTesting();
    }

    private void KeyboardInputsForTesting()
    {
        inputX = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Fire1"))
        {
            var randNum = UnityEngine.Random.Range(0, attackStrings.Length);
            anim.SetTrigger(attackStrings[randNum]);
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            anim.SetTrigger("Jump");
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    public void Attack()
    {
        //gets random number from array and sets it to the animation
        var randNum = UnityEngine.Random.Range(0, attackStrings.Length);
        anim.SetTrigger(attackStrings[randNum]);
    }

    public void Jump()
    {
        //Forces player up if grounded
        if (IsGrounded())
        {
            anim.SetTrigger("Jump");
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    public void Block()
    {
        //anim.SetTrigger("Block");//Blocked Attack, sets animation
        anim.SetBool("IdleBlock", true);
        moveSpeed = 0;//sets speed to 0 so player wont move
    }
    public void UnBlock()
    {
        anim.SetBool("IdleBlock", false);
        moveSpeed = 6;//resets the speed
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
