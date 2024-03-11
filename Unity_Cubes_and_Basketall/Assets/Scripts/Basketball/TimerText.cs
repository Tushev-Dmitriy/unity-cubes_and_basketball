using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerText : MonoBehaviour
{
    public float Duration = 30f;
    public TMP_Text timerText;
    private bool timerStop = false;

    private void Update()
    {
        if (timerStop == false && Duration > 0)
        {
            StartCoroutine(TimerCountdown());
        }
    }

    IEnumerator TimerCountdown()
    {
        timerStop = true;
        yield return new WaitForSeconds(1f);
        Duration -= 1;
        if (Duration < 10)
        {
            timerText.text = "00:0" + Duration;
        }
        else
        {
            timerText.text = "00:" + Duration;
        }

        if (Duration <= 0)
        {
            OnEndTimer();
        }
        timerStop = false;
    }
    private void OnEndTimer()
    {
        Transform canvasTransform = GameObject.Find("Canvas").transform;
        Transform gameOverTransform = canvasTransform.Find("GameOverCanvas");
        gameOverTransform.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResetDuration()
    {
        timerStop = false;
        Duration = 30f;
    }

    public void TimerStop()
    {
        StopAllCoroutines();
        timerStop = true;
    }
}
