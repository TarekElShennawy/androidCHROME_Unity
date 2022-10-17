using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealthbar : MonoBehaviour
{
    public Image healthBarImage;

    public WaveSpawner spawner;
    GameObject boss;
    BossLogic enemyLogic;
    
    private float healthPercentage;

  public void UpdateHealthBar() {
    healthPercentage = (enemyLogic.health)/(enemyLogic.maxHealth);
    healthBarImage.fillAmount = healthPercentage;
  }

  void Update()
  {
    if(spawner.isBossFight == true)
    {
      boss = GameObject.FindWithTag("Boss");
      enemyLogic = boss.GetComponent<BossLogic>();
    }
      

    if(boss)
      UpdateHealthBar();
  }
}
