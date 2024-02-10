using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    public TextScript textScript;
    public void Restart_Game()
    {
        Transform canvasTransform = GameObject.Find("Canvas").transform;
        Transform gameOverTransform = canvasTransform.Find("GameOver");

        BlockSpawner blockSpawner = FindObjectOfType<BlockSpawner>();
        CoinSpawner coinSpawner = FindObjectOfType<CoinSpawner>();

        GameObject coinObject = GameObject.FindGameObjectWithTag("Coin");
        Destroy(coinObject);
        GameObject gameOverObject = gameOverTransform.gameObject;
        GameObject timerObject = GameObject.FindGameObjectWithTag("Timer");
        Transform timerCanvasTransform = canvasTransform.Find("TimerParts");
        GameObject timerCanvasObject = timerCanvasTransform.gameObject;

        textScript.ResetScore();

        gameOverObject.SetActive(false);
        blockSpawner.SetBool(true);
        timerObject.SetActive(true);
        timerCanvasObject.SetActive(true);
        blockSpawner.SpawnBlocksAgain();
        coinSpawner.RestartSpawn(3f);

        Time.timeScale = 1f;
    }
}
