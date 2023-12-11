using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneName;

    public void OnTriggerEnter2D(Collider2D thing)
    {
        sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "Home" & thing.tag == "HomeDoor") // if front door but inside house, go outside
        {
            SceneManager.LoadScene("Outside");
        }

        if (sceneName == "Outside" & thing.tag == "HomeDoor") // if front door but outside house, go intside
        {
            SceneManager.LoadScene("Home");
        }
    }
    


}
