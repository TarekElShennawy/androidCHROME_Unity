using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioSource musicControl;
    
    [SerializeField] private AudioClip playAudio;
    public void PlayGame ()
    {
        musicControl.PlayOneShot(playAudio);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +  1);
    }
}
