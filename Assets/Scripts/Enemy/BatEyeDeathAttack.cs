using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatEyeDeathAttack : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private AudioClip attackDeathAudio;
    public AudioSource enemyAudio;

    PlayerController playerController;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    //Logic for bat enemies' animation triggers aka (THE BETTER WAY)
    void DeathAttack()
    {
            playerController.TakeDamage(1);
            enemyAudio.PlayOneShot(attackDeathAudio);
            Destroy(transform.parent.gameObject,.4f);
    }
}
