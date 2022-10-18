using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoints : MonoBehaviour
{

    [SerializeField]
    private GameObject[] healthPoints = new GameObject[5];

    public PlayerController player;

    public void removeHealthPoints()
    {
        healthPoints[player.health].SetActive(false);
    }

    public void addHealthPoints()
    {
        healthPoints[player.health].SetActive(true);
    }

    public void increaseHP()
    {
        foreach(GameObject healthpoint in healthPoints)
        {
            healthpoint.SetActive(true);
        }
        
    }
}
