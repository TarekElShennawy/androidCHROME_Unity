using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxHealth = 500f;
    public float health;

    public Healthbar healthBar;
    public SpriteRenderer spriteGFX;

    public GameObject deathEffect;
    private float damageTakenCooldown;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthBar.UpdateHealthBar();
    }

    public void TakeDamage (float damage)
    {
        health -= damage;

        //Visual damage effect
        spriteGFX.color = Color.red;
        StartCoroutine(whitecolor());

        healthBar.UpdateHealthBar();
        Debug.Log(health);

        if (health <= 0)
        {
            Die();
        }
    }

    IEnumerator whitecolor() {
        yield return new WaitForSeconds(0.5f);
        spriteGFX.color = Color.white;
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void Update()
    {
        damageTakenCooldown -= Time.deltaTime;
        //Debug.Log(damageTakenCooldown);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Enemy")
        {
            TakeDamage(10);
            damageTakenCooldown = 1f;
        }
    }

    //DoT when enemy on top of player, WORKS BUT THERE MUST BE A BETTER WAY OF IMPLEMENTING THE DAMAGE TAKEN COOL DOWN?
    private void OnTriggerStay2D(Collider2D collider)
    {
        
        if(collider.gameObject.tag == "Enemy" && damageTakenCooldown <= 0)
        {
            TakeDamage(5);
            damageTakenCooldown = 1f;
            Debug.Log("DoT");
        }
    }
    
}
