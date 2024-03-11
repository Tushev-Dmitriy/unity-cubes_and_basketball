using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelText : MonoBehaviour
{
    public TMP_Text scoreText;
    private int level = 1;

    void Start()
    {
        UpdateLevelText();
    }

    void UpdateLevelText()
    {
        scoreText.text = "Level: " + level.ToString();
    }

    public void IncreaseLevel()
    {
        level++;
        UpdateLevelText();
    }

    public void ResetLevel()
    {
        level = 1;
        UpdateLevelText();
    }
}
