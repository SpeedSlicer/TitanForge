using UnityEngine;

public class Grounded : MonoBehaviour
{
    public PlayerController playerController;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            if (playerController != null)
            {
                playerController.isGrounded = true;
            }
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            if (playerController != null)
            {
                playerController.isGrounded = false;
            }
        }
    }

}
