using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timer;

    public float lifeTime = 30f;
    private float gameTime;

    private void Update()
    {
        timer.text = "Time: " + lifeTime;
        gameTime += 1 * Time.deltaTime;
        if (gameTime >= 1)
        {
            lifeTime -= 1;
            gameTime = 0;
        }
        if (lifeTime <= 0)
        {
            gameTime = 0;
        }
    }
}
