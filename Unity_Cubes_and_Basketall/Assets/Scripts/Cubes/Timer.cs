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
    public AudioSource audioSource;
    public AudioClip tickSound;

    private Coroutine timerCoroutine;

    public GameObject gameTimerObject;

    private void Start()
    {
        Being(Duration);
    }

    private void Being(int Second)
    {
        remainingDuration = Second;
        if (timerCoroutine != null)
            StopCoroutine(timerCoroutine);
        timerCoroutine = StartCoroutine(UpdateTimer());
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

                if ((remainingDuration != 0) || (remainingDuration == 0))
                {
                    audioSource.PlayOneShot(tickSound);
                }

                yield return new WaitForSeconds(1f);
            }
            yield return null;
        }
        Time.timeScale = 0f;
        OnEnd();
    }

    private void OnEnd()
    {
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

    public void Reset()
    {
        gameTimerObject.SetActive(true);
        if (timerCoroutine != null)
            StopCoroutine(timerCoroutine);
        Start();
    }
}
