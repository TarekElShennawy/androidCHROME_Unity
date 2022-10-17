using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Run : StateMachineBehaviour
{
    public float speed = 1f;
    public float attackRange = .1f;
    Transform player;
    Rigidbody2D rb;
    BossFlip boss;

    private float distance;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponentInParent(typeof(Rigidbody2D)) as Rigidbody2D;
        boss = animator.GetComponentInParent(typeof(BossFlip)) as BossFlip;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.Flip();

        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPosition = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);

        rb.MovePosition(newPosition);

        distance = Vector2.Distance(player.position, rb.position);

        if(distance <= attackRange)
        {
            animator.SetTrigger("attack");
        }
    }
        

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("attack");
    }

}
