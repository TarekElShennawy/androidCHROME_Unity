using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossUI : MonoBehaviour
{
    public GameObject bossUIParent;

    // Start is called before the first frame update
    void Start()
    {
        disableBossUI();
    }

    public void enableBossUI()
    {
        bossUIParent.SetActive(true);
    }

    public void disableBossUI()
    {
        bossUIParent.SetActive(false);
    }


}
