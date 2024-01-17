using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MailManager : MonoBehaviour
{
    public GameObject mailGrid; // mailbox with mail
    public GameObject mailPopup; // what the letter says popup
    private bool readTrigger;
    private TimeManager timeManager;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        mailGrid.GetComponent<Renderer>().enabled = false;
        mailPopup.SetActive(false);
        readTrigger = false;

        // start testing mail
        player = GameObject.Find("Player").GetComponent<Player>();
        timeManager = GameObject.Find("DayTimePanel").GetComponent<TimeManager>();
        if (timeManager.GetCurentDate() == 2 & !player.mailRead)
        {
            YouveGotMail();
        }
        // end testing mail
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
        player.mailRead = false;
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

}
