using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Levelbar : MonoBehaviour
{
    public Image levelBarImage;
    public LevelSystem levelSystem;
  public void UpdateLevelBar() {
    levelBarImage.fillAmount = Mathf.Clamp(levelSystem.experience / levelSystem.experienceRequired, 0, .5f);   
  }
}
