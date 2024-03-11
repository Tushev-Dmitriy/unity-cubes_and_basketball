using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    GameObject basketball;
    GameObject[] basketballFake;
    GameObject basketballFire;
    public TimerText timerText;
    public RespawnBall respawnBall;
    public ScoreText scoreText;
    public Target targetText;
    public LevelText levelText;
    public void RestarLevel()
    {
        DeleteBalls();
        Transform canvasTransform = GameObject.Find("Canvas").transform;
        Transform gameOverTransform = canvasTransform.Find("GameOverCanvas");
        gameOverTransform.gameObject.SetActive(false);
        timerText.ResetDuration();
        respawnBall.RespawnBasketBall();
        scoreText.ResetScore();
        targetText.ResetTarget();
        levelText.ResetLevel();
        Time.timeScale = 1;
    }

    public void DeleteBalls()
    {
        basketball = GameObject.FindGameObjectWithTag("BasketBall");
        basketballFake = GameObject.FindGameObjectsWithTag("BasketBallFake");
        basketballFire = GameObject.FindGameObjectWithTag("BasketBallFire");
        if (basketball != null && basketballFake != null)
        {
            Destroy(basketball);
            for (int i = 0; i < basketballFake.Length; i++)
            {
                Destroy(basketballFake[i]);
            }
        }
        else if (basketball != null && basketballFake == null)
        {
            Destroy(basketball);
        }
        else if (basketball == null && basketballFake != null)
        {
            for (int i = 0; i < basketballFake.Length; i++)
            {
                Destroy(basketballFake[i]);
            }
        }

        if (basketballFire != null)
        {
            Destroy(basketballFire);
        }
    }
}
