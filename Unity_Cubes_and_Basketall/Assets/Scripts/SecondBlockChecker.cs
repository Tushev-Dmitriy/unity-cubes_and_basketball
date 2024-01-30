using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SecondBlockCheker : MonoBehaviour
{
    public string[] targetTags = { "Block2_0", "Block2_1", "Block2_2", "Block2_3" };
    private int score = 0;

    void Update()
    {
        TrackSecondBlockCoordinates();
    }

    void TrackSecondBlockCoordinates()
    {
        bool block2_0 = false;
        bool block2_1 = false;
        bool block2_2 = false;
        bool block2_3 = false;

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
            BlockSpawner ScriptRestart = GameObject.FindObjectOfType<BlockSpawner>();
            ScriptRestart.SpawnBlocksAgain();
            score++;
            PlayerPrefs.SetInt("Score", score);
            PlayerPrefs.Save();
            Debug.Log(score);
            block2_1 = false;
            block2_2 = false;
            block2_3 = false;

            Time.timeScale = 1f;
        }
    }
}
