using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBall : MonoBehaviour
{
    public GameObject basketBallPrefab;
    public RandomCameraSpawn randomCameraSpawn;
    private GameObject basketBall;
    private GameObject basketballFire;
    private Camera cameraMain;
    public Target targetScript;

    private void Start()
    {
        cameraMain = Camera.main;
    }

    public void Update()
    {
        basketBall = GameObject.FindGameObjectWithTag("BasketBall");
        basketballFire = GameObject.FindGameObjectWithTag("BasketBallFire");
        if (basketBall != null)
        {
            if (basketBall.transform.position.y < -1)
            {
                basketBall.tag = "BasketBallFake";
                Destroy(basketBall, 5);
                Vector3 pos = new Vector3(0, -0.592f, 0.863f);
                randomCameraSpawn.RandomCamSpawn();
                int i = randomCameraSpawn.GetRandomNumber();
                Instantiate(basketBallPrefab, BallPosToSpawn(i), Quaternion.identity);
                basketBallPrefab.tag = "BasketBall";
            }
        } else if (basketballFire != null)
        {
            if (basketballFire.transform.position.y < -1)
            {
                Destroy(basketballFire, 3);
                targetScript.NextLevelButton();
            }
        }
    }

    public void RespawnBasketBall()
    {
        int i = randomCameraSpawn.GetRandomNumber();
        Instantiate(basketBallPrefab, BallPosToSpawn(i), Quaternion.identity);
        basketBallPrefab.tag = "BasketBall";
    }

    public void RespawnBasketBallForReplay()
    {
        Instantiate(basketBallPrefab, BallPosToSpawn(4), Quaternion.identity);
        basketBallPrefab.tag = "BasketBall";
    }

    private Vector3 BallPosToSpawn(int i)
    {
        Vector3 pos;
        switch (i)
        {
            case 0:
                pos = new Vector3(-0.65f, -0.24f, 2.883f);
                return pos;
            case 1:
                pos = new Vector3(0.67f, -0.155f, 2.883f);
                return pos;
            case 2:
                pos = new Vector3(0.3f, -0.065f, 2.93f);
                return pos;
            case 3:
                pos = new Vector3(-0.257f, -0.08f, 2.93f);
                return pos;
            case 4:
                pos = new Vector3(0f, -0.16f, 2.55f);
                return pos;
        }
        return new Vector3(0, 0 ,0);
    }

    public void RespawnAfterBonusBall()
    {
        Instantiate(basketBallPrefab, BallPosToSpawn(4), Quaternion.identity);
    }
}
