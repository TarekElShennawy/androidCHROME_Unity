using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public WaveText waveUI;

    public int currWave;
    public int finalWave;
    private int spawnIndex;
    private Transform[] spawnpoints;
    private Vector3 spawnPos;
    private int count;

    // Currently only spawns one enemy prefab type, develop so that it can take different enemy prefabs
    void Start()
    {
        count = transform.childCount;
        spawnpoints = new Transform[count];
        
        for(int i = 0; i < count; i++){
            spawnpoints[i] = transform.GetChild(i);
        }
    }

    // Spawns a number of enemies based on wave number, try make it more modular?

    void Update()
    {
        if (GameObject.Find("Enemy(Clone)") == null && currWave < finalWave)
        {
            currWave += 1;

            StartCoroutine(waveUI.waveUIPopUp());

            WaveGenerator();
        }

    }

    //Randomised spawn points based on a random number generator
    private void WaveGenerator()
    {
            if (currWave <= finalWave)
            {
                for(int enemyNr = 0; enemyNr < currWave; ++enemyNr)
                {
                    spawnIndex = Random.Range(0, count);
                    Instantiate(enemyPrefab, spawnpoints[spawnIndex].position, enemyPrefab.transform.rotation);
                }
                
            }
    }
}
