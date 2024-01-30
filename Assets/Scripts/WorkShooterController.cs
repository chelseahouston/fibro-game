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



}
