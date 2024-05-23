using UnityEngine;

public class Portal : MonoBehaviour
{
    public Portal destinationPortal;
    public float teleportCooldown = 1f; // Adjust the cooldown duration as needed
    public float colliderDisableDuration = 0.5f; // Adjust the duration of disabling the destination portal's collider

    private bool canTeleport = true;
    private Collider2D destinationCollider;

    private void Start()
    {
        destinationCollider = destinationPortal.GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canTeleport && collision.CompareTag("Player"))
        {
            canTeleport = false;
            collision.transform.position = destinationPortal.transform.position;

            // Disable the destination portal's collider temporarily
            destinationCollider.enabled = false;
            Invoke("EnableDestinationCollider", colliderDisableDuration);

            Invoke("ResetTeleportCooldown", teleportCooldown);
        }
    }

    private void EnableDestinationCollider()
    {
        destinationCollider.enabled = true;
    }

    private void ResetTeleportCooldown()
    {
        canTeleport = true;
    }
}
