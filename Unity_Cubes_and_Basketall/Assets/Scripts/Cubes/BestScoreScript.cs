using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SocialPlatforms.Impl;
using System;

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
    
    public string GetGiftTime()
    {
        string giftTime = item.GiftTime;

        if (string.IsNullOrEmpty(giftTime))
        {
            return "0001-01-01 00:00:00";
        }

        return giftTime;
    }

    public void SetGiftTime()
    {
        item.GiftTime = DateTime.Now.ToString("yyyy-MM-dd HH:m:s");
        SaveField();
    }

    public int GetCoinCount()
    {
        return item.CoinCount;
    }

    public class Item
    {
        public int CoinCount;
        public string GiftTime;
    }
}
