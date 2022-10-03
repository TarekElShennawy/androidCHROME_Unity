using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public int maxHealth = 100;
    public int health;
    public GameObject deathEffect;
    public SpriteRenderer spriteGFX;

    LevelSystem PlayerLevel;

    [SerializeField]
    private GameObject HealthObj;
    private bool hit;

    private void Start ()
    {
        spriteGFX = GetComponentInChildren<SpriteRenderer>();
        PlayerLevel = FindObjectOfType<LevelSystem>();

        health = maxHealth;
    }

    //Current function works just for Health Game Object, refactor to use a list of items :) 
    private void DropLoot(GameObject HealthPot)
    {
        float lootDecider = Random.Range(0, 2);

        // 2/3 chance that the health is dropped (if lootDecider is 0 no loot drops, but if 1 or 2 then health drops!)
        if(lootDecider > 0)
        {
            Instantiate(HealthPot, transform.position, Quaternion.identity);
        }
    }

    //Thank you again Brackeys for explaining how to implement damage logic!
    public void TakeDamage(int damage)
    {
        health -= damage;

        //Visual damage effect
        spriteGFX.color = Color.red;
        StartCoroutine(whitecolor());


        if (health <= 0)
        {
            Die();
            PlayerLevel.AddExperience(5);
            DropLoot(HealthObj);
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
}
