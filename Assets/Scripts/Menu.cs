using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public TextMeshProUGUI Start;


    public void LoadGame()
    {
        SceneManager.LoadScene("Home");
    }

    public void Exit()
    {
        Application.Quit();
    }

       
}
