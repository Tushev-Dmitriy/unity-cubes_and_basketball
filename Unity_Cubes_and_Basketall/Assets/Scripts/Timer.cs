using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class Timer : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Pause = !Pause;
    }

    [SerializeField] private Image uiFill;
    [SerializeField] private Text uiText;

    public int Duration;

    private int remainingDuration;

    private bool Pause;

    private void Start()
    {
        Being(Duration);
    }

    private void Being(int Second)
    {
        remainingDuration = Second;
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (remainingDuration >= 0)
        {
            if (!Pause)
            {
                uiText.text = $"{remainingDuration % 60}";
                uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
                remainingDuration--;
                yield return new WaitForSeconds(1f);
            }
            yield return null;
        }
        OnEnd();
    }

    private void OnEnd()
    {
        Time.timeScale = 0f;
        Transform canvasTransform = GameObject.Find("Canvas").transform;
        Transform timerCanvasTransform = canvasTransform.Find("TimerParts");
        GameObject timerCanvasObject = timerCanvasTransform.gameObject;
        timerCanvasObject.SetActive(false);

        GameObject timerObject = GameObject.FindGameObjectWithTag("Timer");
        timerObject.SetActive(false);
        Transform gameOverTransform = canvasTransform.Find("GameOver");
        GameObject gameOverObject = gameOverTransform.gameObject;
        gameOverObject.SetActive(true);
    }
}
