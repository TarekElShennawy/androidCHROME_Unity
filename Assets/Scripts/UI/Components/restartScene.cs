using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restartScene : MonoBehaviour
{
    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
        Time.timeScale = 1;
    }
}
