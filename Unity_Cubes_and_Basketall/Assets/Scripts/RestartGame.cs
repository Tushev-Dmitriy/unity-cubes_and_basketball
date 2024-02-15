using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    public TextScript textScript;
    public LevelTextScript levelTextScript;
    public Timer timer;
    public void Restart_Game()
    {
        Transform canvasTransform = GameObject.Find("Canvas").transform;
        Transform gameOverTransform = canvasTransform.Find("GameOver");

        Transform winTransform = canvasTransform.Find("WinGame");
        GameObject winObject = winTransform.gameObject;

        BlockSpawner blockSpawner = FindObjectOfType<BlockSpawner>();
        CoinSpawner coinSpawner = FindObjectOfType<CoinSpawner>();

        GameObject coinObject = GameObject.FindGameObjectWithTag("Coin");
        Destroy(coinObject);

        Transform timerTransform = canvasTransform.Find("TimerParts");
        GameObject timerCanvasObject = timerTransform.gameObject;

        GameObject gameOverObject = gameOverTransform.gameObject;

        if (gameOverObject.activeInHierarchy)
        {
            levelTextScript.ResetLevel();
        }
        textScript.ResetScore();

        gameOverObject.SetActive(false);
        winObject.SetActive(false);
        blockSpawner.SetBool(true);
        timer.Reset();
        timerCanvasObject.SetActive(true);
        blockSpawner.SpawnBlocksAgain();
        coinSpawner.RestartSpawn(3f);

        Time.timeScale = 1f;
    }
}
