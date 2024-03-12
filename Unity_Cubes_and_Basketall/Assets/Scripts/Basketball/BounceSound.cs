using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BounceSound : MonoBehaviour
{
    public AudioClip bounceSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "BasketBall" || gameObject.tag == "BasketBallFire")
        {
            audioSource.PlayOneShot(bounceSound);
        }
    }
}
