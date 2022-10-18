using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveText : MonoBehaviour
{
    public WaveSpawner wave;

    private float waveUITimer = 2.0f;
    [SerializeField] private TextMeshProUGUI waveText;
    void Start()
    {
        waveText.enabled = false;
    }

    void Update()
    {
        waveUITimer -= Time.deltaTime;
    }

    public void updateWave()
    {   
        if (wave.currWave == wave.finalWave)
        {
            
            waveText.text = "FINAL";
        }
        else if(wave.currWave < wave.finalWave)
        {
            waveText.text = "WAVE " + wave.currWave.ToString();
        }
        
    }

    public IEnumerator waveUIPopUp()
    {
        float waitTime = 0.5f;

        updateWave();

        waveText.enabled = true;

        while (waitTime > 0)
        {
        waveText.fontMaterial.SetColor("_FaceColor", Color.Lerp(Color.clear, Color.white, waitTime));
        yield return null;
        waitTime -= Time.deltaTime / 4;
        }

        waveText.enabled = false;
    }
}
