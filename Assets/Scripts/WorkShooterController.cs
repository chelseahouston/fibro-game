using TMPro;
using UnityEngine;

public class WorkShooterController : MonoBehaviour
{
    public float moveSpeed;
    public int numberOfLives, score;
    public TextMeshProUGUI scoreText;
    public Animator animator;

    private void Start()
    {
        
        ResetLives();
        ResetScore();
    }

    void Update()
    {
        // Check if the mini-game is active
        if (MiniGameManager.Instance.IsMiniGameActive)
        {
            // Handle input to move the mini-game object
            float horizontalInput = Input.GetAxis("Horizontal");
            // float verticalInput = Input.GetAxis("Vertical");
            moveSpeed = 1.5f;
            Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed;
            transform.Translate(movement);
        }
    }

    public void RecudeLife()
    {
        numberOfLives--;
    }

    public void ResetLives()
    {
        numberOfLives = 5;
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = "Score: " + score + "";
    }

    public void ResetScore() {
        score = 0;
        scoreText.text = "Score: " + score + "";
    }



}
