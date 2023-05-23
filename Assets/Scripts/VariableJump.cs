using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableJump : MonoBehaviour
{
    public Rigidbody2D body;
    public float buttonTime = 0.3f;
    public float jumpAmount = 20;
    private float jumpTime;
    private bool jumping;
   
    private void Update()
    {
        
        if (Input.GetButtonDown("Jump"))
        {
            jumping = true;
            jumpTime = 0;
        }
        
        if (jumping)
        {
            body.velocity = new Vector2(body.velocity.x, jumpAmount);
            jumpTime += Time.deltaTime;
        }

        if (Input.GetButtonUp("Jump") | jumpTime> buttonTime)
            jumping = false;
    }
    private void Jump()
    {

    }
}
