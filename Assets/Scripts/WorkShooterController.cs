using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorkShooterController : MonoBehaviour
{

    public float moveSpeed;
    public int numberOfLives, score;
    public TextMeshProUGUI scoreText;
    public Animator animator;
    public List<GameObject> hearts = new List<GameObject>();
    private Rigidbody2D rb;

    private void Start()
    {
        ResetLives();
        ResetScore();
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 300f;
    }

    void Update()
    {
        // Check if the mini-game is active
        if (MiniGameManager.Instance.IsMiniGameActive)
        {
            // Handle input to move the mini-game object
            float horizontalInput = Input.GetAxis("Horizontal");
            // float verticalInput = Input.GetAxis("Vertical");

            // Calculate movement direction
            Vector3 movement = new Vector3(horizontalInput, 0f, 0f);

            // Set the velocity based on the movement direction and speed
            rb.velocity = movement * moveSpeed;
        }
        else
        {
            // If the mini-game is not active, stop the object
            rb.velocity = Vector3.zero;
        }
    }

    public void RecudeLife()
    {
        numberOfLives--;
        hearts[numberOfLives].GetComponent<Image>().enabled = false;
    }

    public void ResetLives()
    {
        numberOfLives = 5;
        foreach (GameObject heart in hearts) {
            if (!GetComponent<Image>().enabled)
            {
                GetComponent<Image>().enabled = true;
            }
        }
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

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided with " + collision.gameObject.name);
    }



}
