using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// author: chelsea houston
// date last modified: 15/11/23

public class RoomViews : MonoBehaviour
{
    [SerializeField] public GameObject[] views;
    public int currentViewIndex;
    public CameraMovement camMovement;
    public GameObject leftArrow, rightArrow;
    public string currentScene, previousScene;

    private void Awake()
    {
        DisableArrows();
        foreach (GameObject view in views)
        {
            view.SetActive(false);
        } // set all to inactive
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadRoom();
        camMovement.CameraIn();
        Debug.Log("Current Scene View = " + currentViewIndex);
    }

    public void LoadRoom()
    {

        currentScene = SceneManager.GetActiveScene().name;

        // when entering hallway, where did we come from? decides the view of the room
        if (currentScene == "Hallway")
        {
            switch (previousScene)
            {
                case "Bedroom": // when coming from the bedroom to the hallway always load on room angle 1
                    currentViewIndex = 0; // room angle 1 (index 0, bedroom to hallway entry view)
                    break;

                case "Bathroom": // when coming from the bathroom to the hallway always load on room angle 1
                    currentViewIndex = 0; // room angle 1 (index 0, bathroom to hallway entry view)
                    break;

                case "Kitchen": // when coming from the kitchen to the hallway always load on room angle 1
                    currentViewIndex = 2; // room angle 3 (index 2, kitchen to hallway entry view)
                    break;

                case "Lounge": // when coming from the lounge to the hallway always load on room angle 1
                    currentViewIndex = 2; // room angle 3 (index 2, kitchen to hallway entry view)
                    break;
                case "": // first load no previous scene
                    currentViewIndex = 3; // from front door
                    break;
            }
        }

        if (currentScene == "Bedroom") // when coming from hallway load on room angle 2 (index 1, door enrtry view)
        {
            currentViewIndex = 1; 
        }

        if (currentScene == "Kitchen") // when coming from hallway load on room angle 1 (index 0, door enrtry view)
        {
            currentViewIndex = 0;
        }

        if (currentScene == "Bathroom") // when coming from hallway load on room angle 2 (index 1, door enrtry view)
        {
            currentViewIndex = 1;
        }

        if (currentScene == "Lounge") // when coming from hallway load on room angle 2 (index 1, door enrtry view)
        {
            currentViewIndex = 1;
        }

        views[currentViewIndex].SetActive(true); // show first angle as set above
    }

    public void SetPreviousScene() // called from door OnClick methods before the scene change
    {
        previousScene = currentScene;
    }

    // rotate room to the right
    public void RotateRight()
    {
        views[currentViewIndex].SetActive(false);
        if (currentViewIndex == (views.Length-1)) { // if was already shoowing last view in list, go to the first (0)

            currentViewIndex = 0;
        }
        else
        {
            currentViewIndex++; // move to next view
            
        }
        views[currentViewIndex].SetActive(true);
        Debug.Log("Current Scene View = " + currentViewIndex);
    }

    // rotate room to the left
    public void RotateLeft()
    {
        views[currentViewIndex].SetActive(false);
        currentViewIndex--; // move to previous view
        if (currentViewIndex < 0) // if was already showing the first view, go to the last (length of list)
        {
            currentViewIndex = ((views.Length - 1));
        }
        views[currentViewIndex].SetActive(true);
        Debug.Log("Current Scene View = " + currentViewIndex);
    }

    public void EnableArrows()
    {
        leftArrow.SetActive(true);
        rightArrow.SetActive(true);
    }

    public void DisableArrows()
    {
        leftArrow.SetActive(false);
        rightArrow.SetActive(false);
    }

    public void ExitRoom()
    {
        SetPreviousScene();
        DisableArrows();
        camMovement.CameraOut();
    }

    public void LoadBedroom()
    {
        StartCoroutine(LoadScene("Bedroom"));
    }

    public void LoadHallway()
    {
        StartCoroutine(LoadScene("Hallway"));
    }

    public void LoadKitchen()
    {
        StartCoroutine(LoadScene("Kitchen"));
    }

    public void LoadBathroom()
    {
        StartCoroutine(LoadScene("Bathroom"));
    }

    public void LoadLounge()
    {
        StartCoroutine(LoadScene("Lounge"));
    }

    IEnumerator LoadScene(string sceneName)
    {
        yield return new WaitForSeconds(0.5f); // time for the last scene to move out
        SceneManager.LoadScene(sceneName);
    }

}
