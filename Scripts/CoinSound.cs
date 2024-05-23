using UnityEngine;

public class CoinSound : MonoBehaviour
{
    public AudioClip coinSound;  // The sound to play when the player collides with the coin

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Play the coin sound
            AudioSource.PlayClipAtPoint(coinSound, transform.position);

            // Destroy the coin object
            Destroy(gameObject);
        }
    }
}
