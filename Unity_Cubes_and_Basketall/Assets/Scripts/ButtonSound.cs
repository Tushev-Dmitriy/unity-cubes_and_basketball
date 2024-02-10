using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour
{
    public Button[] button;
    public AudioSource audioSource;

    void Start()
    {
        for (int i = 0; i < button.Length; i++)
        {
            button[i].onClick.AddListener(ClickSound);
        }
    }

    void ClickSound()
    {
        audioSource.Play();
    }
}
