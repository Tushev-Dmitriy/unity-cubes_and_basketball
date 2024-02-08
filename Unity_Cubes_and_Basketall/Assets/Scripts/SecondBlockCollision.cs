using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class SecondBlockCollision : MonoBehaviour
{
    private bool gameLost = false;
    private BlockSpawner blockSpawner;
    private BestScoreScript bestScoreScript;
    private ÑoinTextScript coinTextScript;

    void Start()
    {
        blockSpawner = FindObjectOfType<BlockSpawner>();
        bestScoreScript = FindObjectOfType<BestScoreScript>();
        coinTextScript = FindObjectOfType<ÑoinTextScript>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Block2_0") || collision.gameObject.CompareTag("Block2_1") ||
            collision.gameObject.CompareTag("Block2_2") || collision.gameObject.CompareTag("Block2_3"))
        {
            Transform canvasTransform = GameObject.Find("Canvas").transform;
            Transform gameOverTransform = canvasTransform.Find("GameOver");

            GameObject gameOverObject = gameOverTransform.gameObject;
            gameOverObject.SetActive(true);
            Time.timeScale = 0;
        }
        else if (collision.gameObject.CompareTag("Coin"))
        {
            HandleCoinCollision(collision.gameObject);
        }
    }

    private void HandleCoinCollision(GameObject coin)
    {
        Destroy(coin);
        int currentCoinCount = bestScoreScript.GetCoinCount();
        currentCoinCount += 10;
        bestScoreScript.UpdateCoinCount(currentCoinCount);
        coinTextScript.UpdateBestScoreText(currentCoinCount);
    }

    public bool IsGameLost()
    {
        return gameLost;
    }
}
