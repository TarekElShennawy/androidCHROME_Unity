using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Healthbar : MonoBehaviour
{
  public Image healthBarImage;
  public PlayerController player;
  public void UpdateHealthBar() {
    healthBarImage.fillAmount = Mathf.Clamp(player.health / player.maxHealth, 0, 1f);
    
  }
}
