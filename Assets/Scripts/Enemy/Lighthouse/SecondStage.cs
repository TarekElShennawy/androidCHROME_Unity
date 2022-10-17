using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SecondStage : MonoBehaviour
{
    public Light2D roomLight, bloom;

    // Start is called before the first frame update
    void Start()
    {
        //roomLight = GameObject.Find("SceneLight");
    }
    
    public void lightsOff()
    {
            roomLight.intensity -= 0.5f;

            bloom.intensity += 0.3f;
    }
}