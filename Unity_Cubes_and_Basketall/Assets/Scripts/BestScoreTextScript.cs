using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BestScoreTextScript : MonoBehaviour
{
    public TMP_Text bestScoreText;
    public BestScoreScript bestScoreScr;

    void Start()
    {
        UpdateBestScoreText();
    }

    public void UpdateBestScoreText()
    {
        int bestScore = bestScoreScr.GetBestScore();

        bestScoreText.text = "Best: " + bestScore.ToString();
    }
}
