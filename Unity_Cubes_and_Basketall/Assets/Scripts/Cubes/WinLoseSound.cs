using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseSound : MonoBehaviour
{
    public GameObject winLoseObject;
    public AudioClip winLoseSound;
    public AudioSource audioSource;

    private bool isGameOverActive = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (winLoseObject.activeSelf && !isGameOverActive)
        {
            PlayGameOverSound();
        }
    }

    void PlayGameOverSound()
    {
        audioSource.PlayOneShot(winLoseSound);
        isGameOverActive = true;
    }
}
