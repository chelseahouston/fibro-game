using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Computer : MonoBehaviour
{
    public bool on, logIn;
    public Animator animator;
    public GameObject computerPopup, startButton;
    public GameObject loginButton;
    public Sprite currentSprite, desktopSprite, startButtonSprite;
    public Texture2D cursorTexture;

    // Start is called before the first frame update
    void Start()
    {
        on = false;
        logIn = false;
        loginButton.SetActive(false);
        computerPopup.SetActive(false);
        startButton.SetActive(false);
        SetSprites();
    }

    private void SetSprites()
    {
        currentSprite = GetComponent<Image>().sprite;
    }

    // start computer on E key down
    public void StartComputer()
    {
        computerPopup.SetActive(true);
        loginButton.SetActive(false);
        startButton.SetActive(false);
    }

    // login screen computer idle animation with login button enabled
    public void TurnedOnComputer(AnimationEvent animationEvent)
    {
        animator.SetBool("on", true);
        loginButton.SetActive(true);
    }

    // click login button to start login animation
    public void loginButtonClick()
    {
        loginButton.SetActive(false);
        animator.SetBool("logIn", true);
    }

    // when log in animation ends
    public void loggedInComputer(AnimationEvent animationEvent)
    {
        animator.SetBool("logIn", false);
        currentSprite = desktopSprite;
        startButton.SetActive(true);
        currentSprite = desktopSprite;
    }

    public void OnStartBarClick()
    {
        Debug.Log("start button clicked");
        if (currentSprite != startButtonSprite)
        {
            currentSprite = startButtonSprite;
            Debug.Log("showing start menu");
        }
        else if (currentSprite == startButtonSprite)
        {
            currentSprite = desktopSprite;
            Debug.Log("closing start menu");
        }
    }

    public void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    public void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }




}
