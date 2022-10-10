using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int maxHealth;
    public int health;

    public HealthPoints healthPoints;
    public SpriteRenderer spriteGFX;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip hit;


    public GameObject deathEffect;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 5;

        health = maxHealth;
    }

    public void TakeDamage (int damage)
    {
        health -= damage;

        //Visual damage effect
        spriteGFX.color = Color.red;
        StartCoroutine(whitecolor());

        //Hit audio
        audioSource.PlayOneShot(hit);

        healthPoints.removeHealthPoints();

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
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Enemy")
        {
            TakeDamage(1);
        }
    }

    //DoT when enemy on top of player
    
    /*
    private void OnTriggerStay2D(Collider2D collider)
    {
        
        if(collider.gameObject.tag == "Enemy" && damageTakenCooldown <= 0)
        {
            TakeDamage(5);
            damageTakenCooldown = 1f;
            Debug.Log("DoT");
        }
    }
    */
    
}
