using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Computer : MonoBehaviour
{
    public bool on, logIn;
    public Animator computerAnimator;
    public GameObject computerPopup, startButton;
    public GameObject loginButton, startMenu;
    public Sprite currentSprite, desktopSprite;
    public Texture2D cursorTexture;
    public GameObject bin, binOutline, work, workOutline, usernameOb, workScreen;
    public TextMeshProUGUI username;

    // Start is called before the first frame update
    void Start()
    {
        on = false;
        logIn = false;
        loginButton.SetActive(false);
        computerPopup.SetActive(false);
        startButton.SetActive(false);
        currentSprite = GetComponent<Image>().sprite;
        startMenu.SetActive(false);
        bin.SetActive(false);
        work.SetActive(false);
        usernameOb.SetActive(false);
    }


        // start computer on E key down
    public void StartComputer()
    {
        GameObject.Find("Player").GetComponent<StopStartPlayerMovement>().AlterPlayerMovement(false);
        computerPopup.SetActive(true);
        loginButton.SetActive(false);
        startButton.SetActive(false);
        workScreen.SetActive(false);
    }

    // login screen computer idle animation with login button enabled
    public void TurnedOnComputer(AnimationEvent animationEvent)
    {
        computerAnimator.SetBool("on", true);
        username.enabled=true;
        username.text = GameObject.Find("Player").GetComponent<Player>().playerName;
        Debug.Log("Player name = " + username.text);
        loginButton.SetActive(true);
        usernameOb.SetActive(true);
    }

    // click login button to start login animation
    public void loginButtonClick()
    {
        loginButton.SetActive(false);
        computerAnimator.SetBool("logIn", true);
        username.enabled = false;
    }

    // when log in animation ends
    public void loggedInComputer(AnimationEvent animationEvent)
    {
        computerAnimator.SetBool("logIn", false);
        currentSprite = desktopSprite;
        startButton.SetActive(true);
        bin.SetActive(true);
        binOutline.SetActive(false);
        work.SetActive(true);
        workOutline.SetActive(false);
    }

    public void OnStartBarClick()
    {
        Debug.Log("start button clicked");
        if (!startMenu.activeSelf)
        {
            startMenu.SetActive(true);
            Debug.Log("showing start menu");
        }
        else
        {
            startMenu.SetActive(false);
            Debug.Log("hiding start menu");
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

    public void OnBinClick()
    {
        if (!binOutline.activeSelf)
        {
            binOutline.SetActive(true);
            if (workOutline.activeSelf)
            {
                workOutline.SetActive(false);
            }
        }
        else
        {
            binOutline.SetActive(false);
        }
    }

    public void OnWorkClick()
    {
        if (!workOutline.activeSelf)
        {
            StartCoroutine(OpenWorkApp());
        }
        else
        {
            workOutline.SetActive(false);
        }
    }

    IEnumerator OpenWorkApp()
    {
        workOutline.SetActive(true);
        if (binOutline.activeSelf)
        {
            binOutline.SetActive(false);
        }
        yield return new WaitForSeconds(0.5f);
        workScreen.SetActive(true);
        
    }

    public void ExitComputer()
    {
        //play shutting down animation
        GameObject.Find("Player").GetComponent<StopStartPlayerMovement>().AlterPlayerMovement(true);
        computerPopup.SetActive(false);
    }






}
