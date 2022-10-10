using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class enemyAI : MonoBehaviour
{
    Transform player;
    public PlayerController playerController;
    public float speed = 200f;
    private float distance;

    public Animator animator;

    public float attackRange = 0.5f;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        //Getting the angle between y and x directions using Tan
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

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

        //Debug.Log(distance);
    }
}
