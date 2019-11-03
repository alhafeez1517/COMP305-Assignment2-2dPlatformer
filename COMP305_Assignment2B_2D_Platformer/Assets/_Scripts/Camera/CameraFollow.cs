using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class CameraFollow : MonoBehaviour
{
    
    public CameraBoundaries boundaries;

    public GameObject player;
   

    void Update()
    {
        this.transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, boundaries.xMin, boundaries.xMax),
            Mathf.Clamp(player.transform.position.y, boundaries.yMin, boundaries.yMax),transform.position.z);
    }
}

