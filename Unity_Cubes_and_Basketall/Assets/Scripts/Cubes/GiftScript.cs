using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class GiftScript : MonoBehaviour
{
    public BestScoreScript bestScoreScript;
    public void Click()
    {
        DateTime timeNow = DateTime.Now;
        string giftTimeCheck = bestScoreScript.GetGiftTime();
        DateTime giftTime = DateTime.Parse(giftTimeCheck).AddDays(1);
        if (giftTime < timeNow)
        {
            bestScoreScript.UpdateCoinCount(bestScoreScript.GetCoinCount() + 100);
            bestScoreScript.SetGiftTime();
        }
        else
        {
            Debug.Log("рано");
        }
    }
}

