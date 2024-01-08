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
    private List<float> currentLevels = new List<float>();

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
        // initialise list of needs and their values
        needsList.Clear();
        currentLevels.Clear();
        needsList.Add(new Need("Hunger", 10, 110, 2f, 110, needsBars[0]));
        needsList.Add(new Need("Sleep", 10, 110, 2f, 10, needsBars[1]));
        needsList.Add(new Need("Toilet", 10, 110, 1f, 110, needsBars[2]));
        needsList.Add(new Need("Hygiene", 10, 110, 1f, 110, needsBars[3]));
        needsList.Add(new Need("Fun", 10, 110, 2f, 110, needsBars[4]));
        needsList.Add(new Need("Pain", 10, 110, 2f, 110, needsBars[5]));
        needsList.Add(new Need("Fatigue", 10, 110, 2f, 110, needsBars[6]));
        needsList.Add(new Need("Brain Fog", 10, 110, 2f, 110, needsBars[7]));
        needsList.Add(new Need("Social", 10, 110, 2f, 110, needsBars[8]));
        needsList.Add(new Need("Happiness", 10, 110, 2f, 110, needsBars[9]));
        ResetNeeds();

    }


    public void ResetNeeds()
    {
        int i = 0; // first in array to iterate through needs
        foreach (Need need in needsList)
        {

            BarFill thisBar = needsBars[i].GetComponent<BarFill>(); // get the bar fill for this need
            thisBar.SetValue(110); // set as new current value
            currentLevels.Add(needsList[i].maxLevel); // add to current values list
            i++; // continue iteration
            // all needs are now at maximum levels
        }

    }
    public void DecreaseNeeds()
    {

        for (int i = 0; i < currentLevels.Count; i++)
        {

            currentLevels[i] -= needsList[i].decreaseRate;

            if (currentLevels[i] < needsList[i].minLevel)
            {
                currentLevels[i] = needsList[i].minLevel;
            }
            Debug.Log($"{needsList[i].name}: Current={currentLevels[i]}, DecreaseRate={needsList[i].decreaseRate}");
        }
    }

    public void ShowNeeds()
    {
        int i = 0; // first in array to iterate through needs
        foreach (Need need in needsList)
        {
            BarFill thisBar = needsBars[i].GetComponent<BarFill>();
            thisBar.SetValue(currentLevels[i]); // set as new current valsue for each bar and show
            i++; // continue iterations
        }
    }


    public void IncreaseNeeds(string name)
    {
        int index = GetNeedLocationByName(name);
        Need need = needsList[index];
        Debug.Log("Increasing " + name);
        BarFill thisBar = needsBars[index].GetComponent<BarFill>(); // get the bar fill for this need
        currentLevels[index] += need.increaseRate; // new value is current plus this need's increasing value
        if (currentLevels[index] > need.maxLevel)
            {
            currentLevels[index] = need.maxLevel;
            }
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


}
