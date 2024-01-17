using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MailManager : MonoBehaviour
{
    public GameObject mailGrid; // mailbox with mail
    public GameObject mailPopup; // what the letter says popup
    public TextMeshProUGUI mailTitle, mailBody;
    public Dictionary<string, string> mails = new Dictionary<string, string>(); // title , body
    private bool readTrigger;
    private TimeManager timeManager;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        mailGrid.GetComponent<Renderer>().enabled = false;
        
        readTrigger = false;

        PopulateMailDictionary();
        mailPopup.SetActive(false);

        // start testing mail
        player = GameObject.Find("Player").GetComponent<Player>();
        timeManager = GameObject.Find("DayTimePanel").GetComponent<TimeManager>();
        if (player.mailDay & !player.mailRead)
        {
            YouveGotMail();
        }
        // end testing
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (readTrigger)
            {
                ReadMail();
            }
        }
    }

    public void YouveGotMail()
    {
        mailGrid.GetComponent<Renderer>().enabled = true;
        SetMail("Community Centre Grand Opening!");
    }

    public void CloseMail()
    {
        mailPopup.SetActive(false);
    }

    public void ReadMail()
    {
        mailPopup.SetActive(true);
        readTrigger = false;
        mailGrid.GetComponent<Renderer>().enabled = false;
        player.mailRead = true;
    }

    private void OnTriggerEnter2D(Collider2D thing)
    {
            if (thing.CompareTag("Player"))
            {
                if (mailGrid.GetComponent<Renderer>().enabled)
                {
                    readTrigger = true;
                } 
            }
    }

    private void OnTriggerExit2D(Collider2D thing)
{
    if (thing.CompareTag("Player"))
    {
        if (mailGrid.GetComponent<Renderer>().enabled)
        {
            readTrigger = false;
        }
    }
}

    private void PopulateMailDictionary()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        mails.Clear();
        mails.Add("Community Centre Grand Opening!", "Hey " + player.playerName + ", \nThe Community Centre is now open!\nHope to see you there soon!\n\n - Sammie");
        //mails.Add("", "");
        //mails.Add("", "");
        //mails.Add("", "");
        //mails.Add("", "");
    }

    public void SetMail(string title)
    {
        if (mails.ContainsKey(title))
        {
            mailTitle.text = title;
            mails.TryGetValue(title, out string text);
            mailBody.text = text;
        }
        
    }



}
