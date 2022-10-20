using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLogic : MonoBehaviour
{
    public float maxHealth = 100;
    public float health;
    public SpriteRenderer spriteGFX;
    LevelSystem PlayerLevel;

    [SerializeField]
    private Animator animator;

    public enemyAI enemyAI;

    WaveSpawner spawner;

    [SerializeField]
    private int scoreVal;

    scoreLogic scoreLogic;

    public bool isSneer;

    private void Start ()
    {
        spriteGFX = GetComponentInChildren<SpriteRenderer>();
        PlayerLevel = FindObjectOfType<LevelSystem>();
        spawner = FindObjectOfType<WaveSpawner>();
        scoreLogic = FindObjectOfType<scoreLogic>();

        health = maxHealth;

        isSneer = false;
    }

    IEnumerator Sneer()
    {
            isSneer = true;
            animator.SetBool("isSneer", true);
            yield return new WaitForSeconds(3f);

            enemyAI.speed = 3f;
    }

    //Thank you again Brackeys for explaining how to implement damage logic!
    public void TakeDamage(int damage)
    {
        health -= damage;
        animator.SetTrigger("hurt");

        if(health <= (0.7 * maxHealth) && isSneer == false)
        {
            StartCoroutine(Sneer());
            isSneer = false;
        }

        if (health <= 0)
        {
            spawner.playerWins = true;
            scoreLogic.AddScore(scoreVal);
            animator.SetBool("isDead", true);
        }

    }

}
