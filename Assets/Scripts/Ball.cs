using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public float startingSpeed = 8f;

    [Header("Multi Ball Settings")]
    public GameObject ballPrefab;
    public float spawnOffset = 0.5f;

    // THIS prevents infinite spawning
    public bool canSpawn = true;

    void Start()
    {
        Launch();
    }

    void Launch()
    {
        float xDirection = Random.value < 0.5f ? -1f : 1f;
        float yDirection = Random.Range(-0.5f, 0.5f);

        Vector2 direction = new Vector2(xDirection, yDirection).normalized;
        rb.linearVelocity = direction * startingSpeed;
    }

    void Update()
    {
        if (Mathf.Abs(transform.position.x) >= 10f)
        {
            ResetBall();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle") && canSpawn)
        {
            SpawnNewBall();
            canSpawn = false; 
        }
    }

    void SpawnNewBall()
    {
        Vector2 direction = rb.linearVelocity.normalized;
        Vector2 spawnPosition = (Vector2)transform.position - direction * spawnOffset;

        GameObject newBall = Instantiate(ballPrefab, spawnPosition, Quaternion.identity);

        Rigidbody2D newRb = newBall.GetComponent<Rigidbody2D>();
        newRb.linearVelocity = direction * startingSpeed;
        
        newBall.GetComponent<Ball>().canSpawn = false;
    }

    void ResetBall()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = Vector2.zero;

        Launch();
    }
}