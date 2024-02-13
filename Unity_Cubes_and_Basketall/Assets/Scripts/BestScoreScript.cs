using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SocialPlatforms.Impl;

public class BestScoreScript : MonoBehaviour
{
    public Item item;

    private string filePath;
    private int bestScore = 0;

    void Awake()
    {
        filePath = Path.Combine(Application.streamingAssetsPath, "base.json");
        LoadField();
    }

    public void LoadField()
    {
        if (File.Exists(filePath))
        {
            item = JsonUtility.FromJson<Item>(File.ReadAllText(filePath));
        }
        else
        {
            item = new Item();
            SaveField();
        }
    }

    public void SaveField()
    {
        File.WriteAllText(filePath, JsonUtility.ToJson(item));
    }
    public void IncreaseLevel()
    {
        bestScore++;
    }

    public int GetBestScore()
    {
        int bestScore;
        if (int.TryParse(item.BestScore, out bestScore))
        {
            return bestScore;
        }
        else
        {
            return 0;
        }
    }

    public void UpdateBestScore(int level)
    {
        int bestScore = GetBestScore();
        if (level > bestScore)
        {
            item.BestScore = level.ToString();
            SaveField();
        }
    }

    public void UpdateCoinCount(int coinCount)
    {
        item.CoinCount = coinCount;
        SaveField();
    }
    
    public int GetCoinCount()
    {
        return item.CoinCount;
    }

    public class Item
    {
        public string BestScore;
        public int CoinCount;
    }
}
