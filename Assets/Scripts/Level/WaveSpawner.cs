using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public WaveText waveUI;

    public SetScreen victory;

    public SetScreen loss;

    public int currWave;
    public int finalWave;
    private int landSpawnIndex;
    private int airSpawnIndex;
    private Transform[] spawnpoints;
    private Vector3 spawnPos;
    private int count;
    private int enemyIndex;

    public float waveTimer;

    private float newTime;

    [SerializeField]
    private int difficultyMultiplier;

    [SerializeField]
    private GameObject[] enemyList;

    // Currently only spawns one enemy prefab type, develop so that it can take different enemy prefabs
    void Start()
    {
        count = transform.childCount;
        spawnpoints = new Transform[count];
        newTime = waveTimer;
        
        for(int i = 0; i < count; i++){
            spawnpoints[i] = transform.GetChild(i);
        }
    }

    // Spawns a number of enemies based on wave number, try make it more modular?

    void Update()
    {
        waveTimer -= Time.deltaTime;

        if (waveTimer <= 0)
        {
            newTime += 2f;
        
            if(currWave <= finalWave)
            {
                waveTimer = newTime;
                currWave += 1;

                StartCoroutine(waveUI.waveUIPopUp());

                WaveGenerator();
            }
            else
            {
                victory.ActivateScreen();
            }
        }
        else if (GameObject.Find("Player") == null)
        {
            loss.ActivateScreen();
        }
    }

    //Randomised spawn points based on a random number generator, made more modular using a list of Enemy prefabs. Spawns are semi-hardcoded (landSpawnIndex and airSpawnIndex) and has room for improvement.
    private void WaveGenerator()
    {


                for(int enemyNr = 0; enemyNr < currWave + difficultyMultiplier; ++enemyNr)
                {
                    Random.seed = System.DateTime.Now.Millisecond;
                    landSpawnIndex = Random.Range(2, 4);
                    airSpawnIndex = Random.Range(0, 2);
                    enemyIndex = Random.Range(0, 2);

                    GameObject enemySpawn = enemyList[enemyIndex];

                    switch(enemySpawn.name) 
                    {
                        case "Orc":
                        Instantiate(enemySpawn, spawnpoints[landSpawnIndex].position, enemySpawn.transform.rotation);
                        break;

                        case "BatEye":
                        Instantiate(enemySpawn, spawnpoints[airSpawnIndex].position, enemySpawn.transform.rotation);
                        break;
                    }

                    
                }
    }
}
