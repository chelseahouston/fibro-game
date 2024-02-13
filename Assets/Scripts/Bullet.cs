using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Vector2 startPosition;
    public BulletSpawner spawner;
    public Animator animator;
    public bool hit;

    void Start()
    {
        // initial position off-screen
        startPosition = transform.position;
        spawner = GameObject.Find("PlayerShooter").GetComponent<BulletSpawner>();
        speed = 100f;
    }

    void Update()
    {
        Vector3 targetPosition = new Vector3(transform.position.x, spawner.targetPosition.y, transform.position.z);
        // Move bug towards the target position
        if (!hit)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Bug(Clone)")
        {
            animator.SetBool("BugHit", true);
            hit = true;
            Debug.Log("Bug hit!");
        }
        else if (collision.name == "EndScreen")
        {
            Destroy(gameObject);
            Debug.Log("EndScreen hit");
        }
    }

    public void DestroyObject(AnimationEvent animationEvent)
    {
        Destroy(gameObject);
    }
}
