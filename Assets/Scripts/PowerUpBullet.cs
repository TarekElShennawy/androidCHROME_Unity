using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBullet : MonoBehaviour
{   
    public float speed = 20;
    public int damage = 30;
    public Rigidbody2D rb;
    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyLogic enemy = hitInfo.GetComponent<EnemyLogic>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
