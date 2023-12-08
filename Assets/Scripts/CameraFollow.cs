using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Camera mainCamera; // Drag your camera into this field in the Unity Editor
    public float smoothSpeed = 0.125f;
    public Vector3 offset = new Vector3(0f, 0f, -40f);
    public float edgeThreshold = 0.1f;

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("Camera target is not assigned.");
            return;
        }

        if (mainCamera == null)
        {
            Debug.LogWarning("Main Camera is not assigned.");
            return;
        }

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;

        CheckEdgeMovement();
    }

    void CheckEdgeMovement()
    {
        if (target == null || mainCamera == null)
        {
            return;
        }

        Vector3 viewportPos = mainCamera.WorldToViewportPoint(target.position);

        bool shouldMove = viewportPos.x < edgeThreshold || viewportPos.x > 1 - edgeThreshold ||
                          viewportPos.y < edgeThreshold || viewportPos.y > 1 - edgeThreshold;

        if (shouldMove)
        {
            Vector3 desiredPosition = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        }
    }
}
