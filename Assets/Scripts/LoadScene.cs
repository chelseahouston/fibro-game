using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneName;
    public GameObject player;
    public Transform homePosition, shopPosition, commPosition, medPosition; // player's inside positions
    public Transform outsideHomePos, outsideShopPos, outsideCommPosition, outsideMedPos; // player's outside positions

    private void Start()
    {
        homePosition = ;
        shopPosition = ;
        commPosition = ;
        medPosition = ;
        outsideHomePos = ;
        outsideShopPos = ;
        outsideCommPosition = ;
        outsideMedPos = ;
    }
    public void OnTriggerEnter2D(Collider2D thing)
    {
        sceneName = SceneManager.GetActiveScene().name;
        Debug.Log("Scene = "+ sceneName);

        if (sceneName == "Home" & thing.tag == "HomeDoor") // if front door but inside house, go outside
        {
            // set player position to outsideHomePos
            SceneManager.LoadScene("Outside");
        }

        if (sceneName == "Outside" & thing.tag == "HomeDoor") // if front door but outside house, go inside
        {
            // set player position to homePosition
            SceneManager.LoadScene("Home");
        }

        if (sceneName == "Shop" & thing.tag == "ShopDoor") // if front door but inside shop, go outside
        {
            // set player position to outsideShopPos
            SceneManager.LoadScene("Outside");
        }

        if (sceneName == "Outside" & thing.tag == "ShopDoor") // if front door but outside shop, go inside
        {
            // set player position to shopPosition
            SceneManager.LoadScene("Shop");
        }

        if (sceneName == "CommunityClub" & thing.tag == "CommDoor") // if front door but inside comm club, go outside
        {
            // set player position to outsideCommPos
            SceneManager.LoadScene("Outside");
        }

        if (sceneName == "Outside" & thing.tag == "ShopDoor") // if front door but outside comm club, go inside
        {
            // set player position to commPosition
            SceneManager.LoadScene("CommunityClub");
        }

        if (sceneName == "MedicalCentre" & thing.tag == "MedDoor") // if front door but inside med centre, go outside
        {
            // set player position to outsideShopPos
            SceneManager.LoadScene("Outside");
        }

        if (sceneName == "Outside" & thing.tag == "MedDoor") // if front door but outside med centre, go inside
        {
            // set player position to shopPosition
            SceneManager.LoadScene("MedicalCentre");
        }
    }
    


}
