using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeCubes : MonoBehaviour
{
    private Rigidbody _rb;

    public string[] targetTags = { "Block2_0", "Block2_1", "Block2_2", "Block2_3" };

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        SecondBlockCoordinates();
    }

    private void SecondBlockCoordinates()
    {
        foreach (string targetTag in targetTags)
        {
            GameObject[] blocks = GameObject.FindGameObjectsWithTag(targetTag);

            foreach (GameObject block in blocks)
            {
                Vector3 blockPosition = block.transform.position;
                switch (targetTag)
                {
                    case "Block2_0":
                        if (blockPosition.y <= 0.35)
                        {
                            _rb.constraints = RigidbodyConstraints.FreezePositionY; 
                            break;
                        }
                        break;
                    case "Block2_1":
                        if (blockPosition.y <= 0.35)
                        {
                            _rb.constraints = RigidbodyConstraints.FreezePositionY;
                            break;
                        }
                        break;
                    case "Block2_2":
                        if (blockPosition.y <= 0.35)
                        {
                            _rb.constraints = RigidbodyConstraints.FreezePositionY;
                            break;
                        }
                        break;
                    case "Block2_3":
                        if (blockPosition.y <= 0.35)
                        {
                            _rb.constraints = RigidbodyConstraints.FreezePositionY;
                            break;
                        }
                        break;
                }
            }
        }
    }
}
