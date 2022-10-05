using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMechanics : MonoBehaviour
{
    private Vector3 mousePosition;
    private Camera mainCam;



    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = mainCam.ScreenToWorldPoint(Input.mousePosition);
        
        Vector3 rotation = mousePosition - transform.position;

        //Getting the Tan of the rotation axis then turning to degrees using Rad2Deg!
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
        
        //TODO: Work on player flipping after a certain threshold of crosshair movement
        /*
        if(rotZ > 100)
        {
            Debug.Log("Flip!");
        }
        */
    }
}
