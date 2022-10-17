using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFlip : MonoBehaviour
{
    Transform player;
    public bool isFlipped = false;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    public void Flip()
    {
        Vector2 direction = player.position - transform.position;

        if(direction.x >= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        } else if (direction.x <= -0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
