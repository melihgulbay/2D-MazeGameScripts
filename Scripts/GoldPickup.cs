using UnityEngine;
using UnityEngine.UI;

public class GoldPickup : MonoBehaviour
{
    public int coinValue = 1; // The value of the coin
    private bool isCollected = false; // Whether the coin has been collected or not
    public Text coinText; // The text object to display the coin count
    private static int coinsCollected = 0; // The total number of coins collected
    public SpriteRenderer kumasSprite; // The kumas sprite renderer

    // Find the coinText object and kumas sprite renderer on start
    private void Start()
    {
        coinsCollected = 0;
        coinText = GameObject.Find("CoinText")?.GetComponent<Text>();
        if (coinText == null)
        {
            Debug.LogError("CoinText GameObject not found!");
        }

        kumasSprite = GameObject.Find("Kumas").GetComponent<SpriteRenderer>();
        kumasSprite.enabled = false; // Disable the kumas sprite by default
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            isCollected = true; // Set isCollected to true to avoid collecting the same coin multiple times
            Destroy(gameObject); // Destroy the coin object
            UpdateCoinCount(); // Update the coin count
            CheckCoinTotal(); // Check if the total number of coins collected is 3
        }
    }

    // Update the coin count and display it on the screen
    private void UpdateCoinCount()
    {
        int currentCoins = int.Parse(coinText.text.Split(':')[1].Trim()); // Parse the current coin count from the text
        currentCoins += coinValue; // Add the coin value to the current coin count
        coinText.text = "Collected Items: " + currentCoins.ToString(); // Update the coin text
        coinsCollected++; // Increment the total number of coins collected
        Debug.Log("Coins collected: " + coinsCollected);

        kumasSprite.enabled = true; // Enable the kumas sprite when gold is picked up
    }

    // Check if the total number of coins collected is 3, and destroy all game objects with the "Door" tag
    private void CheckCoinTotal()
    {
        if (coinsCollected >= 1)
        {
            GameObject[] doors = GameObject.FindGameObjectsWithTag("Door");
            foreach (GameObject door in doors)
            {
                Destroy(door);
            }
        }

        if (coinsCollected >= 4)
        {
            GameObject[] doors2 = GameObject.FindGameObjectsWithTag("Door2");
            foreach (GameObject door2 in doors2)
            {
                Destroy(door2);
            }
        }
        if (coinsCollected >= 4)
        {
            GameObject[] doors3 = GameObject.FindGameObjectsWithTag("Door3");
            foreach (GameObject door3 in doors3)
            {
                Destroy(door3);
            }
        }
        if (coinsCollected >= 4)
        {
            GameObject[] doors4 = GameObject.FindGameObjectsWithTag("Door4");
            foreach (GameObject door4 in doors4)
            {
                Destroy(door4);
            }
        }
    }
}