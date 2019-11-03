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
    public bool IsGrounded;
    public float defaultGravity;
    //public GameObject rayTarget;
    //public float gravityScaleRate;

    [Header("Other")]
    public Rigidbody2D PlayerRig;
    private double gravity;
    private float playerMass;
    public bool SpaceDown;
    public float maxVelocity;
    public Animator anim;

    void Start()
    {
       gravity = this.PlayerRig.gravityScale;
       playerMass = this.PlayerRig.mass;
        IsGrounded = false;
    }

    void FixedUpdate()
    {
        Jump();
       
        
    }

    void Update()
    {
        IsGrounded = Physics2D.BoxCast(transform.position, new Vector2(2.0f, 1.0f), 0.0f, Vector2.down, 1.0f, 1 << LayerMask.NameToLayer("Grounded"));

   
        this.PlayerRig.velocity = new Vector2(PlayerRig.velocity.x,Mathf.Clamp(this.PlayerRig.velocity.y, -maxVelocity, maxVelocity));

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

   
    public void Jump()
    {
        if ((Input.GetAxis("Jump"))>0&&(IsGrounded))
        {
            anim.SetInteger("AnimationState", 2);
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

 
}
