using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerPopup : MonoBehaviour
{
    // Dictionary to store tag-text mappings
    private Dictionary<string, string> actionlist = new Dictionary<string, string>();
    public TextMeshProUGUI popupText;
    public GameObject popup;
    public string sceneName;

    // Initialize the dictionary in Start or Awake method
    void Start()
    {
        PopulateActionTagDictionary(SceneManager.GetActiveScene().name);
        popup.SetActive(false);
    }

    private void PopulateActionTagDictionary(string scene)
    {
        actionlist.Clear();
        switch (sceneName)
        {
            case "Home":
                PopulateHomeActionTagDictionary();
                break;
            case "Outside":
                PopulateOutsideActionTagDictionary();
                break;
            case "Shop":
                PopulateShopActionTagDictionary();
                break;
            case "CommunityClub":
                PopulateCommClubActionTagDictionary();
                break;
            case "MedicalCentre":
                PopulateMedActionTagDictionary();
                break;
        }
    }

    private void PopulateHomeActionTagDictionary()
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
        actionlist.Add("Cane", "Take Cane");
        actionlist.Add("WheelChair", "Use Wheelchair");
    }

    private void PopulateShopActionTagDictionary()
    {
        actionlist.Add("Milk", "Get Milk");
        actionlist.Add("Bread", "Get Bread");
        actionlist.Add("Pasta", "Get Pasta");
        actionlist.Add("Veg", "Get Veg");
        actionlist.Add("Bench", "Sit");
        actionlist.Add("Cashier", "Pay for Groceries");
    }

    private void PopulateCommClubActionTagDictionary()
    {
        actionlist.Add("Chair", "Sit");
    }

    private void PopulateMedActionTagDictionary()
    {
        actionlist.Add("Chair", "Sit");
        actionlist.Add("WaitingChair", "Wait");
        actionlist.Add("Pharmacy", "Buy Medication");
        actionlist.Add("Reception", "Check in");
    }

    private void PopulateOutsideActionTagDictionary()
    {
        actionlist.Add("Flowers", "Smell Flowers");
    }

    public void OnTriggerEnter2D(Collider2D thing)
    {
        // Check if the object has a tag in the dictionary
        if (actionlist.ContainsKey(thing.tag))
        {
            popup.SetActive(true);
            // get the corresponding text from the dictionary
            popupText.text = actionlist[thing.tag];
            // display the popup text
            
        }
    }

    public void OnTriggerExit2D()
    {
        popupText.text = "";
        popup.SetActive(false);
    }
}
