using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class СoinTextScript : MonoBehaviour
{
    public TMP_Text coinText;
    public BestScoreScript bestScoreScript;

    void Start()
    {
        int coinCount = bestScoreScript.GetCoinCount();
        UpdateBestScoreText(coinCount);
    }

    public void UpdateBestScoreText(int coinCount)
    {
        coinText.text = coinCount.ToString();
    }
}
