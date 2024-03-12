using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerShooter : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 mousePressPosition;
    private bool isShooting;
    private GameObject selectedBasketBall;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        isShooting = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 20))
            {
                if (hit.collider.CompareTag("BasketBall"))
                {
                    selectedBasketBall = hit.collider.gameObject;
                    mousePressPosition = hit.point;
                    isShooting = true;
                    gameObject.GetComponent<MoveBallOnStart>().enabled = false;
                } else if (hit.collider.CompareTag("BasketBallFire"))
                {
                    selectedBasketBall = hit.collider.gameObject;
                    mousePressPosition = hit.point;
                    isShooting = true;
                    gameObject.GetComponent<MoveBallOnStart>().enabled = false;
                }
            }
        }

        if (Input.GetMouseButtonUp(0) && isShooting)
        {
            
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 20))
            {
                Vector3 mouseReleasePosition = hit.point;
                Vector3 shootDirection = mouseReleasePosition - mousePressPosition;
                if (selectedBasketBall.CompareTag("BasketBall"))
                {
                    rb.isKinematic = false;
                    isShooting = false;
                    selectedBasketBall.GetComponent<Rigidbody>().AddForce(shootDirection * 3.5f, ForceMode.Impulse);
                } else if (selectedBasketBall.CompareTag("BasketBallFire"))
                {
                    rb.isKinematic = false;
                    isShooting = false;
                    selectedBasketBall.GetComponent<Rigidbody>().AddForce(shootDirection * 3f, ForceMode.Impulse);
                }

                selectedBasketBall = null;
            }
        }
    }
}
