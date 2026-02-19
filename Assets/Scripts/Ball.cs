using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public float startingSpeed = 8f;

    void Start()
    {
        Launch();
    }

    void Launch()
    {
        float xDirection = Random.value < 0.5f ? -1f : 1f;

        // Limit vertical angle so it doesn't go almost straight up
        float yDirection = Random.Range(-0.5f, 0.5f);

        Vector2 direction = new Vector2(xDirection, yDirection).normalized;

        rb.linearVelocity = direction * startingSpeed;
    }

    void Update()
    {
        // If ball goes past left or right bounds, reset
        if (Mathf.Abs(transform.position.x) >= 10f)
        {
            ResetBall();
        }
    }

    void ResetBall()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = Vector2.zero;

        Launch();
    }
}