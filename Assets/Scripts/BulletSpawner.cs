using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject objectPrefab, mainScreen, target;
    public Transform parentTransform;
    public Vector2 startPosition, targetPosition;
    public WorkShooterController workShooterController;


    void Start()
    {
        workShooterController = GetComponent<WorkShooterController>();
        targetPosition = target.transform.position;
    }

    private void Update()
    {
        if (gameObject.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                workShooterController.animator.SetTrigger("Shoot");
                workShooterController.animator.ResetTrigger("Shoot");
                SpawnObject();

            }
        }
    }

    void SpawnObject()
    {
        if (workShooterController.numberOfLives > 0 & mainScreen.activeSelf)
        {
            // Calculate random spawn position
            startPosition = transform.position;
            startPosition.y = startPosition.y + 3;

            // Instantiate object at spawn position
            GameObject obj = GameObject.Instantiate(objectPrefab, startPosition, Quaternion.identity, parentTransform);
            Debug.Log("Spawned at " + obj.transform.position);
        }
    }

}
