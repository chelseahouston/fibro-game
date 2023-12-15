using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPanel : MonoBehaviour
{
    public GameObject needsPanel;
    public GameObject tasksPanel;
    public GameObject calendarPanel;


    private void Start() 
    { 
        HideCalendar();
        HideTasks();
        HideNeeds();
    }


    public void ShowTasks()
    {
        if (needsPanel.activeSelf)
        {
            needsPanel.SetActive(false);
        }
        tasksPanel.SetActive(true);
    }

    public void HideTasks()
    {
        tasksPanel.SetActive(false);
    }

    public void ShowNeeds()
    {
        if (tasksPanel.activeSelf)
        {
            tasksPanel.SetActive(false);
        }

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

    public void OnTasksClick()
    {
        if (tasksPanel.activeSelf)
        {
            HideTasks();
        }
        else
        {
            ShowTasks();
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
}
