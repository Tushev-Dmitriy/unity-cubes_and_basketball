using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SocialPlatforms.Impl;

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
        public int CoinCount;
    }
}
