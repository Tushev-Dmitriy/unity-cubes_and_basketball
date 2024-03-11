using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelTextScript : MonoBehaviour
{
    public TMP_Text scoreText;
    private static int level = 1;

    public static int Level
    {
        get { return level; }
        set { level = value; }
    }

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

    public int GetLevel()
    {
        return level;
    }

    public void ResetLevel()
    {
        level = 1;
        UpdateLevelText();
    }
}
