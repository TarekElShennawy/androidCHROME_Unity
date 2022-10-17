using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScreen : MonoBehaviour
{
    [SerializeField] private GameObject Screen;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetActive(false);
    }

    public void ActivateScreen()
    {

        Screen.SetActive(true);
    }
}
