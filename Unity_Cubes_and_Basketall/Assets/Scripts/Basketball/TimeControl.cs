using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    public GameObject basketball;
    void Start()
    {
        Time.timeScale = 0;
        basketball.SetActive(false);
    }


    public void SetTime()
    {
        Time.timeScale = 1;
        basketball.SetActive(true);
    }
}
