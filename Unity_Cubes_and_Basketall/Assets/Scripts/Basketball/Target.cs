using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Target : MonoBehaviour
{
    private int[] targets = new int[10] { 2, 6, 12, 18, 26, 34, 42, 52, 64, 76 };
    private int currentTarget;
    private int a = 0;
    private int b = 0;
    private Transform canvasTransform;
    private Transform nextLevelTransform;
    private Transform bonusShotImageTransform;
    private Transform nextLevelMakeTransform;
    private Camera mainCam;
    private int currentScore;
    private Vector3 bonusBallPos = new Vector3(0, 0.687f, 1.085f);
    private Vector3 cameraBasePos = new Vector3(0, 0.392f, 1.687f);
    private bool restartAfterBonusShot = false;

    public GameObject bonusBallPrefab;
    public TMP_Text targetText;
    public ScoreText scoreText;
    public TimerText timerText;
    public LevelText levelText;
    public RestartScene restartScene;
    public RespawnBall respawnBall;
    public Sounds sounds;

    private void Start()
    {
        mainCam = Camera.main;
        canvasTransform = GameObject.Find("Canvas").transform;
        nextLevelTransform = canvasTransform.Find("NextLevelCanvas");
        nextLevelMakeTransform = nextLevelTransform.Find("NextLevel");
        bonusShotImageTransform = nextLevelTransform.Find("BonusShotImage");
        TargetsGenerate();
        UpdateTargetText();
    }

    private void Update()
    {
        currentScore = scoreText.GetScore();
        if (currentTarget <= currentScore)
        {
            BonusShot();
        }

        if (restartAfterBonusShot)
        {
            CameraReturn();
        }
    }

    void TargetsGenerate()
    {
        currentTarget = targets[a];
    }

    void UpdateTargetText()
    {
        targetText.text = "Target: " + currentTarget.ToString();
    }

    void RestartTarget()
    {
        a++;
        TargetsGenerate();
        UpdateTargetText();
    }

    public void ResetTarget()
    {
        a = 0;
        TargetsGenerate();
        UpdateTargetText();
    }

    public void NextLevelButton()
    {
        nextLevelMakeTransform.gameObject.SetActive(true);
    }

    public void NextLevel()
    {
        nextLevelMakeTransform.gameObject.SetActive(false);
        timerText.ResetDuration();
        restartAfterBonusShot = true;
        respawnBall.RespawnAfterBonusBall();
    }

    public void BonusShotNextLevel()
    {
        levelText.IncreaseLevel();
        timerText.TimerStop();
        RestartTarget();
        SpawnBonusBasketBall();
    }

    private void BonusShotSound()
    {
        if (nextLevelTransform.gameObject.activeSelf && b != 1)
        {
            sounds.BonusShotSound();
            b++;
        }

    }

    private void BonusShot()
    {
        restartScene.DeleteBalls();
        nextLevelTransform.gameObject.SetActive(true);
        BonusShotSound();
        Vector3 newPos = new Vector3(0, 1.228f, 0.299f);
        Quaternion newRotationPos = new Quaternion(9, 0, 0, 115);
        mainCam.transform.position = Vector3.MoveTowards(mainCam.transform.position, newPos, 0.003f);
        mainCam.transform.rotation = Quaternion.Slerp(mainCam.transform.rotation, newRotationPos, 0.0002f);
        if (mainCam.transform.position ==  newPos)
        {
            bonusShotImageTransform.gameObject.SetActive(false);
            BonusShotNextLevel();
        }
    }

    public void SpawnBonusBasketBall()
    {
        GameObject bonusBasketBall = Instantiate(bonusBallPrefab, bonusBallPos, Quaternion.identity);
        ParticleSystem fireParticles = bonusBasketBall.GetComponent<ParticleSystem>();
        fireParticles.Play();
    }

    public void CameraReturn()
    {
        mainCam.transform.position = Vector3.MoveTowards(mainCam.transform.position, cameraBasePos, 0.003f);

        if (mainCam.transform.position == cameraBasePos)
        {
            restartAfterBonusShot = false;
        }
    }
}
