using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Computer : MonoBehaviour
{
    public bool on, logIn;
    public Animator animator;
    public GameObject computerPopup, startButton;
    public TextMeshProUGUI logintext;
    public Sprite currentSprite, desktopSprite, startButtonSprite;

    // Start is called before the first frame update
    void Start()
    {
        on = false;
        logIn = false;
        logintext.enabled = false;
        computerPopup.SetActive(false);
        startButton.SetActive(false);
        SetSprites();
    }

    private void SetSprites()
    {
        currentSprite = GetComponent<Sprite>();
        desktopSprite = Resources.Load<Sprite>("Sprites/minigames/work11");
        startButtonSprite = Resources.Load<Sprite>("Sprites/minigames/work12");
    }

    // start computer on E key down
    public void StartComputer()
    {
        computerPopup.SetActive(true);
        logintext.enabled = false;
        startButton.SetActive(false);
    }

    // login screen computer idle animation with login button enabled
    public void TurnedOnComputer(AnimationEvent animationEvent)
    {
        animator.SetBool("on", true);
        logintext.enabled = true;
    }

    // click login button to start login animation
    public void loginButtonClick()
    {
        logintext.enabled = false;
        animator.SetBool("logIn", true);
    }

    // when log in animation ends
    public void loggedInComputer(AnimationEvent animationEvent)
    {
        animator.SetBool("logIn", false);
        currentSprite = desktopSprite;
        startButton.SetActive(true);
    }

    public void OnStartBarClick()
    {
        if (currentSprite != startButtonSprite)
        {
            currentSprite = startButtonSprite;
        }
        if (currentSprite == startButtonSprite)
        {
            currentSprite = desktopSprite;
        }
    }




}
