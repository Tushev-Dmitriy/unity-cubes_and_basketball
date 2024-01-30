using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondBlockCollision : MonoBehaviour
{
    private bool gameLost = false;
    private BlockSpawner blockSpawner;

    void Start()
    {
        blockSpawner = FindObjectOfType<BlockSpawner>();
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
    }

    public bool IsGameLost()
    {
        return gameLost;
    }
}
