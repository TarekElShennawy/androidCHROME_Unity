using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public WaveText waveUI;

    public bossUI bossHealthUI;

    public SetScreen victory;
    public SetScreen loss;

    public int currWave;
    public int finalWave;
    private int landSpawnIndex;
    private int airSpawnIndex;
    private Transform[] spawnpoints;
    [SerializeField] private Transform bossSpawnPoint;
    private int count;
    private int enemyIndex;

    public float waveTimer;

    private float newTime;

    public bool isBossFight;

    public float waveTimeIterator;

    [SerializeField]
    private int difficultyMultiplier;

    [SerializeField]
    private GameObject[] enemyList;

    [SerializeField] private GameObject boss;

    [SerializeField] private TextMeshProUGUI timerText;

    // Currently only spawns one enemy prefab type, develop so that it can take different enemy prefabs
    void Start()
    {
        count = transform.childCount;
        spawnpoints = new Transform[count];
        newTime = waveTimer;

        isBossFight = false;
        
        for(int i = 0; i < count; i++){
            spawnpoints[i] = transform.GetChild(i);
        }
    }

    // Spawns a number of enemies based on wave number, try make it more modular?

    void Update()
    {
        waveTimer -= Time.deltaTime;

        timerText.text = waveTimer.ToString("0");
        
        if (waveTimer <= 0)
        {
            newTime += waveTimeIterator;
        
            if(currWave < finalWave)
            {
                Iterate();
            }
            else
            {
                //Else, Boss fight
                if(!isBossFight)
                {
                    isBossFight = true;
                    GameObject.Destroy(timerText);
                    bossHealthUI.enableBossUI();
                    SpawnBoss();
                }
            }
        }

        if(isBossFight && GameObject.FindWithTag("Boss") == null)
            {
                victory.ActivateScreen();
            }

        if(isBossFight && GameObject.FindWithTag("Player") == null)
            {
                loss.ActivateScreen();
            }
}

    private void SpawnBoss()
    {
        Instantiate(boss, bossSpawnPoint.position, bossSpawnPoint.transform.rotation);
    }

    private void Iterate()
    {
                waveTimer = newTime;
                currWave += 1;

                StartCoroutine(waveUI.waveUIPopUp());

                WaveGenerator();
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
