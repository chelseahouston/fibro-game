using UnityEngine;

public class Bug : MonoBehaviour
{
    public float speed = 2.0f;
    public Vector2 targetPosition, startPosition;
    public GameObject destroyZone;

    void Start()
    {
        // initial position off-screen
        startPosition = transform.position;
        destroyZone = GameObject.FindGameObjectWithTag("DestroyBugZone");
        targetPosition = destroyZone.transform.position;
    }

    void Update()
    {
        // Move bug towards the target position
        Vector2 movement = (targetPosition - (Vector2)transform.position).normalized;
        transform.Translate(movement * speed * Time.deltaTime);

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "DestroyBugZone")
        {
            Destroy(gameObject);
        }
    }
}
