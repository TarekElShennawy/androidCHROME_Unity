using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreLogic : MonoBehaviour
{
    public int score;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI winFinalScoreText;
    [SerializeField] private TextMeshProUGUI lossFinalScoreText;
    
    //TODO: ADD A COMBO-SCORE MULTIPLIER (TIME-BASED..MAYBE BASED ON WAVE TIMER?)

    void Start()
    {
        score = 0;
    }

    public void AddScore(int value)
    {
        score += value;
    }

    void Update()
    {
        scoreText.text = score.ToString();
        winFinalScoreText.text = score.ToString();
        lossFinalScoreText.text = score.ToString();
    }
}
