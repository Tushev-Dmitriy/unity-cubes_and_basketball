using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCameraSpawn : MonoBehaviour
{
    private Vector3[] cameraPos = new Vector3[5] { new Vector3(-0.833f, 0.392f, 2.02f), new Vector3(0.833f, 0.392f, 2.02f), 
                                                   new Vector3(0.366f, 0.522f, 2.068f), new Vector3(-0.366f, 0.522f, 2.068f), 
                                                   new Vector3(0, 0.392f, 1.687f) };
    private int i;

    public void RandomCamSpawn()
    {
        i = Random.Range(0, 5);
        Camera.main.transform.position = cameraPos[i];
        switch (i)
        {
            case 0:
                Camera.main.transform.rotation = Quaternion.Euler(new Vector3(9, 10, 0));
                break;
            case 1:
                Camera.main.transform.rotation = Quaternion.Euler(new Vector3(9, -10, 0));
                break;
            case 2:
                Camera.main.transform.rotation = Quaternion.Euler(new Vector3(9, -5, 0));
                break;
            case 3:
                Camera.main.transform.rotation = Quaternion.Euler(new Vector3(9, 5, 0));
                break;
            case 4:
                Camera.main.transform.rotation = Quaternion.Euler(new Vector3(9, 0, 0));
                break;
        }
    }

    public int GetRandomNumber()
    {
        return i;
    }
}
