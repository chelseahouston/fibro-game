using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NeedsManager : MonoBehaviour
{
    public List<Need> needsList = new List<Need>();
    [SerializeField] public List<GameObject> needsBars = new List<GameObject>();

    public List<Symptom> symptomsList = new List<Symptom>();
    [SerializeField] public List<GameObject> stymptomsBars = new List<GameObject>();

    private List<float> currentLevels = new List<float>();
    private List<float> currentSymptomLevels = new List<float>();

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

        if (timeSinceLastUpdate >= updateInterval)
        {
            DecreaseNeeds(); // pretty much always decreasing
            if (loadpanel.mainSymptomsPanel.activeSelf) // if symptoms starting to show, increase their severity
            {
                InitializeSymptoms();
                IncreaseSymptoms();
            }
            
            timeSinceLastUpdate = 0.0f;
        }

        if (sceneChangeDetector.sceneChanged && !SceneSetup)
        {
            Instantiate();
        }

        if (SceneSetup && needsPanel.activeSelf)
        {
            ShowNeeds();
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
            InitializeNeeds();
        }
    }


    void InitializeNeeds()
    {


        // initialise list of needs and their values
        
        needsList.Clear();
        currentLevels.Clear();
        needsList.Add(new Need("Hunger", 10, 110, 0.4f, needsBars[0]));
        needsList.Add(new Need("Sleep", 10, 110, 0.8f, needsBars[1]));
        needsList.Add(new Need("Toilet", 10, 110, 0.6f, needsBars[2]));
        needsList.Add(new Need("Hygiene", 10, 110, 0.4f, needsBars[3]));
        needsList.Add(new Need("Fun", 10, 110, 0.6f, needsBars[4]));
        ResetNeeds();
        
        SceneSetup = true;

    }

    void InitializeSymptoms()
    {
        // symptoms
        symptomsList.Clear();
        symptomsList.Add(new Symptom("Pain", 10, 100, 0.9f, needsBars[5]));
        symptomsList.Add(new Symptom("Fatigue", 10, 100, 0.8f, needsBars[6]));
        symptomsList.Add(new Symptom("Brain Fog", 10, 100, 0.6f, needsBars[7]));
        ResetSymptoms();
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

    public void ResetSymptoms()
    {

        for (int i = 0; i < symptomsList.Count; i++)
        {
            BarFill thisBar = needsBars[i].GetComponent<BarFill>(); // get the bar fill for this need
            thisBar.SetValue(10); // set as new current value
            currentSymptomLevels.Add(symptomsList[i].minLevel); // add to current values list
            // all needs are now at maximum levels
        }

    }

    public void DecreaseNeeds()
    {

        for (int i = 0; i < needsList.Count; i++)
        {

            currentLevels[i] -= needsList[i].decreaseRate;

            if (currentLevels[i] < needsList[i].minLevel)
            {
                currentLevels[i] = needsList[i].minLevel;
            }
        }
    }

    public void IncreaseSymptoms()
    {

        for (int i = 0; i < symptomsList.Count; i++)
        {
            currentSymptomLevels[i] += symptomsList[i].decreaseRate;

            if (currentSymptomLevels[i] > symptomsList[i].maxLevel)
            {
                currentSymptomLevels[i] = symptomsList[i].maxLevel;
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

    public void ShowSymptoms()
    {
        int i = 0; // first in array to iterate through needs
        foreach (Symptom symptom in symptomsList)
        {
            ;
            BarFill thisBar = needsBars[i].GetComponent<BarFill>();
            thisBar.SetValue(currentSymptomLevels[i]); // set as new current valsue for each bar and show
            i++; // continue iterations
        }
    }


    public void IncreaseNeeds(string name, int increaseRate)
    {
        Debug.Log("Increasing " + name);

        int index = GetNeedLocationByName(name);
        Need need = needsList[index];
        
        BarFill thisBar = needsBars[index].GetComponent<BarFill>(); // get the bar fill for this need
        currentLevels[index] += increaseRate; // new value is current plus this need's increasing value
        if (currentLevels[index] > need.maxLevel)
            {
            currentLevels[index] = need.maxLevel;
            }
    }

    public void DecreaseSymptoms(string name, int decreaseRate)
    {
        Debug.Log("Decreasing " + name);

        int index = GetSymptomLocationByName(name);
        Symptom symptom = symptomsList[index];

        BarFill thisBar = needsBars[index].GetComponent<BarFill>(); // get the bar fill for this need
        currentSymptomLevels[index] += decreaseRate; // new value is current plus this need's increasing value
        if (currentSymptomLevels[index] < symptom.minLevel)
        {
            currentSymptomLevels[index] = symptom.minLevel;
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
        }

        return index;
    }

    public int GetSymptomLocationByName(string name)
    {
        int index = 0;
        switch (name)
        {
            case "Pain":
                index = 0;
                break;
            case "Fatigue":
                index = 1;
                break;
            case "Brain Fog":
                index = 2;
                break;
        }

        return index;
    }


}
