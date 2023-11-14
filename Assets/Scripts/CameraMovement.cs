using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;

// author: chelsea houston
// date last midified: 14/11/23

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float targetOrthoSize = 5.0f; // Adjust this value according to your scene

    public void BottomRightIn()
    {
        StartCoroutine(MoveCameraInBottomRight());
    }

    IEnumerator MoveCameraInBottomRight()
    {
        Debug.Log("Starting camera movement");

        // Get the initial orthographic size of the camera
        float startOrthoSize = Camera.main.orthographicSize;

        float elapsedTime = 0f;

        while (elapsedTime < 1f)
        {
            // Lerp between the start and target orthographic sizes
            Camera.main.orthographicSize = Mathf.Lerp(startOrthoSize, targetOrthoSize, elapsedTime);

            // Increment the elapsed time based on the moveSpeed
            elapsedTime += Time.deltaTime * moveSpeed;

            yield return null;
        }

        // Ensure the camera reaches the exact target orthographic size
        Camera.main.orthographicSize = targetOrthoSize;

        Debug.Log("Completed camera movement");
    }
}

