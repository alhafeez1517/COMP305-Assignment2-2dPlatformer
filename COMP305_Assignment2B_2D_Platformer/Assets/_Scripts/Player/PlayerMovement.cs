//Program Name:PlayerMovement.cs
//Program Description:Program to move the player left and right by applying
//force to the rigidbody

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement Variables")]
    public float moveVelocity;
    public Rigidbody2D playerRig;

    void Start()
    {
        
    }


    void FixedUpdate()
    {
        Movement();
    }

    void Update()
    {
        
    }

    void Movement()
    {
        float MoveHorizontal = Input.GetAxisRaw("Horizontal");

        if (MoveHorizontal > 0.0)
        {
            playerRig.AddForce(transform.right * moveVelocity, ForceMode2D.Force);
        }

        if (MoveHorizontal < 0.0)
        {
            playerRig.AddForce(-transform.right * moveVelocity, ForceMode2D.Force);
        }
    }
}
