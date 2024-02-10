using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveSecondBlocks : MonoBehaviour
{
    public string[] targetTags = { "Block2_0", "Block2_1", "Block2_2", "Block2_3" };
    public float maxXCoordinate = 0.0f;
    public float maxZCoordinate = 0.0f;
    public float minXCoordinate = 0.0f;
    public float minZCoordinate = 0.0f;

    private SecondBlockCollision collisionHandler;

    private void Start()
    {
        collisionHandler = GetComponent<SecondBlockCollision>();  
    }

    public void MoveBlocks()
    {
        if (collisionHandler != null && collisionHandler.IsGameLost()) return;

        foreach (string targetTag in targetTags)
        {
            GameObject[] blocks = GameObject.FindGameObjectsWithTag(targetTag);

            foreach (GameObject block in blocks)
            {
                MoveBlockToTargetPosition(block, targetTag);

                float blockXCoordinate = block.transform.position.x;
                float blockZCoordinate = block.transform.position.z;

                Vector3 targetPosition = GetTargetPosition(targetTag);
            }
        }
    }

    void MoveBlockToTargetPosition(GameObject block, string tag)
    {
        float blockXCoordinate = block.transform.position.x;
        float blockZCoordinate = block.transform.position.z;

        if ((blockXCoordinate < maxXCoordinate && blockXCoordinate > minXCoordinate) &&
            (blockZCoordinate < maxZCoordinate && blockZCoordinate > minZCoordinate))
        {
            Vector3 targetPosition = GetTargetPosition(tag);
            StartCoroutine(MoveTowardsTarget(block, targetPosition));
        }
    }

    Vector3 GetTargetPosition(string tag)
    {
        Vector3 targetPosition = Vector3.zero;

        switch (tag)
        {
            case "Block2_0":
                targetPosition = new Vector3(-1f, 0.65f, 1f);
                break;
            case "Block2_1":
                targetPosition = new Vector3(-1f, 0.65f, -1f);
                break;
            case "Block2_2":
                targetPosition = new Vector3(1f, 0.65f, -1f);
                break;
            case "Block2_3":
                targetPosition = new Vector3(1f, 0.65f, 1f);
                break;
        }

        return targetPosition;
    }

    IEnumerator MoveTowardsTarget(GameObject block, Vector3 targetPosition)
    {
        if (collisionHandler != null && collisionHandler.IsGameLost()) yield break;

        float speed = 5f;

        while (block != null && Vector3.Distance(block.transform.position, targetPosition) > 0.1f)
        {
            block.transform.position = Vector3.MoveTowards(block.transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
    }
}