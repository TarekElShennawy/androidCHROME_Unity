using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;

    public Transform firePoint_crouch;

    public Transform firePoint_up;
    public GameObject bulletPrefab;
    public Animator animator;
    public AudioSource audioSource;
    public AudioClip shootingAudio;
    public MovementController controller;
    public GameObject powerUp;

    public bool powerUpEnabler;

    public float animationTime = 0.5f;
    private float cooldownValue = 0f;

    private void Start()
    {
        powerUpEnabler = false;
    }

    private IEnumerator CrouchShot()
    {

        audioSource.PlayOneShot(shootingAudio);
        Instantiate(bulletPrefab, firePoint_crouch.position, firePoint_crouch.rotation);

        yield return new WaitForSeconds(animationTime);
    }

    private IEnumerator UpShot()
    {

        audioSource.PlayOneShot(shootingAudio);
        Instantiate(bulletPrefab, firePoint_up.position, firePoint_up.rotation);

        yield return new WaitForSeconds(animationTime);
    }

    private IEnumerator Shoot()
    {
        animator.SetBool("isShooting", true);
        audioSource.PlayOneShot(shootingAudio);

        if(powerUpEnabler)
        {
            Instantiate(powerUp , transform.position, transform.rotation);
        }
        else
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }

        yield return new WaitForSeconds(animationTime);
        animator.SetBool("isShooting", false);
    }

    private bool WeaponCooldown(float cooldownValue)
    {
        if (cooldownValue <= 0)
        {
            return true;
        }
        else{
            return false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        cooldownValue -= Time.deltaTime;

        //TODO: Put cooldown value reset in coroutines? maybe.
        if(controller.isCrouching == true && Input.GetButtonDown("Fire1") && WeaponCooldown(cooldownValue)  )
        {
            StartCoroutine(CrouchShot());
            cooldownValue = .5f;
        }
        else if(controller.shootingUp == true && Input.GetButtonDown("Fire1") && WeaponCooldown(cooldownValue))
        {
            StartCoroutine(UpShot());
            cooldownValue = .5f;
        }
        else if(Input.GetButtonDown("Fire1") && WeaponCooldown(cooldownValue))
        {
            StartCoroutine(Shoot());
            cooldownValue = .5f;
        }
    }
}
