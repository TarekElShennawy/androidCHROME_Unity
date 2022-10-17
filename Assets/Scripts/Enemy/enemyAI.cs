using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class enemyAI : MonoBehaviour
{
    Transform player;
    public PlayerController playerController;
    public float speed;
    private float distance;

    public Animator animator;

    public float attackRange = 0.5f;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        speed = 2f;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();


        //I understand I could've done triggers now, I wrote this code before and implemented triggers in the boss scripts. (TODO: substitute enemy animator bools to triggers)
        if(distance >= attackRange)
        {
            animator.SetBool("nearPlayer", false);
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("nearPlayer", true);
        }
        

        if(direction.x >= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        } else if (direction.x <= -0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
