using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Levelbar : MonoBehaviour
{
    public Image levelBarImage;
    public LevelSystem levelSystem;
    
    private float levelPercentage;

  public void UpdateLevelBar() {
    levelPercentage = (levelSystem.experience)/(levelSystem.experienceRequired);
    levelBarImage.fillAmount = levelPercentage;
  }

  void Update()
  {
    UpdateLevelBar();
  }
}
