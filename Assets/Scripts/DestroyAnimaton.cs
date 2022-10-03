using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAnimaton : MonoBehaviour
{
    public float delay = 4f;
    public GameObject animation;
 
     // Use this for initialization
     void Update() {

        delay -= Time.deltaTime;

        if(delay <= 0)
        {
            Destroy (animation);
        }
         
     }
}
