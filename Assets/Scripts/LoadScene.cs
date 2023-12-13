using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneName;
    public GameObject player;
    public Vector3 homePosition, shopPosition, commPosition, medPosition; // player's inside positions
    public Vector3 outsideHomePos, outsideShopPos, outsideCommPosition, outsideMedPos; // player's outside positions

    private void Start()
    {
        SetStartingPositions();
    }

    private void SetStartingPositions()
    {
        // set starting positions
        homePosition = new Vector3(-28.46f, -26.86f, 0f);
        shopPosition = new Vector3(-23.54f, -26.81f, 0f);
        commPosition = new Vector3(-23.54f, -17.34f, 0f);
        medPosition = new Vector3(-31.5f, -25.87f, 0f);
        outsideHomePos = new Vector3(-28.46f, -26.76f, 0f);
        outsideShopPos = new Vector3(-15.46f, -34.64f, 0f);
        outsideCommPosition = new Vector3(14.58f, -19.52f, 0f);
        outsideMedPos = new Vector3(-8.5f, -13.56f, 0f);
    }

    public void OnTriggerEnter2D(Collider2D thing)
    {

        // Check if the collider is a trigger
        if (!thing.isTrigger)
        {
            // Exit the method if the collider is not a trigger
            return;
        }

        sceneName = SceneManager.GetActiveScene().name;

        switch (sceneName)
        {
            case "Home":
                LeaveHomeScene(thing);
                break;
            case "Outside":
                LeaveOutsideScene(thing);
                break;
            case "Shop":
                LeaveShopScene(thing);
                break;
            case "CommunityClub":
                LeaveCommunityClubScene(thing);
                break;
            case "MedCentre":
                LeaveMedicalCentreScene(thing);
                break;
        }

    }

    private void LeaveHomeScene(Collider2D thing)
    {
        if (thing.tag == "HomeDoor")
        {
            StartCoroutine(LoadSceneAndSetPosition("Outside", outsideHomePos, thing));
        }
    }

    private void LeaveShopScene(Collider2D thing)
    {
        if (thing.tag == "ShopDoor")
        {
            StartCoroutine(LoadSceneAndSetPosition("Outside", outsideShopPos, thing));
        }
    }

    private void LeaveCommunityClubScene(Collider2D thing)
    {
        if (thing.tag == "CommDoor")
        {
            StartCoroutine(LoadSceneAndSetPosition("Outside", outsideCommPosition, thing));
        }
    }

    private void LeaveMedicalCentreScene(Collider2D thing)
    {
        if (thing.tag == "MedicalDoor")
        {
            StartCoroutine(LoadSceneAndSetPosition("Outside", outsideMedPos, thing));
        }
    }

    private void LeaveOutsideScene(Collider2D thing)
    {
        switch (thing.tag)
        {
            case "HomeDoor":
                StartCoroutine(LoadSceneAndSetPosition("Home", homePosition, thing));
                break;
            case "ShopDoor":
                StartCoroutine(LoadSceneAndSetPosition("Shop", shopPosition, thing));
                break;
            case "CommDoor":
                StartCoroutine(LoadSceneAndSetPosition("CommunityClub", commPosition, thing));
                break;
            case "MedicalDoor":
                StartCoroutine(LoadSceneAndSetPosition("MedCentre", medPosition, thing));
                break;
        }
    }

    IEnumerator LoadSceneAndSetPosition(string scene, Vector3 position, Collider2D thing)
    {
        Debug.Log("Called ");
        SceneManager.LoadScene(scene);
        Debug.Log("Loading " + scene);
        yield return new WaitForSeconds(1f); // Wait for the next frame
        Debug.Log("Loaded " + scene);
        player.transform.position = position;

    }
}
