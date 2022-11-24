using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Feto;

public class ScoreManager : Singleton<ScoreManager>
{
    [SerializeField] TextMeshProUGUI scoreText;

    public int score { get; set; }

    public void AddScore(int ammount) {
        score += ammount;
        scoreText.SetText(score.ToString());
    }

    private void Start() {
        score = 0;
        scoreText.SetText(score.ToString());
    }
}
