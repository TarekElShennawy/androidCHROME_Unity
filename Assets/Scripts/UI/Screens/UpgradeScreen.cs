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

    public Animator transition;

    public MovementController MoveControl;

    public Weapon WeaponControl;

    //TODO: Will need to implement a list-like system for upgrades to randomise what upgrades the three buttons provide!!! Currently the upgrade systems changes bools that enable their respective upgrades in Movement and Weapon Controller!
    void Start()
    {
        Screen.SetActive(false);

        upgradeTitle.enabled = false;

        U1Button.enabled = false;
        U2Button.enabled = false;
        U3Button.enabled = false;
    }

    public void ChooseUpgrade()
    {
        Time.timeScale = 0;


        //TODO: Closing wipe animation wont work because of the SetActive line below, not a priority currently as opening animation works.
        Screen.SetActive(true);
        upgradeTitle.enabled = true;

        U1Button.enabled = !U1Button.enabled;
        U2Button.enabled = !U2Button.enabled;
        U3Button.enabled = !U3Button.enabled;
    }

    public void Continue()
    {
        Time.timeScale = 1;

        Screen.SetActive(false);

        U1Button.enabled = !U1Button.enabled;
        U2Button.enabled = !U2Button.enabled;
        U3Button.enabled = !U3Button.enabled;

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
    
}
