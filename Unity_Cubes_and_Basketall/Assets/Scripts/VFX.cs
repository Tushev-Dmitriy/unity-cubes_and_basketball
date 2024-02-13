using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX : MonoBehaviour
{
    [SerializeField] GameObject fireVFX;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Block2_0") || collision.gameObject.CompareTag("Block2_1") ||
            collision.gameObject.CompareTag("Block2_2") || collision.gameObject.CompareTag("Block2_3"))
        {
            Destroy(gameObject);
            GameObject explosion = Instantiate(fireVFX, transform.position, transform.rotation);
            Destroy(explosion, 1f);
        }
    }
}
