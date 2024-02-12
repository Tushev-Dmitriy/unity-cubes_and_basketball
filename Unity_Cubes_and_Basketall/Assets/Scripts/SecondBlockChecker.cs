using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondBlockCheker : MonoBehaviour
{
    public string[] targetTags = { "Block2_0", "Block2_1", "Block2_2", "Block2_3" };
    public TextScript textScript;
    public BestScoreScript bestScoreScript;

    private bool block2_0 = false;
    private bool block2_1 = false;
    private bool block2_2 = false;
    private bool block2_3 = false;

    void Update()
    {
        TrackSecondBlockCoordinates();
    }

    void TrackSecondBlockCoordinates()
    {
        foreach (string targetTag in targetTags)
        {
            GameObject[] blocks = GameObject.FindGameObjectsWithTag(targetTag);

            foreach (GameObject block in blocks)
            {
                Vector3 blockPosition = block.transform.position;
                switch (targetTag)
                {
                    case "Block2_0":
                        if ((blockPosition.x > -1.15 && blockPosition.x < -0.85) && (blockPosition.z < 1.15 && blockPosition.z > 0.85))
                        {
                            block2_0 = true;
                        }
                        break;
                    case "Block2_1":
                        if ((blockPosition.x > -1.15 && blockPosition.x < -0.85) && (blockPosition.z > -1.15 && blockPosition.z < -0.85))
                        {
                            block2_1 = true;
                        }
                        break;
                    case "Block2_2":
                        if ((blockPosition.x < 1.15 && blockPosition.x > 0.85) && (blockPosition.z > -1.15 && blockPosition.z < -0.85))
                        {
                            block2_2 = true;
                        }
                        break;
                    case "Block2_3":
                        if ((blockPosition.x < 1.15 && blockPosition.x > 0.85) && (blockPosition.z < 1.15 && blockPosition.z > 0.85))
                        {
                            block2_3 = true;
                        }
                        break;
                }
            }
        }

        if (block2_0 && block2_1 && block2_2 && block2_3)
        {
            textScript.IncreaseScore();

            int currentScore = textScript.GetScore();
            int bestScore = bestScoreScript.GetBestScore();

            if (currentScore > bestScore)
            {
                bestScoreScript.UpdateBestScore(currentScore);
            }

            TargetScore target = GameObject.FindObjectOfType<TargetScore>();
            if (currentScore >= target.getTarget())
            {
                Time.timeScale = 0f;
                target.CheckScore();
                target.UpdateTarget();  

                block2_0 = false;
                block2_1 = false;
                block2_2 = false;
                block2_3 = false;
            } else 
            {
                BlockSpawner blockSpawner = GameObject.FindObjectOfType<BlockSpawner>();
                CoinSpawner coinSpawner = GameObject.FindObjectOfType<CoinSpawner>();

                blockSpawner.SpawnBlocksAgain();
                coinSpawner.RestartSpawn(0.01f);

                block2_0 = false;
                block2_1 = false;
                block2_2 = false;
                block2_3 = false;

                Time.timeScale = 1f;
            }
        }
    }
}
