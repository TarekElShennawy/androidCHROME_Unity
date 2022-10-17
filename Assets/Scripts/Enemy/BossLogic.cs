using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLogic : MonoBehaviour
{
    public float maxHealth = 100;
    public float health;
    public GameObject deathEffect;  
    public SpriteRenderer spriteGFX;
    LevelSystem PlayerLevel;

    [SerializeField]
    private Animator animator;

    public enemyAI enemyAI;

    private void Start ()
    {
        spriteGFX = GetComponentInChildren<SpriteRenderer>();
        PlayerLevel = FindObjectOfType<LevelSystem>();

        health = maxHealth;
    }

    //Thank you again Brackeys for explaining how to implement damage logic!
    public void TakeDamage(int damage)
    {
        health -= damage;
        animator.SetTrigger("hurt");

        if(health <= (0.7 * maxHealth))
        {
            animator.SetBool("isSneer", true);
            enemyAI.speed = 3f;
        }

        if (health <= 0)
        {
            Die();
            PlayerLevel.AddExperience(5);
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    
}
