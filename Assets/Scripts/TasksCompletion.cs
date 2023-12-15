using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using Unity.VisualScripting;

public class TaskManager : MonoBehaviour
{
    public TextMeshProUGUI[] taskTexts;
    public Image[] completionImages;
    public Dictionary<int, string> tasklist = new Dictionary<int, string>();


    private void Start()
    {
        PopulateTaskList(); // test
        AssignTasks();
        CompleteTask(0); // test to show first task completed only

        
    }


    public void PopulateTaskList()
    {
        tasklist.Clear();
        tasklist.Add(1, "Bathe once today");
        tasklist.Add(2, "Work for 4 hours total");
        tasklist.Add(3, "Cook a meal from scratch");
        tasklist.Add(4, "Go for a walk for an hour");
        tasklist.Add(5, "Attend the Community Club Support Group");
        tasklist.Add(6, "Socialise with a friend");
        tasklist.Add(7, "Go to sleep before 10pm");
        tasklist.Add(8, "Watch TV");
        tasklist.Add(9, "Wash the dishes");
        tasklist.Add(10, "Spend time with your pet");
        tasklist.Add(11, "Take your meds");
        tasklist.Add(12, "Brush your teeth");
        tasklist.Add(13, "Vaccuum");
        tasklist.Add(14, "Play Video Games");
        tasklist.Add(15, "Read a book");
        tasklist.Add(16, "Feed your pet");
        tasklist.Add(17, "Buy Groceries");
        tasklist.Add(18, "Study for 3 hours total");
        tasklist.Add(19, "Meditate Outside");
        tasklist.Add(20, "Go to the Cinema");
    }

    public void AssignTasks()
    {
        ResetTasks();
        for (int i = 0; i < taskTexts.Length; i++)
        {
            int randomKey = Random.Range(1, tasklist.Count + 1);
            taskTexts[i].text = tasklist[randomKey];
            tasklist.Remove(randomKey);
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
