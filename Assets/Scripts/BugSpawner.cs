using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawner : MonoBehaviour
{
    public GameObject objectPrefab;
    public int numberOfObjects = 5;
    public float spawnInterval = 0.5f;
    public float speed = 2.0f;
    public Vector2 targetPosition;

    void Start()
    {
        // Invoke method to spawn objects randomly
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    void SpawnObject()
    {
        if (numberOfObjects > 0)
        {
            // Calculate random spawn position
            Vector2 spawnPosition = new Vector2(Random.Range(-10f, 10f), 7f); // Adjust spawn area as needed

            // Instantiate object at spawn position
            GameObject obj = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
            numberOfObjects--;

            // Set target position for object to move towards
            obj.GetComponent<Bug>().targetPosition = targetPosition;
            obj.GetComponent<Bug>().speed = speed;
        }
    }
}
