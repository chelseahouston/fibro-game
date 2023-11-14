using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// author: chelsea houston
// date last midified: 14/11/23

public class RoomViews : MonoBehaviour
{

    [SerializeField] public GameObject[] views;
    public int currentViewIndex;
    public CameraMovement camMovement;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject view in views) {
            view.SetActive(false);
        } // set all to inactive
        currentViewIndex = 1; // always load on room angle 2 (index 1, door enrtry view)
        views[currentViewIndex].SetActive(true); // show first angle

        camMovement.BottomRightIn();
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




}
