using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public float timeLimit = 60f; // Time limit in seconds
    public float timeIncreaseAmount = 5f; // Amount to increase time when colliding with the item

    private float currentTime;
    private bool gameEnded = false;

    private Text timerText; // Updated to private

    void Start()
    {
        currentTime = timeLimit;

        // Find the Text component with the name "timerText"
        timerText = GameObject.Find("timerText").GetComponent<Text>();

        // Check if the Text component was found
        if (timerText == null)
        {
            Debug.LogError("Timer Text component not found in the scene!");
        }
    }

    void Update()
    {
        if (!gameEnded)
        {
            currentTime -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.RoundToInt(currentTime).ToString();

            if (currentTime <= 0)
            {
                EndGame();
            }
        }
    }

    void EndGame()
    {
        gameEnded = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            currentTime += timeIncreaseAmount;
            Destroy(collision.gameObject); // Destroy the item after collision
        }
    }
}
