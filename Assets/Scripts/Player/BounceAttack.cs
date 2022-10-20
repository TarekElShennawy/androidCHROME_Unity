using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceAttack : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;

    [SerializeField] private AudioClip bounceSFX;

    public AudioSource sfxSource;

    private int bounceScore = 2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyHead"))
        {
            _rigidbody.AddForce(new Vector2(0, 5f), ForceMode2D.Impulse);

            sfxSource.PlayOneShot(bounceSFX);

            var enemy = other.gameObject.transform.parent.GetComponent<EnemyLogic>();

            var logic = FindObjectOfType<scoreLogic>();

            logic.AddScore(bounceScore);
            enemy.Die();
        }
    }
}
