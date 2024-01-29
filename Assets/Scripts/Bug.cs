using UnityEngine;

public class Bug : MonoBehaviour
{
    public float speed = 2.0f;
    public Vector2 targetPosition;
    public GameObject destroyZone;

    void Start()
    {
        // initial position off-screen
        destroyZone = GameObject.FindGameObjectWithTag("DestroyBugZone");
        transform.position = new Vector3(0f, 0f, 0f);
        targetPosition = destroyZone.transform.position;
    }

    void Update()
    {
        // Move bug towards the target position
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "DestroyBugZone")
        {
            Destroy(gameObject);
        }
    }
}
