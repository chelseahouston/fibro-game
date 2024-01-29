using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawner : MonoBehaviour
{
    public GameObject objectPrefab, mainScreen;
    public Transform parentTransform;
    public int numberOfLives;
    public float spawnInterval = 3f;
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
        pos1 = new Vector3(2.5f, 121f, 0f);
        pos2 = new Vector3(-100.46f, 121f, 0f);
        pos3 = new Vector3(0f, 121f, 0f);
        pos4 = new Vector3(100.46f, 121f, 0f);
        pos5 = new Vector3(-2.5f, 121f, 0f);

        spawningPoints.Clear();
        spawningPoints.Add(pos1);
        Debug.Log("Pos1 = " + pos1);
        spawningPoints.Add(pos2);
        Debug.Log("Pos2 = " + pos2);
        spawningPoints.Add(pos3);
        Debug.Log("Pos3 = " + pos3);
        spawningPoints.Add(pos4);
        Debug.Log("Pos4 = " + pos4);
        spawningPoints.Add(pos5);
        Debug.Log("Pos5 = " + pos5);
    }

    void SpawnObject()
    {
        if (numberOfLives > 0 & mainScreen.activeSelf)
        {
            // Calculate random spawn position
            Vector3 spawnPosition = spawningPoints[Random.Range(0, spawningPoints.Count)];

            // Instantiate object at spawn position
            GameObject obj = Instantiate(objectPrefab, spawnPosition, Quaternion.identity, parentTransform);
            Debug.Log("Spawned at " + obj.transform.position);
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
