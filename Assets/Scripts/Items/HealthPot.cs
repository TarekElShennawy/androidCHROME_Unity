using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPot : MonoBehaviour
{
    PlayerController Controller;

    HealthPoints healthPoints; 

    void Awake()
    {
        healthPoints = FindObjectOfType<HealthPoints>();
        Controller = FindObjectOfType<PlayerController>();
    }

    private void Heal()
    {
            
            //Conditional for if the health overheals:
            if(Controller.health >= Controller.maxHealth)
            {
                Controller.health = Controller.maxHealth;
            }
            else{
                healthPoints.addHealthPoints();
                Controller.health += 1;
            }
            Object.Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            Heal();
        }
    }
}
