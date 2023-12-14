using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerPopup : MonoBehaviour
{
    public GameObject popup;

    // Initialize the dictionary in Start or Awake method
    void Start()
    {
        popup.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D thing)
    {
        popup.SetActive(true);
    }

    public void OnTriggerExit2D()
    {
        popup.SetActive(false);
    }
}
