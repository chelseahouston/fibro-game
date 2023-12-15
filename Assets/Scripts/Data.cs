using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    private static Data instance;

    private void Awake()
    {
        // Ensure there is only one instance of the Player object
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

    // store task data


    // store day and month data

    
    // store needs data


    // store achievement data


    // store music volume data


}
