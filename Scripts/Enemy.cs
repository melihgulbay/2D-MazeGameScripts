using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3f; // Speed of the enemy's up/down movement
    public float distance = 2f; // Distance the enemy moves up/down from its starting position

    private float startY;       // The y-position of the enemy's starting position
    private bool movingUp = true; // Flag indicating if the enemy is currently moving up or down

    private Rigidbody2D rb;    // Rigidbody2D component of the enemy

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;   // Set gravity scale to zero
        startY = transform.position.y; // Record the enemy's starting y-position
    }

    private void FixedUpdate()
    {
        // Move the enemy up or down
        if (movingUp)
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        }

        // Check if the enemy has reached its maximum distance from its starting position
        if (Mathf.Abs(transform.position.y - startY) >= distance)
        {
            // Reverse the direction of movement
            movingUp = !movingUp;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the enemy has collided with the Player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Restart the game
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }

        // Check if the enemy has collided with a wall
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Reverse the direction of movement
            movingUp = !movingUp;
        }
    }
}