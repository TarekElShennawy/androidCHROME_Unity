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
    private float cooldownValue;
    private float knockbackValue;

    public ScreenShake shaker;

    private void Start()
    {
        powerUpEnabler = false;

        cooldownValue = 0f;

        knockbackValue = 2f;
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
        //animator.SetBool("isShooting", true);
        audioSource.PlayOneShot(shootingAudio);
        //controller.KnockbackEffect(knockbackValue);

        if(powerUpEnabler)
        {
            Instantiate(powerUp , transform.position, transform.rotation);
        }
        else
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }

        yield return new WaitForSeconds(animationTime);
        //animator.SetBool("isShooting", false);
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

        if(controller.isCrouching == true && Input.GetButtonDown("Fire1") && WeaponCooldown(cooldownValue)  )
        {
            StartCoroutine(CrouchShot());
            cooldownValue = .1f;
        }
        else if(controller.shootingUp == true && Input.GetButtonDown("Fire1") && WeaponCooldown(cooldownValue))
        {
            StartCoroutine(UpShot());
            cooldownValue = .1f;
        }
        else if(Input.GetButtonDown("Fire1") && WeaponCooldown(cooldownValue))
        {
            StartCoroutine(Shoot());
            StartCoroutine(shaker.Shake()); 
            cooldownValue = .1f;
        }
    }
}
