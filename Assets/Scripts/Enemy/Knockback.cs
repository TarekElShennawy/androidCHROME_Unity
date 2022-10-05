using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    [SerializeField] private float knockbackAmount;

    Rigidbody2D enemyrb;

    Bullet bullet;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Bullet")
        {
            //Tried to change transform.position but it didn't work with opposite directions (obviously)
            //Now using AddForce (thanks to Panda Strong!)
            Vector2 diff = (transform.position - other.transform.position).normalized;
            Vector2 force = diff * knockbackAmount;
            enemyrb.AddForce(force, ForceMode2D.Impulse);
        }
    }
}