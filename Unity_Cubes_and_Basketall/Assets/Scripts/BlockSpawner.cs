using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blockPrefab;
    public GameObject blockPrefab2;
    public float spawnInterval = 0f;
    public int breakAfterCount = 4;
    public float breakDuration = 0.2f;

    public bool globalRespawn = false;
    private Vector3[] spawnPositions;
    private Vector3[][] secondSpawnPositionsArrays;
    private int i = 0;

    void Start()
    {
        InitializeSpawnPositions();

        StartCoroutine(SpawnBlocks());
        StartCoroutine(SecondSpawnBlocks());
    }

    void InitializeSpawnPositions()
    {
        spawnPositions = new Vector3[]
        {
            //центр
            new Vector3(-1f, 35f, 1f), //1
            new Vector3(-1f, 35f, -1f), //2
            new Vector3(1f, 35f, -1f), //3
            new Vector3(1f, 35f, 1f), //4
            //запад
            new Vector3(-1f, 35f, -3f), //5
            new Vector3(-1f, 35f, -5f), //6
            new Vector3(1f, 35f, -5f), //7
            new Vector3(1f, 35f, -3f), //8
            //юг
            new Vector3(3f, 35f, 1f), //9
            new Vector3(3f, 35f, -1f), //10
            new Vector3(5f, 35f, -1f), //11
            new Vector3(5f, 35f, 1f), //12
            //восток
            new Vector3(-1f, 35f, 5f), //13
            new Vector3(-1f, 35f, 3f), //14
            new Vector3(1f, 35f, 3f), //15
            new Vector3(1f, 35f, 5f), //16
            //север
            new Vector3(-5f, 35f, 1f), //17
            new Vector3(-5f, 35f, -1f), //18
            new Vector3(-3f, 35f, -1f), //19
            new Vector3(-3f, 35f, 1f), //20
        };

        secondSpawnPositionsArrays = new Vector3[][]
        {
            new Vector3[]
            {
                new Vector3(1f, 35f, -5f), //7
                new Vector3(3f, 35f, 1f), //9
                new Vector3(3f, 35f, -1f), //10
                new Vector3(5f, 35f, 1f), //12
            },
            new Vector3[]
            {
                new Vector3(5f, 35f, -1f), //11
                new Vector3(5f, 35f, 1f), //12
                new Vector3(-1f, 35f, 5f), //13
                new Vector3(-1f, 35f, 3f), //14
            },
            new Vector3[]
            {
                new Vector3(-1f, 35f, -5f), //6
                new Vector3(-1f, 35f, 5f), //13
                new Vector3(5f, 35f, -1f), //11
                new Vector3(5f, 35f, 1f), //12
            },
            new Vector3[]
            {
                new Vector3(-1f, 35f, 3f), //14
                new Vector3(1f, 35f, -5f), //7
                new Vector3(3f, 35f, 1f), //9
                new Vector3(5f, 35f, 1f), //12
            },
            new Vector3[]
            {
                new Vector3(-1f, 35f, -3f), //5
                new Vector3(-1f, 35f, -5f), //6
                new Vector3(-3f, 35f, 1f), //20
                new Vector3(1f, 35f, 3f), //15
            },
            new Vector3[]
            {
                new Vector3(3f, 35f, 1f), //9
                new Vector3(1f, 35f, 3f), //15
                new Vector3(1f, 35f, 5f), //16
                new Vector3(-5f, 35f, -1f), //18
            },
            new Vector3[]
            {
                new Vector3(1f, 35f, -5f), //7
                new Vector3(1f, 35f, -3f), //8
                new Vector3(3f, 35f, -1f), //10
                new Vector3(-1f, 35f, 5f), //13
            },
        };
    }
    public void SpawnBlocksAgain()
    {
        if (globalRespawn) 
        {
            GameObject[] existingBlocks = GameObject.FindGameObjectsWithTag("CubePrefab");
            foreach (GameObject block in existingBlocks)
            {
                Destroy(block);
            }

            GameObject[] existingBlocks2;

            for (int i = 0; i < 4; i++)
            {
                existingBlocks2 = GameObject.FindGameObjectsWithTag($"Block2_{i}");
                foreach (GameObject block in existingBlocks2)
                {
                    Destroy(block);
                }
            }

            SpawnBlock();

        } else
        {
            GameObject[] existingBlocks2;

            for (int i = 0; i < 4; i++)
            {
                existingBlocks2 = GameObject.FindGameObjectsWithTag($"Block2_{i}");
                foreach (GameObject block in existingBlocks2)
                {
                    Destroy(block);
                }
            }

            SpawnBlock();
        }

    }

    private void SpawnBlock()
    {
        if (globalRespawn)
        {
            StartCoroutine(SpawnBlocks());
            StartCoroutine(SecondSpawnBlocks());
        } else
        {
            StartCoroutine(SecondSpawnBlocks());
        }
    }

    IEnumerator SpawnBlocks()
    {
        int spawnCount = 0;

        foreach (Vector3 spawnPosition in spawnPositions)
        {
            GameObject block = Instantiate(blockPrefab, spawnPosition, Quaternion.identity);

            spawnCount++;

            if (spawnCount >= breakAfterCount)
            {
                spawnCount = 0;
                yield return new WaitForSeconds(breakDuration);
            }

            yield return new WaitForSeconds(spawnInterval);
        }

        yield return null;
    }

    IEnumerator SecondSpawnBlocks()
    {
        while (i < 1)
        {
            globalRespawn = true;
            i++;
        }

        if (globalRespawn)
        {
            yield return new WaitForSeconds(2f);
        }

        int spawnCount = 0;

        int randomIndex = Random.Range(0, secondSpawnPositionsArrays.Length);
        Vector3[] selectedSpawnPositionsArray = secondSpawnPositionsArrays[randomIndex];

        foreach (Vector3 secondSpawnPosition in selectedSpawnPositionsArray)
        {
            GameObject block2 = Instantiate(blockPrefab2, secondSpawnPosition, Quaternion.identity);

            CoordForBlocks(block2, secondSpawnPosition);

            spawnCount++;

            if (spawnCount >= breakAfterCount)
            {
                spawnCount = 0;
                yield return new WaitForSeconds(breakDuration);
            }

            yield return new WaitForSeconds(spawnInterval);
        }

        globalRespawn = false;
    }

    void CoordForBlocks(GameObject block, Vector3 position)
    {
        if ((position.x == -1 && position.z == -3) || (position.x == 3 && position.z == 1) ||
            (position.x == -1 && position.z == 5) || (position.x == -5 && position.z == 1))
        {
            block.tag = "Block2_0";
        }
        else if ((position.x == -1 && position.z == -5) || (position.x == 3 && position.z == -1) ||
            (position.x == -1 && position.z == 3) || (position.x == -5 && position.z == -1))
        {
            block.tag = "Block2_1";
        }
        else if ((position.x == 1 && position.z == -5) || (position.x == 5 && position.z == -1) ||
            (position.x == 1 && position.z == 3) || (position.x == -3 && position.z == -1))
        {
            block.tag = "Block2_2";
        }
        else if ((position.x == 1 && position.z == -3) || (position.x == 5 && position.z == 1) ||
            (position.x == 1 && position.z == 5) || (position.x == -3 && position.z == 1))
        {
            block.tag = "Block2_3";
        }
    }

    public void SetBool(bool value)
    {
        globalRespawn = value;
    }
}
