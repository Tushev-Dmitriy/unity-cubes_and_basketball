using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioClip scoreOfShot;
    public AudioClip gameOverSound;
    public AudioClip bonusShotSound;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ScoreSound()
    {
        audioSource.clip = scoreOfShot;
        audioSource.volume = 0.05f;
        audioSource.Play();
    }

    public void GameOverSound()
    {
        audioSource.clip = gameOverSound;
        audioSource.volume = 0.5f;
        audioSource.Play();
    }

    public void BonusShotSound()
    {
        audioSource.clip = bonusShotSound;
        audioSource.volume = 0.1f;
        audioSource.Play();
    }
}
