using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bug : MonoBehaviour
{
    public float speed;
    public Vector2 startPosition;
    public BugSpawner spawner;
    public WorkShooterController workshooterController;

    void Start()
    {
        // initial position off-screen
        startPosition = transform.position;
        spawner = GetComponentInParent<BugSpawner>();
        workshooterController = GameObject.Find("PlayerShooter").GetComponent<WorkShooterController>();
        speed = 30f;
    }

    void Update()
    {
        Vector3 targetPosition = new Vector3(transform.position.x, spawner.targetPosition.y, transform.position.z);
        // Move bug towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "DestroyBugZone")
        {
            Destroy(gameObject);
            workshooterController.RecudeLife();
        }

        if (collision.name == "Bullet(Clone)")
        {
            Destroy(gameObject);
            workshooterController.IncreaseScore();
        }
    }
}
