using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSFX : MonoBehaviour
{
    public AudioSource sfxSource;
    public AudioClip footstepSFX;

    void PlaySFX()
    {
        sfxSource.PlayOneShot(footstepSFX);
    }
}
