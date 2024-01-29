using UnityEngine;

public class Bug : MonoBehaviour
{
    public float speed = 2.0f;
    public Vector2 targetPosition;

    void Start()
    {
        // initial position off-screen
        transform.position = new Vector3(-10f, 0f, 0f);
    }

    void Update()
    {
        // Move bug towards the target position
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Check if the object reaches the target position
        if (transform.position == (Vector3)targetPosition)
        {
            Destroy(gameObject);
        }
    }
}
