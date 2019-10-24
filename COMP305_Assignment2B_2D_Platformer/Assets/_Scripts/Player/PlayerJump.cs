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
    public GameObject rayTarget;
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
        GroundCheck();
        
    }

    void Update()
    {
        KeyStatesCheck();
        AlterGravity();
         
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

    public void GroundCheck()
    {


        //Debug.DrawRay(rayTarget.transform.position,Vector3.down*0.1f, Color.red);
        RaycastHit hitRay;
        //Debug.DrawRay(rayTarget.transform.position, hitRay.point, Color.red, 2f);

        if (Physics.Raycast(rayTarget.transform.position, -Vector3.up, out hitRay))
        {
            if (hitRay.collider)
            {
                Debug.Log("Collided");
                Debug.DrawRay(rayTarget.transform.position, -Vector3.up * hitRay.distance, Color.red, 2f);
            }
           
           
        }

    }

    public void Jump()
    {
        if (SpaceDown&&IsGrounded)
        {
            PlayerRig.AddForce(Vector3.up * JumpVelocity, ForceMode2D.Impulse);
            IsGrounded = false;
            
        }

    }

    public void AlterGravity()
    {
        if (!IsGrounded)
        {
            PlayerRig.gravityScale += 0.15f;
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

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            IsGrounded = false;
            //gravity = defaultGravity;
        }

    }
}
