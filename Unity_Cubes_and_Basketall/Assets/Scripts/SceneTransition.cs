using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [Header("����� �����")]

    public int sceneNumber;
    public void Transition()
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
