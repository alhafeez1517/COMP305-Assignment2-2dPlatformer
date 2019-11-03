using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class gameController : MonoBehaviour
{
    public EnemyController enemyController;
    public AudioSource deathSound;

    private void Start()
    {
        enemyController = (EnemyController)FindObjectOfType(typeof(EnemyController));
    }

    void Update()
    {
        if (enemyController.PlayerCollide())
        {
            deathSound.Play();

            
            
        }
    }
}
