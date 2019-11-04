//Program Name:PlayerMovement.cs
//Program Description:Program to move the player left and right by applying
//force to the rigidbody

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Util;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement Variables")]
    public float moveVelocity;
    public Rigidbody2D playerRig;
    public float MaxSpeed;
    public Animator anim;
    public SpriteRenderer spriteRenderer;

    [Header("Player Jump Variables")]
    public float JumpVelocity;
    public bool IsGrounded;
    public float defaultGravity;
    public float maxVelocity;

    [Header("Audio Sources")]
    public AudioSource jumpSfx;
    public AudioSource pickUpSfx;
    public AudioSource hurtSfx;
    public AudioSource lifeSfx;

    [Header("UI Controller")]
    public UiController uiController;

    //public Vector2 maximumVelocity = new Vector2(6.0f, 7.0f);

    [Header("Other")]
    private double gravity;
    private float playerMass;
    public bool SpaceDown;
    public Transform SpawnPoint;



    void Start()
    {
        gravity = this.playerRig.gravityScale;
        IsGrounded = false;
        uiController.Lives = 5;
    }


    void FixedUpdate()
    {
        Jump();
    }

    void Update()
    {
        Movement();
        //VelocityConstraint();
      

        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            anim.SetInteger("AnimationState", (int)PlayerAnimState.IDLE);
        }

       

        IsGrounded = Physics2D.BoxCast(transform.position, new Vector2(0.75f,0.25f), 0.0f, Vector2.down, 1.0f, 1 << LayerMask.NameToLayer("Grounded"));
        this.playerRig.velocity = new Vector2(playerRig.velocity.x, Mathf.Clamp(this.playerRig.velocity.y, -maxVelocity, maxVelocity));


        KeyStatesCheck();
        AlterGravity();

        //this.playerRig.velocity = new Vector2(Mathf.Clamp(this.playerRig.velocity.x, -MaxSpeed, MaxSpeed), playerRig.velocity.y);
    }

    void Movement()
    {
        float MoveHorizontal = Input.GetAxisRaw("Horizontal");

        if (MoveHorizontal > 0.0&&IsGrounded)
        {
            playerRig.AddRelativeForce(transform.right * moveVelocity, ForceMode2D.Force);
            anim.SetInteger("AnimationState", (int)PlayerAnimState.RUN);
        
            
           this.spriteRenderer.flipX = false;
            
          
        }

        if (MoveHorizontal < 0.0&&IsGrounded)
        {
            playerRig.AddRelativeForce(-transform.right * moveVelocity, ForceMode2D.Force);
            anim.SetInteger("AnimationState", (int)PlayerAnimState.RUN);

            this.spriteRenderer.flipX = true;
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
        if ((Input.GetAxis("Jump")) > 0 && (IsGrounded))
        {
            Debug.Log(playerRig.velocity.y.ToString());
            anim.SetInteger("AnimationState", (int)PlayerAnimState.JUMP);
            
            playerRig.AddForce(Vector3.up * JumpVelocity, ForceMode2D.Impulse);
            jumpSfx.Play();
            IsGrounded = false;

        }

    }

    public void AlterGravity()
    {
        if (!IsGrounded)
        {
            playerRig.gravityScale += 0.12f;
        }
        else
        {
            playerRig.gravityScale = defaultGravity;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Collectible":
                pickUpSfx.Play();
                uiController.CherryScore += 1;
                Destroy(collision.gameObject);
                break;

            case "Life":
                lifeSfx.Play();
                uiController.Lives += 1;
                Destroy(collision.gameObject);
                break;

            case "Victory":
                SceneManager.LoadScene("Win");
                break;
                
        }
       
    }

  

    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {

            case "DeathGround":

                if (uiController.Lives != 0)
                {
                    this.transform.position = SpawnPoint.transform.position;
                    hurtSfx.Play();
                    uiController.Lives -= 1;
                }

                break;

            case "Enemy":
                if (uiController.Lives != 0)
                {
                    hurtSfx.Play();
                    anim.SetTrigger("IsHurt");

                    uiController.Lives -= 1;
                }
                    break;

            case "Spikes":
                if (uiController.Lives != 0)
                {
                    hurtSfx.Play();
                    anim.SetTrigger("IsHurt");
                    uiController.Lives -=10;
                }
                    break;
        }
       
    }
}
