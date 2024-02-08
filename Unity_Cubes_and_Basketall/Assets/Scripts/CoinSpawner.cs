using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;

    private Vector3[] SpawnPositionsArray;
    private float timeToSpawn = 3f;

    void Start()
    {
        InitializeSpawnPositions();

        StartCoroutine(SpawnCoins(timeToSpawn));
    }

    public void RestartSpawn(float timeToSpawn)
    {
        InitializeSpawnPositions();

        StartCoroutine(SpawnCoins(timeToSpawn));
    }

    IEnumerator SpawnCoins(float timeToSpawn)
    {
        yield return new WaitForSeconds(timeToSpawn);

        int randomIndex = Random.Range(0, SpawnPositionsArray.Length);
        Vector3 selectedSpawnPositions = SpawnPositionsArray[randomIndex];

        Instantiate(coinPrefab, selectedSpawnPositions, Quaternion.Euler(90, 180, 0));
    }

    void InitializeSpawnPositions()
    {
        SpawnPositionsArray = new Vector3[]
        {
            new Vector3(-1f, 0.7f, 1f), //1
            new Vector3(-1f, 0.7f, -1f), //2
            new Vector3(1f, 0.7f, -1f), //3
            new Vector3(1f, 0.7f, 1f), //4
        };
    }
}
