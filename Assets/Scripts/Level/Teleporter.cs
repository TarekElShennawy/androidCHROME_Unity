using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField]
    private GameObject TeleporterL;
    
    [SerializeField]
    private GameObject TeleporterR;

    [SerializeField]
    private GameObject LDrop;
    
    [SerializeField]
    private GameObject RDrop;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" && gameObject.name == "TeleporterL")
        {
            collider.transform.position = RDrop.transform.position;
            Debug.Log("Teleport Right!");
        }
        else if (collider.tag == "Player" && gameObject.name == "TeleporterR")
        {
            collider.transform.position = LDrop.transform.position;
            Debug.Log("Teleport Left!");
        }
    }
}
