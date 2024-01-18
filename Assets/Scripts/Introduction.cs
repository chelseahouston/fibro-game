using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Introduction : MonoBehaviour
{

    public TextMeshProUGUI DrText, PlayerText, SpaceToProgressText;
    public PlayerData PlayerData;
    public List<string> drscript = new List<string>();
    public List<string> playerscript = new List<string>();
    public bool DrSpeaking;

    // Start is called before the first frame update
    void Start()
    {
        DrText.text = "";
        PlayerText.text = "";
        setScript();
        DrText.text = drscript[0];
        DrSpeaking = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space)) { 
            if (DrSpeaking)
            {
                DrText.text = "";
                drscript.RemoveAt(0);
                PlayerText.text = playerscript[0];
                DrSpeaking = false;
            }
            if (!DrSpeaking & drscript.Count > 0)
            {
                PlayerText.text = "";
                playerscript.RemoveAt(0);
                DrText.text = playerscript[0];
                drscript.RemoveAt(0);
            }
            if (SpaceToProgressText.text == "[space] to continue")
            {
                SceneManager.LoadScene("Home");
            }
        }
        if (!DrSpeaking & drscript.Count == 0)
        {
            SpaceToProgressText.text = "[space] to continue";
        }
        

    }

    public void setScript()
    {
        string player1 = "I have what? That's what is causing all of my symptoms?";
        string doc1 = "Yes, we believe so.";
        string player2 = "So what do we do next so I can get better?";
        string doc2 = "Unfortuntely, this is a lifelong condition that you need to learn to live with.";
        string player3 = "... learn... to.. live with?";

        drscript.Clear();
        drscript.AddRange(new string[] { doc1, doc2 });
        playerscript.Clear();
        playerscript.AddRange(new string[] { player1, player2, player3 });
    }
}
