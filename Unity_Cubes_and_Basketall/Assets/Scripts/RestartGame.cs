using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    public BlockSpawner blockSpawner;
    public TextScript textScript;
    public void Restart_Game()
    {
        Transform canvasTransform = GameObject.Find("Canvas").transform;
        Transform gameOverTransform = canvasTransform.Find("GameOver");

        BlockSpawner blockSpawner = GameObject.FindObjectOfType<BlockSpawner>();

        GameObject gameOverObject = gameOverTransform.gameObject;

        textScript.ResetScore();

        gameOverObject.SetActive(false);
        blockSpawner.SetBool(true);
        blockSpawner.SpawnBlocksAgain();

        Time.timeScale = 1f;
    }
}
