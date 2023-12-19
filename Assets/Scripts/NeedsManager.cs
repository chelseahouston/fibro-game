using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NeedsManager : MonoBehaviour
{
    public List<Need> needsList = new List<Need>();
    public List<GameObject> needsBars = new List<GameObject>();
    private Dictionary<string, float> currentLevels = new Dictionary<string, float>();

    private float updateInterval = 1.0f;
    private float timeSinceLastUpdate = 0.0f;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Home") // placeholder for first playthrough for now
        {
            InitializeNeeds();
        }
    }

    public void Update()
    {
        timeSinceLastUpdate += Time.deltaTime;

        if (timeSinceLastUpdate >= updateInterval)
        {
            Debug.Log("Updating Needs");
            DecreaseNeeds(); // pretty much always decreasing
            timeSinceLastUpdate = 0.0f;
        }
    }

    void InitializeNeeds()
    {
        needsList.Clear();
        needsList.Add(new Need("Hunger", 0, 110, 5, 110, needsBars[0]));
        needsList.Add(new Need("Sleep", 0, 110, 8, 10, needsBars[1]));
        needsList.Add(new Need("Toilet", 0, 110, 5, 110, needsBars[2]));
        needsList.Add(new Need("Hygiene", 0, 110, 5, 110, needsBars[3]));
        needsList.Add(new Need("Fun", 0, 110, 5, 110, needsBars[4]));
        needsList.Add(new Need("Pain", 0, 80, 5, 110, needsBars[5]));
        needsList.Add(new Need("Fatigue", 0, 90, 5, 110, needsBars[6]));
        needsList.Add(new Need("Brain Fog", 0, 100, 5, 110, needsBars[7]));
        needsList.Add(new Need("Social", 0, 110, 5, 110, needsBars[8]));
        needsList.Add(new Need("Happiness", 0, 110, 5, 110, needsBars[9]));
        ResetNeeds();
    }


    public void ResetNeeds()
    {
        int i = 0; // first in array to iterate through needs
        foreach (Need need in needsList)
        {

            BarFill thisBar = needsBars[i].GetComponent<BarFill>(); // get the bar fill for this need
            thisBar.SetValue(need.minLevel); // set as new current value
            i++; // continue iteration
        }

    }
    public void DecreaseNeeds()
    {
        int i = 0; // first in array to iterate through needs
        foreach (Need need in needsList)
        {

            BarFill thisBar = needsBars[i].GetComponent<BarFill>(); // get the bar fill for this need
            float currentValue = thisBar.CurrentValue; // get and store the current value
            float newValue = currentValue + need.decreaseRate; // new value is current plus this need's decreasing value
            if (newValue < need.minLevel) {
                newValue = need.minLevel;
                    }
            thisBar.SetValue(newValue); // set as new current value
            i++; // continue iteration
        }

    }


    public void IncreaseNeeds()
    {

        Debug.Log("Increaseing Needs...");

        int i = 0; // first in array to iterate through needs
        foreach (Need need in needsList)
        {
            Debug.Log("Increasing " + need.name);
            BarFill thisBar = needsBars[i].GetComponent<BarFill>(); // get the bar fill for this need
            float currentValue = thisBar.CurrentValue; // get and store the current value
            float newValue = currentValue - need.increaseRate; // new value is current minus this need's increasing value
            if (newValue > need.maxLevel)
            {
                newValue = need.maxLevel;
            }
            thisBar.SetValue(newValue); // set as new current value
            i++; // continue iteration
        }

    }
}
