using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class bossAI : MonoBehaviour
{
    Transform player;
    public PlayerController playerController;
    public float speed;
    private float distance;

    public Animator animator;

    public float attackRange = 0.5f;

    private Vector2 direction;

    private Vector3 newXPos;

    [SerializeField] private BossLogic boss;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void Movement()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        direction = player.transform.position - transform.position;
        
        direction.Normalize();

        newXPos = new Vector3(player.transform.position.x, -2.91f, 0);


        if(animator != null)
        {
            if(distance >= attackRange)
            {
                animator.SetBool("nearPlayer", false);
                
                if(boss.isSneer)
                {
                    transform.position = transform.position + new Vector3(0,0);
                }
                else
                {
                    transform.position = Vector2.MoveTowards(this.transform.position, newXPos, speed * Time.deltaTime);
                }
                
            }
            else
            {
                animator.SetBool("nearPlayer", true);
            }
        }    
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();

        if(direction.x >= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        } else if (direction.x <= -0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
