using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{ 
    public PlayerData playerData;


    public void LoadGame()
    {
        if (playerData.playerName != "")
        {
            SceneManager.LoadScene("Home");
        }

        
    }

    public void LoadDisclaimer()
    {
        SceneManager.LoadScene("Disclaimer");
    }

    public void LoadPlayerCustomiser()
    {
        Debug.Log("Called");
        SceneManager.LoadScene("CharacterCustomise");
    }

    public void LoadIntroduction()
    {
        SceneManager.LoadScene("Introduction");
    }

    public void Exit()
    {
        Application.Quit();
    }

       
}
