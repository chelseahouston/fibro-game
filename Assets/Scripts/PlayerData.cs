using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    private static PlayerData instance;
    public TMP_InputField playerNameInput;
    public TextMeshProUGUI playerNameDisplay;
    public string playerName;

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
    private void Start()
    {
        playerNameInput.onEndEdit.AddListener(SetPlayerName);
    }

    private void SetPlayerName(string name)
    {
        // Save the player's name as a variable or use it as needed
        // For now, let's just display it on the screen
        playerNameDisplay.text = name;
        playerName = name;
    }
}
