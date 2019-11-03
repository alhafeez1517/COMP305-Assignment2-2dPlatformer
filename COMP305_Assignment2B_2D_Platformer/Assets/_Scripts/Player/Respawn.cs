using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
public class Respawn : MonoBehaviour
{
    public Transform SpawnPoint;

   void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeathGround")
        {
            this.transform.position = SpawnPoint.transform.position;
        }
    }
}
