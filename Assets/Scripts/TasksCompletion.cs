using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Collections;

public class TaskManager : MonoBehaviour
{
    public TextMeshProUGUI[] taskTexts;
    public Image[] completionImages;
    public List<string> tasklist = new List<string>();

    // for future use of adding tasks gradually
    public List<string> activeTaskList = new List<string>();


    private void Start()
    {
        // testing - - - -
        PopulateTaskList();
        RandomlyAssignTasks();
    }

    // tasks to be gradually shown throughout the gameplay to help advance the story - the below are placeholers
    public void PopulateTaskList()
    {
        tasklist.Clear();
        tasklist.Add("Visit the Community Club");
        tasklist.Add("Complete your work Project");
        tasklist.Add("Cook a meal from scratch");
        tasklist.Add("Go for a walk for an hour");
        tasklist.Add("Attend the Community Club Support Group");
        tasklist.Add("Socialise with a friend");
        tasklist.Add("Go to sleep before 10pm");
        tasklist.Add("Study for 3 hours total");
        tasklist.Add("Meditate Outside");
        tasklist.Add("Go to the Cinema");
    }

    public void RandomlyAssignTasks()
    {
        ResetTasks();
        for (int i = 0; i < taskTexts.Length; i++)
        {
            if (tasklist.Count > 0)
            {
                int randomKey = Random.Range(0, tasklist.Count);
                string task = tasklist[randomKey];
                taskTexts[i].text = task;
                tasklist.RemoveAt(randomKey);
            }
            else
            {
                Debug.LogWarning("Not enough tasks in the list to assign.");
            }
        }
    }

    // for future of adding one task gradually to progress the story
    public void AssignTask(string task)
    {
        if (tasklist.Contains(task))
        {
            activeTaskList.Add(task);
        }
    }


    // call this method when a task is completed
    public void CompleteTask(int taskIndex)
    {
        if (taskIndex >= 0 && taskIndex < taskTexts.Length)
        {

            // Activate the corresponding completion image
            if (taskIndex < completionImages.Length)
            {
                completionImages[taskIndex].gameObject.SetActive(true);
            }
        }
        else
        {
            Debug.LogWarning("Invalid task index");
        }
    }

    public void ResetTasks()
    {
        foreach (TextMeshProUGUI text in taskTexts)
        {
            text.text = "";
        }
        foreach (var completionImage in completionImages)
        {
            completionImage.gameObject.SetActive(false);
        }
    }




}
