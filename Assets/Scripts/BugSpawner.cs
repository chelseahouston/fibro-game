using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawner : MonoBehaviour
{
    public GameObject objectPrefab, mainScreen;
    public int numberOfLives;
    public float spawnInterval = 0.5f;
    public float speed = 2.0f;
    public Vector2 targetPosition;
    public Vector3 pos1, pos2, pos3, pos4, pos5;
    public List<Vector3> spawningPoints = new List<Vector3>();

    void Start()
    {
        SetSpawnPoints();
        ResetLives();

        // Invoke method to spawn objects randomly
        InvokeRepeating("SpawnObject", 0f, spawnInterval);

    }

    public void SetSpawnPoints()
    {
        pos1 = new Vector3(-214.96f, 158.1f, 0f);
        pos2 = new Vector3(-100.46f, 158.1f, 0f);
        pos3 = new Vector3(0f, 158.1f, 0f);
        pos4 = new Vector3(100.46f, 158.1f, 0f);
        pos5 = new Vector3(214.96f, 158.1f, 0f);

        spawningPoints.Clear();
        spawningPoints.Add(pos1);
        spawningPoints.Add(pos2);
        spawningPoints.Add(pos3);  
        spawningPoints.Add(pos4);
        spawningPoints.Add(pos5);
    }

    void SpawnObject()
    {
        if (numberOfLives > 0 & mainScreen.activeSelf)
        {
            // Calculate random spawn position
            Vector3 spawnPosition = spawningPoints[Random.Range(0, spawningPoints.Count)];

            // Instantiate object at spawn position
            GameObject obj = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);

            // Set target position for object to move towards
            obj.GetComponent<Bug>().targetPosition = targetPosition;
            obj.GetComponent<Bug>().speed = speed;
        }
    }

    public void RecudeLife()
    {
        numberOfLives--;
    }

    public void ResetLives()
    {
        numberOfLives = 5;
    }
}
