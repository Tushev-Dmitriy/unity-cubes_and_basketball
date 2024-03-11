using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TargetScore : MonoBehaviour
{
    public TextMeshProUGUI targetText;
    public GameObject winGame;
    public TextScript textScript;

    private int target;

    void Start()
    {
        UpdateTarget();
    }

    public void UpdateTarget()
    {
        target = Random.Range(1, 6);
        UpdateTargetText(target);
    }

    public int getTarget()
    {
        return target;
    }

    void UpdateTargetText(int target)
    {
        targetText.text = "Target: " + target.ToString();
    }

    public void CheckScore()
    {
        Transform canvasTransform = GameObject.Find("Canvas").transform;
        Transform winTransform = canvasTransform.Find("WinGame");
        GameObject winObject = winTransform.gameObject;

        Transform timerTransform = canvasTransform.Find("TimerParts");
        GameObject timerObject = timerTransform.gameObject;

        Time.timeScale = 0;
        timerObject.SetActive(false);
        winObject.SetActive(true);

        GameObject[] blocks = GameObject.FindGameObjectsWithTag("CubePrefab");
        foreach (GameObject block in blocks)
        {
            Destroy(block);
        }

        string[] blockTags = { "Block2_0", "Block2_1", "Block2_2", "Block2_3" };
        foreach (string blockTag in blockTags)
        {
            GameObject[] secondBlocks = GameObject.FindGameObjectsWithTag(blockTag);
            foreach (GameObject block in secondBlocks) 
            {
                Destroy(block);
            }
        }

        GameObject coinObject = GameObject.FindGameObjectWithTag("Coin");
        Destroy(coinObject);
    }
}
