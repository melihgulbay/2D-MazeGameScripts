using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy2 : MonoBehaviour
{
    public float moveSpeed = 3f; // Speed of the enemy's left/right movement
    public float distance = 2f; // Distance the enemy moves left/right from its starting position

    private float startX;       // The x-position of the enemy's starting position
    private bool movingRight = true; // Flag indicating if the enemy is currently moving right or left

    private Rigidbody2D rb;    // Rigidbody2D component of the enemy

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;   // Set gravity scale to zero
        startX = transform.position.x; // Record the enemy's starting x-position
    }

    private void FixedUpdate()
    {
        // Move the enemy left or right
        if (movingRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }

        // Check if the enemy has reached its maximum distance from its starting position
        if (Mathf.Abs(transform.position.x - startX) >= distance)
        {
            // Reverse the direction of movement
            movingRight = !movingRight;
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
            movingRight = !movingRight;
        }
    }
}
