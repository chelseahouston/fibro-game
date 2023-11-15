using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// author: chelsea houston
// date last modified: 14/11/23

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
    }

    public void LoadRoom()
    {

        currentScene = SceneManager.GetActiveScene().name;

        switch (currentScene, previousScene)
        {
            case ("Bedroom", "Hallway"): // when coming from the hallway always load on room angle 2
                currentViewIndex = 1; // room angle 2 (index 1, door enrtry view)
                break;

            case ("Hallway", "Bedroom"): // when coming from the bedroom to the hallways always load on room angle 2
                currentViewIndex = 1; // room angle 2 (index 1, bedroom to hallway entry view)
                break;

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
            Debug.Log("Current Scene View = " + currentViewIndex);
        }
        views[currentViewIndex].SetActive(true);
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

    IEnumerator LoadScene(string sceneName)
    {
        yield return new WaitForSeconds(0.5f); // time for the last scene to move out
        SceneManager.LoadScene(sceneName);
    }



}
