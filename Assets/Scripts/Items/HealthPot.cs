using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPot : MonoBehaviour
{
    PlayerController Controller;

    Healthbar healthBar; 

    void Awake()
    {
        healthBar = FindObjectOfType<Healthbar>();
        Controller = FindObjectOfType<PlayerController>();
    }

    private void Heal()
    {
            Controller.health += (Controller.maxHealth * 0.3f);

            //Conditional for if the health overheals:
            if(Controller.health >= Controller.maxHealth)
            {
                Controller.health = Controller.maxHealth;
            }
            healthBar.UpdateHealthBar();
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
