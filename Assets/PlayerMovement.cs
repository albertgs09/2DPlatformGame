using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public LayerMask ground;
    public Transform groundCheck;
    public float moveSpeed, jumpForce;
    private SpriteRenderer body;
    private Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        body = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Jump();
        FlipsSprite();
    }
    private void Jump()
    {
        //Jump input
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    private void FlipsSprite()
    {
        //gets input and flips sprite
        float inputX = Input.GetAxisRaw("Horizontal");
        if (inputX > 0 || inputX < 0)
            // anim.SetBool("");
        //else anim.SetBool("");

        if (inputX > 0) body.flipX = false;
        else if (inputX < 0) body.flipX = true;
    }
    void FixedUpdate()
    {
        //moves player
        transform.Translate(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0, 0);
    }

    bool IsGrounded()
    {
        //checks if grounded
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, ground);
    }
}
