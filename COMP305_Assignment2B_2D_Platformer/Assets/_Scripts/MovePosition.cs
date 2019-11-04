using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePosition : MonoBehaviour
{
    //public Transform targetPosition;
    //public Transform startingPosition;
    public GameObject[] positions;
    private int index = 0;
    public float moveSpeed;
    //public bool IsMovingUp;
    //public bool IsMovingDown;

    
    void Start()
    {
       
       
    }

  
    void Update()
    {
       
        if (Vector3.Distance(positions[index].transform.position,transform.position)<0.8f)
        {
            index++;
            if (index >= positions.Length)
            {
                index = 0;
            }
            //transform.position = Vector3.MoveTowards(transform.position, startingPosition.position, 0.04f);
        }

        transform.position = Vector3.MoveTowards(transform.position,positions[index].transform.position, moveSpeed);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.collider.transform.SetParent(this.gameObject.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.collider.transform.SetParent(null);
        }
    }





}
