using UnityEngine;

public class SecondBlockCollision : MonoBehaviour
{
    private bool gameLost = false;
    private BlockSpawner blockSpawner;
    private BestScoreScript bestScoreScript;
    private СoinTextScript coinTextScript;
    private ParticleSystem _particleSystem;
    public Transform target;
    private Vector3 direction;
    private Vector3 lastPosition;

    void Start()
    {
        blockSpawner = FindObjectOfType<BlockSpawner>();
        bestScoreScript = FindObjectOfType<BestScoreScript>();
        coinTextScript = FindObjectOfType<СoinTextScript>();
        _particleSystem = GetComponent<ParticleSystem>();

        lastPosition = transform.position;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Block2_0") || collision.gameObject.CompareTag("Block2_1") ||
            collision.gameObject.CompareTag("Block2_2") || collision.gameObject.CompareTag("Block2_3"))
        {
            DestroyWithVFX();

            Transform canvasTransform = GameObject.Find("Canvas").transform;            
            Transform gameOverTransform = canvasTransform.Find("GameOver");
            GameObject gameOverObject = gameOverTransform.gameObject;

            Transform timerTransform = canvasTransform.Find("TimerParts");
            GameObject timerObject = timerTransform.gameObject; 

            timerObject.SetActive(false);
            gameOverObject.SetActive(true);
        }
        else if (collision.gameObject.CompareTag("Coin"))
        {
            HandleCoinCollision(collision.gameObject);
        }
    }

    private void HandleCoinCollision(GameObject coin)
    {
        Destroy(coin);
        int currentCoinCount = bestScoreScript.GetCoinCount();
        currentCoinCount += 10;
        bestScoreScript.UpdateCoinCount(currentCoinCount);
        coinTextScript.UpdateBestScoreText(currentCoinCount);
    }

    public bool IsGameLost()
    {
        return gameLost;
    }

    void Update()
    {
        Vector3 deltaPosition = transform.position - lastPosition;
        if (deltaPosition != Vector3.zero)
        {
            lastPosition = transform.position;
            Vector2 direction = new Vector2(deltaPosition.x, deltaPosition.z).normalized;
            _particleSystem.transform.forward = new Vector3(direction.x, 0f, direction.y);
        }
    }

    private void DestroyWithVFX()
    {
        GetComponent<Renderer>().enabled = false;

        _particleSystem.simulationSpace = ParticleSystemSimulationSpace.World;
        direction = GetComponent<Rigidbody>().velocity.normalized;
        _particleSystem.transform.forward = direction.normalized;
        _particleSystem.Play();

        Destroy(gameObject, _particleSystem.main.duration);
    }
}
