using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class PlayerData : MonoBehaviour
{
    private static PlayerData instance;
    public TMP_InputField playerNameInput;
    public TextMeshProUGUI playerNameDisplay;

    // customisation
    public string playerName;

    public Color selectedEyeColor, selectedSkinColor, selectedHairColor, selectedTrousersColor, selectedTshirtColor, selectedShoesColor; // preview chosen colors
    public Color skinColor, eyeColor, hairColor, tshirtColor, trousersColor, shoesColor;

    public Image characterBaseModel, hair, tshirt, trousers, eyes, shoes;

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

        //default colours
        selectedEyeColor = new Color(0.23f, 0.79f, 0.85f, 1);
        selectedSkinColor = new Color(1, 0.89f, 0.78f, 1); 
        selectedHairColor = new Color(0.36f, 0.2f, 0.04f, 1);
        selectedTrousersColor = new Color(0.14f, 0.14f, 0.14f, 1);
        selectedTshirtColor = new Color(0.32f, 0.24f, 0.84f, 1);
        selectedShoesColor = new Color(0.4f, 0.25f, 0.17f, 1);
        UpdateCharacterPreview();

    }

    public void SetPlayerName(string name)
    {
        // Save the player's name as a variable or use it as needed
        // For now, let's just display it on the screen
        playerNameDisplay.text = name;
        playerName = name;
    }

    public void OnColorClick(GameObject color)
    {
        string colortag = color.tag;
        Debug.Log("color clicked for " + color.name);
        switch (colortag)
        {
            case "EyeColor":
                selectedEyeColor = color.GetComponent<Image>().color;
                Debug.Log("New Color selected");
                UpdateCharacterPreview();
                break;

            case "SkinColor":
                selectedSkinColor = color.GetComponent<Image>().color;
                Debug.Log("New Color selected");
                UpdateCharacterPreview();
                break;

            case "HairColor":
                selectedHairColor = color.GetComponent<Image>().color;
                Debug.Log("New Color selected");
                UpdateCharacterPreview();
                break;

            case "TrousersColor":
                selectedTrousersColor = color.GetComponent<Image>().color;
                Debug.Log("New Color selected");
                UpdateCharacterPreview();
                break;

            case "TShirtColor":
                selectedTshirtColor = color.GetComponent<Image>().color;
                Debug.Log("New Color selected");
                UpdateCharacterPreview();
                break;

            case "ShoeColor":
                selectedShoesColor = color.GetComponent<Image>().color;
                Debug.Log("New Color selected");
                UpdateCharacterPreview();
                break;
        }
    }

    public void UpdateCharacterPreview()
    {
        Debug.Log("Updating Preview");
        characterBaseModel.GetComponent<Image>().color = selectedSkinColor;
        hair.GetComponent<Image>().color = selectedHairColor;
        tshirt.GetComponent<Image>().color = selectedTshirtColor;
        trousers.GetComponent<Image>().color = selectedTrousersColor;
        eyes.GetComponent<Image>().color = selectedEyeColor;
        shoes.GetComponent<Image>().color = selectedShoesColor;
    }

}
