using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NeedsManager : MonoBehaviour
{
    public List<Need> needsList = new List<Need>(10);
    [SerializeField] public List<GameObject> needsBars = new List<GameObject>(10);
    private List<float> currentLevels = new List<float>(10);

    private float updateInterval = 1.0f;
    private float timeSinceLastUpdate = 0.0f;

    public LoadPanel loadpanel;
    public GameObject UI, needsPanel;

    public SceneChangeDetector sceneChangeDetector;
    public bool SceneSetup;


    private static NeedsManager instance;


    private void Awake()
    {

        // Ensure there is only one instance of the Data object
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        sceneChangeDetector = GameObject.Find("SceneChangeDetector").GetComponent<SceneChangeDetector>();

    }


    public void Update()
    {
        timeSinceLastUpdate += Time.deltaTime;

        if (timeSinceLastUpdate >= updateInterval & SceneSetup)
        {

            DecreaseNeeds(); // pretty much always decreasing
            timeSinceLastUpdate = 0.0f;
        }

        if (sceneChangeDetector.sceneChanged && !SceneSetup)
        {
            Instantiate();
        }
    }

    public void Instantiate()
    {
        
        Debug.Log("SceneChanged: " + sceneChangeDetector.sceneChanged);

        if (needsPanel == null)
        {
            Debug.LogError("Needs Panel Not Found!");
            
        }
        else
        {
            Debug.Log("Needs Panel Found!");
            Initialize();
        }
    }


    void Initialize()
    {


        // initialise list of needs and their values
        
        needsList.Clear();
        currentLevels.Clear();
        needsList.Add(new Need("Hunger", 10, 110, 0.4f, 110, needsBars[0]));
        needsList.Add(new Need("Sleep", 10, 110, 0.8f, 10, needsBars[1]));
        needsList.Add(new Need("Toilet", 10, 110, 0.6f, 110, needsBars[2]));
        needsList.Add(new Need("Hygiene", 10, 110, 0.4f, 110, needsBars[3]));
        needsList.Add(new Need("Fun", 10, 110, 0.6f, 110, needsBars[4]));
        needsList.Add(new Need("Pain", 10, 100, 0.9f, 110, needsBars[5]));
        needsList.Add(new Need("Fatigue", 10, 100, 0.8f, 110, needsBars[6]));
        needsList.Add(new Need("Brain Fog", 10, 100, 0.6f, 110, needsBars[7]));
        needsList.Add(new Need("Social", 10, 110, 0.3f, 110, needsBars[8]));
        needsList.Add(new Need("Happiness", 10, 110, 0.4f, 110, needsBars[9]));

        ResetNeeds();
        
        SceneSetup = true;

    }


    public void ResetNeeds()
    {

        for (int i = 0; i < needsList.Count; i++)
        {
            BarFill thisBar = needsBars[i].GetComponent<BarFill>(); // get the bar fill for this need
            thisBar.SetValue(110); // set as new current value
            currentLevels.Add(needsList[i].maxLevel); // add to current values list
            // all needs are now at maximum levels
        }
        
        loadpanel.HideNeeds();

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
