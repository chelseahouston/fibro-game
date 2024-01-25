using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPanel : MonoBehaviour
{
    public GameObject needsPanel;
    public GameObject SymptomsPanel;
    public GameObject calendarPanel;
    public NeedsManager needsManager;
    public GameObject mainSymptomsPanel;


    private void Start() 
    { 
        HideCalendar();
        mainSymptomsPanel.SetActive(false);
    }

    public void SymptomTime()
    {
        mainSymptomsPanel.SetActive(true);
    }


    public void ShowSymptoms()
    {
        SymptomsPanel.SetActive(true);
    }

    public void HideSymptoms()
    {
        SymptomsPanel.SetActive(false);
    }

    public void ShowNeeds()
    {
        needsPanel.SetActive(true);
    }

    public void HideNeeds()
    {
        needsPanel.SetActive(false);
    }

    public void ShowCalendar()
    {
        calendarPanel.SetActive(true);  
    }

    public void HideCalendar()
    {
        calendarPanel.SetActive(false);
    }


    public void OnNeedsClick()
    {
        if (needsPanel.activeSelf)
        {
            HideNeeds();
        }
        else
        {
            ShowNeeds();
        }
    }

    public void OnSymptomsClick()
    {
        if (SymptomsPanel.activeSelf)
        {
            HideSymptoms();
        }
        else
        {
            ShowSymptoms();
        }
    }

    public void OnCalClick()
    {
        if (calendarPanel.activeSelf)
        {
            HideCalendar();
        }
        else
        {
            ShowCalendar();
        }
    }

    public void HideAllUI()
    {
        HideSymptoms();
        HideNeeds();
        HideCalendar();
    }
}
