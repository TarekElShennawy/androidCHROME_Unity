using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighthouseAudio : MonoBehaviour
{

    public AudioSource lighthouseSfxSource;

    public AudioClip whirringSFX;
    public AudioClip shotSFX;

    void PlayWhirring()
    {
        lighthouseSfxSource.PlayOneShot(whirringSFX);
    }

    void PlayShot()
    {
        lighthouseSfxSource.PlayOneShot(shotSFX);
    }
}
