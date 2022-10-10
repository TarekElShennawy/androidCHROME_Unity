using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcAttack : MonoBehaviour
{
    PlayerController playerController;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
     
    public void attackPlayer()
    {
        playerController.TakeDamage(1);
    }
}