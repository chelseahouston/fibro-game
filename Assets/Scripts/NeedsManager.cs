using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NeedsManager : MonoBehaviour
{
    public List<Need> needsList = new List<Need>();
    public List<GameObject> needsBars = new List<GameObject>();
    public List<float> needsAmts = new List<float>();
    private Dictionary<string, float> currentLevels = new Dictionary<string, float>();

    private float updateInterval = 1.0f;
    private float timeSinceLastUpdate = 0.0f;

    public LoadPanel loadpanel;

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

        if (loadpanel.needsPanel.activeSelf)
        {
            ShowNeeds();
        }
    }

    void InitializeNeeds()
    {
        needsAmts = new List<float>(needsList.Count);

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
            thisBar.SetValue(need.maxLevel); // set as new current value
            needsAmts.Add(needsList[i].maxLevel); // add to needsAmts
            i++; // continue iteration
        }

    }
    public void DecreaseNeeds()
    {
        for (int i = 0; i < needsList.Count; i++)
        {
            BarFill thisBar = needsBars[i].GetComponent<BarFill>();
            float currentValue = thisBar.CurrentValue;
            float newValue = currentValue - needsList[i].decreaseRate;

            if (newValue < needsList[i].minLevel)
            {
                newValue = needsList[i].minLevel;
            }

            needsAmts[i] = newValue;
        }
    }

    public void ShowNeeds()
    {
        int i = 0; // first in array to iterate through needs
        foreach (Need need in needsList)
        {
            BarFill thisBar = needsBars[i].GetComponent<BarFill>();
            thisBar.SetValue(needsAmts[i]); // set as new current value for each bar and show
            i++; // continue iteration
        }
    }

/*
    public void IncreaseNeeds(string name)
    {
        int index = GetNeedLocationByName(name);
        Need need = needsList[index];
        Debug.Log("Increasing " + name);
        BarFill thisBar = needsBars[index].GetComponent<BarFill>(); // get the bar fill for this need
        float currentValue = thisBar.CurrentValue; // get and store the current value
        float newValue = currentValue + need.increaseRate; // new value is current plus this need's increasing value
        if (newValue > need.maxLevel)
            {
                newValue = need.maxLevel;
            }
        needsAmts[index] = newValue; // assign value to list in same order

    }

    public int GetNeedLocationByName(string name) {
        int index = 0;
        switch (name)
        {
            case "Hunger":
                index = 0;
                break;
            case "Sleep":
                index = 1;
                break;
            case "Toilet":
                index = 2;
                break;
            case "Hygiene":
                index = 3;
                break;
            case "Fun":
                index = 4;
                break;
            case "Pain":
                index = 5;
                break;
            case "Fatigue":
                index = 6;
                break;
            case "Brain Fog":
                index = 7;
                break;
            case "Social":
                index = 8;
                break;
            case "Happiness":
                index = 9;
                break;
        }

        return index;
    }
*/

}
