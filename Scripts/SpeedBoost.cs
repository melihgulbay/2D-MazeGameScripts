using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public float boostMultiplier = 2f; // Speed boost multiplier
    public float boostDuration = 5f; // Duration of the speed boost

    private PlayerMovement playerMovement; // Reference to the PlayerMovement script
    private bool isBoostActive = false; // Flag to track if the speed boost is active
    private float originalMoveSpeed; // Original move speed of the player

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        originalMoveSpeed = playerMovement.moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SpeedBoostItem") && !isBoostActive)
        {
            isBoostActive = true;
            playerMovement.moveSpeed *= boostMultiplier;

            Destroy(collision.gameObject, boostDuration); // Destroy the speed boost item after boostDuration

            Invoke("DisableSpeedBoost", boostDuration);
        }
    }

    private void DisableSpeedBoost()
    {
        playerMovement.moveSpeed = originalMoveSpeed;
        isBoostActive = false;
    }
}
