using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeDetector : MonoBehaviour
{
    private Scene previousScene;
    public bool sceneChanged;
    private static SceneChangeDetector instance;

    private void Awake()
    {
        // Ensure there is only one instance of the SCD object
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {

        previousScene = SceneManager.GetActiveScene();
        sceneChanged = true;
    }


    public void SetSceneChangeFalse()
    {
        sceneChanged = false;
        
    }
}
