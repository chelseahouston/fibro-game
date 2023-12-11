using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TriggerPopup : MonoBehaviour
{
    // Dictionary to store tag-text mappings
    private Dictionary<string, string> actionlist = new Dictionary<string, string>();
    public TextMeshProUGUI popupText;
    public GameObject popup;

    // Initialize the dictionary in Start or Awake method
    void Start()
    {
        PopulateActionTagDictionary();
        popup.SetActive(false);
    }

    private void PopulateActionTagDictionary()
    {
        actionlist.Add("TV", "Watch TV");
        actionlist.Add("Bed", "Sleep");
        actionlist.Add("Fridge", "Get Snack");
        actionlist.Add("Stove", "Cook Food");
        actionlist.Add("Sofa", "Sit");
        actionlist.Add("Armchair", "Sit");
        actionlist.Add("Bath", "Take Bath");
        actionlist.Add("Toilet", "Use Toilet");
        actionlist.Add("Fire", "Light Fire");
        actionlist.Add("Desk", "Work/ Study");
    }


    public void OnTriggerEnter2D(Collider2D thing)
    {
        Debug.Log("Entered Object Tag: " + thing.tag);

        // Check if the object has a tag in the dictionary
        if (actionlist.ContainsKey(thing.tag))
        {
            popup.SetActive(true);
            // get the corresponding text from the dictionary
            popupText.text = actionlist[thing.tag];
            // display the popup text
            Debug.Log("Popup Text: " + popupText.text);
            
        }
    }

    public void OnTriggerExit2D()
    {
        popupText.text = "";
        popup.SetActive(false);
    }
}
