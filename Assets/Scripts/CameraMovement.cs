using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;

// author: chelsea houston
// date last modified: 08/12/23

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera cam;
    public Transform startMarker;
    public Transform endMarker;
    public float speed;
    private float t; // Time variable
    private bool isMovingIn, isMovingOut = false;
    public float journeyLength;
    public UItext UItext;

    void Awake()
    {
        Application.targetFrameRate = 60;
    }
    void Start()
    {
        speed = 2.0f;
        Time.timeScale = 1.0f;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
        Debug.Log("Journey Length: " + journeyLength);
        Debug.Log("Speed: " + speed);
    }

    void Update()
    {
        if (isMovingIn)
        {
            StartCoroutine(MoveCameraIn());
        }
        if (isMovingOut)
        {
            StartCoroutine(MoveCameraOut());
        }
    }

    public void CameraIn()
    {
        Debug.Log("Starting camera movement");
        t = 0f; // Reset time variable
        isMovingIn = true;
    }

    public void CameraOut()
    {
        Debug.Log("Starting camera movement");
        t = 0f; // Reset time variable
        isMovingOut = true;
        UItext.DisableIcons();
    }

    IEnumerator MoveCameraIn()
    {
        t += Time.deltaTime * speed;
        cam.transform.position = Vector3.Lerp(startMarker.position, endMarker.position, t);

        // Check if the movement is complete
        if (t >= 1.0f)
        {
            isMovingIn = false;
            Debug.Log("Completed camera movement");
            yield return new WaitForSeconds(0.5f);
            UItext.SetIconsActive();
        }
    }
    IEnumerator MoveCameraOut()
    {
        t += Time.deltaTime * speed;
        cam.transform.position = Vector3.Lerp(endMarker.position, startMarker.position, t);

        // Check if the movement is complete
        if (t >= 1.0f)
        {
            yield return new WaitForSeconds(0.5f);
            isMovingIn = false;
            Debug.Log("Completed camera movement");
            
        }
    }
}



