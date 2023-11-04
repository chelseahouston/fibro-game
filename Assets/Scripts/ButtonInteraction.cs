using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Import the UnityEngine.UI namespace

// author: chelsea houston
// date last midified: 04/11/23

public class ButtonInteraction : MonoBehaviour
{
    private Color originalColor; // store the original color
    private Color clickedColor; // store the clicked color
    private Image image; // reference to the object's Image component

    private void Start()
    {
        image = GetComponent<Image>(); // arrow's image component
        originalColor = image.color; // store the original color
        clickedColor = new Color(0.68f, 0.68f, 0.68f, 1.0f); // store the clicked color
    }

    public void OnMouseDown()
    {
        ChangeObjectColor(clickedColor); // change arrow color when clicked
    }

    public void OnMouseUp()
    {
        ChangeObjectColor(originalColor); // revert to original color when released
    }

    private void ChangeObjectColor(Color newColor)
    {
        image.color = newColor; // change the object's color
    }
}
