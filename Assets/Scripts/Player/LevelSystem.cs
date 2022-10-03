﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelSystem : MonoBehaviour
{
    private int level;
    public int experience;

    public int experienceRequired;

    public UpgradeScreen Screen;

    [SerializeField] private TextMeshProUGUI levelUI;

    // Start is called before the first frame update
    void Start()
    {
        level = 1;
        experienceRequired = 10;

        levelUI.text = "Level: " + level.ToString();

    }
    //TODO: GET RID OF MAGIC NUMBERS BOTH HERE AND IN THE ENEMY LOGIC WHEN ADDING THE EXP!!
    //(good job though :)  you'll be able to start working on the upgrades after you improve this code )
    public void AddExperience(int enemyExperience)
    {
        experience += enemyExperience;

        if (experience >= experienceRequired)
        {
            //Level Up!
            level += 1;
            experience = 0;
            
            Screen.ChooseUpgrade();
            
            levelUI.text = "Level: " + level.ToString();
            
        }
    }
}
