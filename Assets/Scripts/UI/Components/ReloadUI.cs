using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadUI : MonoBehaviour
{
    [SerializeField]
    private GameObject[] ammo = new GameObject[6];

    public Weapon weaponControl;

    public void removeAmmo()
    {
        ammo[weaponControl.currentBullets].SetActive(false);
    }

    public void addAmmo()
    {
        for(int i = 0; i < weaponControl.currentBullets; i++)
        {
            ammo[i].SetActive(true);
        }
    }

    public void increaseAmmo()
    {
        ammo[5].SetActive(true);
        addAmmo();
    }
}
