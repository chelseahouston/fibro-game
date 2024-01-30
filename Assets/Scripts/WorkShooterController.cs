using UnityEngine;

public class WorkShooterController : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        // Check if the mini-game is active
        if (MiniGameManager.Instance.IsMiniGameActive)
        {
            // Handle input to move the mini-game object
            float horizontalInput = Input.GetAxis("Horizontal");
            // float verticalInput = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime;
            transform.Translate(movement);
        }
    }
}
