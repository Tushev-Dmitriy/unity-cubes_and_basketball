using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BestScoreScript : MonoBehaviour
{
    public Item item;

    private string filePath;

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
    public void UpdateBestScore(int currentScore)
    {
        int bestScore = GetBestScore();
        if (currentScore > bestScore)
        {
            item.BestScore = currentScore.ToString();
            SaveField();
        }
    }

    public class Item
    {
        public string BestScore;
    }
}
