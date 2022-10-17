using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Animator animator;
    public AudioSource audioSource;
    public AudioClip shootingAudio;
    public AudioClip reloadingAudio;
    public GameObject powerUp;
    public bool powerUpEnabler;
    public float animationTime = 0.5f;
    private float cooldownValue;
    private float knockbackValue;
    public ScreenShake shaker;

    public ReloadUI reloadUI;

    public int magazineSize, currentBullets;
    private float reloadTime;

    private bool isReloading;

    private void Start()
    {
        powerUpEnabler = false;

        cooldownValue = 0f;

        knockbackValue = 2f;

        magazineSize = 5;

        currentBullets = magazineSize;

        reloadTime = 1f;
    }

    private IEnumerator Shoot()
    {
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

    IEnumerator Reload()
    {
        isReloading = true;

        yield return new WaitForSeconds(reloadTime);

        currentBullets = magazineSize;

        audioSource.PlayOneShot(reloadingAudio);

        reloadUI.addAmmo();

        isReloading = false;
    }

    void Update()
    {
        cooldownValue -= Time.deltaTime;

        if(isReloading)
            return;

        if(currentBullets <= 0 || Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
            return;
        }

        if(Input.GetButtonDown("Fire1") && WeaponCooldown(cooldownValue) && currentBullets > 0)
        {
            StartCoroutine(Shoot());
            StartCoroutine(shaker.Shake()); 
            cooldownValue = .1f;
            currentBullets--;
            reloadUI.removeAmmo();
        }
    }
}
