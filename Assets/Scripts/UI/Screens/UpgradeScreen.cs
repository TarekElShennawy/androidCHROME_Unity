using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UpgradeScreen : MonoBehaviour
{
    [SerializeField] private GameObject Screen;
    [SerializeField] private TextMeshProUGUI upgradeTitle;
    [SerializeField] private TextMeshProUGUI NAUpgradeText;
    [SerializeField] private Button U1Button;
    [SerializeField] private Button U2Button;
    [SerializeField] private Button U3Button;
    [SerializeField] private Button U4Button;
    [SerializeField] private Button U5Button;

    public Animator transition;

    public MovementController MoveControl;

    public Weapon WeaponControl;

    public PlayerController PlayerControl;

    public HealthPoints healthUI;

    public ReloadUI reloadUI;

    //TODO: Will need to implement a list-like system for upgrades to randomise what upgrades the three buttons provide!!! Currently the upgrade systems changes bools that enable their respective upgrades in Movement and Weapon Controller!
    void Start()
    {
        Screen.SetActive(false);

        upgradeTitle.enabled = false;
    }

    public void ChooseUpgrade()
    {
        Time.timeScale = 0;

        Screen.SetActive(true);
        upgradeTitle.enabled = true;
    }

    public void Continue()
    {
        Time.timeScale = 1;

        Screen.SetActive(false);

        transition.SetTrigger("Continue");
    }

    //Upgrade enablers
    public void enableDoubleJump()
    {
        MoveControl.doubleJumpEnabler = true;

        U1Button.enabled = false;
        U1Button.GetComponent<Image>().enabled = false;
        Continue();
    }

    public void enablePowerUp()
    {
        WeaponControl.powerUpEnabler = true;

        U2Button.enabled = false;
        U2Button.GetComponent<Image>().enabled = false;
        Continue();
    }

    public void enableDoubleSpeed()
    {
        MoveControl.speedMultiplier = 2;

        U3Button.enabled = false;
        U3Button.GetComponent<Image>().enabled = false;
        Continue();
    }

    public void enableHealthIncrease()
    {
        PlayerControl.maxHealth += 1;
        PlayerControl.health = PlayerControl.maxHealth;
        healthUI.increaseHP();

        U4Button.enabled = false;
        U4Button.GetComponent<Image>().enabled = false;
        Continue();
    }

    public void enableAmmoIncrease()
    {
        WeaponControl.magazineSize += 1;
        WeaponControl.currentBullets = WeaponControl.magazineSize;
        reloadUI.increaseAmmo();

        U5Button.enabled = false;
        U5Button.GetComponent<Image>().enabled = false;
        Continue();
    }
    
}
