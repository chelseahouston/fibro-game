using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopStartPlayerMovement : MonoBehaviour
{

    public static StopStartPlayerMovement Instance;
    public bool moving;

    private void Awake()
    {
        // Ensure there is only one instance of the object
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        moving = true;
    }

    public void AlterPlayerMovement(bool move)
    {
        moving = move;
    }
}
