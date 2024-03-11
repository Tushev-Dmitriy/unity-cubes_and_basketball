using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveBallOnStart : MonoBehaviour
{
    private float speed = 0.1f;
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        float newY = startPos.y + (Mathf.Sin(Time.time)/2) * speed;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
