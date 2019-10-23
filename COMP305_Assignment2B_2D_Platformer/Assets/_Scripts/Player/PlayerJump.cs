//Program Name:PlayerJump
//Program Description:Program to make the player jump by 
//applying force to rigidbody
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [Header("Player Jump Variables")]
    public float JumpVelocity;
    public bool IsGrounded = false;
    public float defaultGravity;
    //public float gravityScaleRate;

    [Header("Other")]
    public Rigidbody2D PlayerRig;
    private double gravity;
    private float playerMass;
    public bool SpaceDown;

    void Start()
    {
       gravity = this.PlayerRig.gravityScale;
       playerMass = this.PlayerRig.mass;
    }

    void FixedUpdate()
    {
        Jump();
        
    }

    void Update()
    {
        KeyStatesCheck();
        AlterGravity();
        if (transform.position.y > 0.0125364)
        {
            IsGrounded = false;
        }
      
       
    }

    public void KeyStatesCheck()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpaceDown = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            SpaceDown = false;
        } 
        
    }

    public void Jump()
    {
        if (SpaceDown&&IsGrounded)
        {
            PlayerRig.AddForce(transform.up * JumpVelocity, ForceMode2D.Impulse);
            IsGrounded = false;
            
        }

    }

    public void AlterGravity()
    {
        if (!IsGrounded)
        {
            PlayerRig.gravityScale += playerMass;
        }
        else
        {
            PlayerRig.gravityScale = defaultGravity;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            IsGrounded = true;
            gravity = defaultGravity;
        }
       
    }
}
