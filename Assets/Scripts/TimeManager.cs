using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI dateText;
    public TextMeshProUGUI dayText;
    public Image[] dayImages; // array of day images (28 in total) for the green blocks to show which day it is
    //public Toggle timeFormatToggle; // toggle for 12/24 hour format to be set by the user

    private DateTime currentTime;
    private string currentDay; // Mon, Tues, Wed, Thurs, Fri, Sat, Sun
    private int currentDate; // 1 - 28
    private int currentMonth; // 1 - 4
    private int currentYear; // 1 +
    private bool is24HourFormat = true; // defaults to 24-hour format

    public List<int> mailDays = new List<int>(); // days user gets mail

    private const float realTimePerGame15Minute = 1f; // increase by 15 minutes every 5 seconds real time


    void Start()
    {
        InitializeGameTime();
        UpdateUI();
        InvokeRepeating("ProgressTime", 0f, realTimePerGame15Minute);
        InitializeMailDays();
    }

    void InitializeGameTime()
    {
        currentTime = new DateTime(2024, 1, 1, 7, 0, 0); // Initial time
        currentDay = "Mon";
        currentDate = 1;
        currentMonth = 1;
        currentYear = 1;
    }

    public int GetCurentDate()
    {
        return currentDate;
    }

    void ProgressTime()
    {
        currentTime = currentTime.AddMinutes(15);

        if (currentTime.Hour == 0 && currentTime.Minute == 0)
        {
            ProgressDate();
        }

        UpdateUI();
    }

    void ProgressDate()
    {
        currentDate++;

        if (currentDate > 28)
        {
            currentDate = 1;
            currentMonth++;
            if (currentMonth > 4)
            {
                currentMonth = 1;
                currentYear++;
            }
        }

        // Reset time to 7:00 AM when a new day starts
        currentTime = new DateTime(currentYear, currentMonth, currentDate, 0, 0, 0);
        currentDay = GetDayOfWeekForCurrentDate();
    }

    void UpdateUI()
    {
        timeText.text = is24HourFormat ? currentTime.ToString("HH:mm") : currentTime.ToString("h:mm tt");
        dateText.text = "Month " + currentMonth + " / Year " + currentYear;
        dayText.text = currentDay + " " + currentDate;

        for (int i = 0; i < dayImages.Length; i++)
        {
            dayImages[i].color = i + 1 == currentDate ? Color.green : Color.clear;
        }
    }

    private string GetDayOfWeekForCurrentDate()
    {
        if (currentDate == 1 || currentDate == 8 || currentDate == 15 || currentDate == 22)
        {
            return "Mon";
        }
        else if (currentDate == 2 || currentDate == 9 || currentDate == 16 || currentDate == 23)
        {
            return "Tue";
        }
        else if (currentDate == 3 || currentDate == 10 || currentDate == 17 || currentDate == 24)
        {
            return "Wed";
        }
        else if (currentDate == 4 || currentDate == 11 || currentDate == 18 || currentDate == 25)
        {
            return "Thurs";
        }
        else if (currentDate == 5 || currentDate == 12 || currentDate == 19 || currentDate == 26)
        {
            return "Fri";
        }
        else if (currentDate == 6 || currentDate == 13 || currentDate == 20 || currentDate == 27)
        {
            return "Sat";
        }
        else if (currentDate == 7 || currentDate == 14 || currentDate == 21 || currentDate == 28)
        {
            return "Sun";
        }
        else
        {
            return "";


        }
    }

    private void InitializeMailDays()
    {
        mailDays.Clear();
        mailDays.AddRange(new[] { 1, 5, 9, 15, 19, 22, 27 });
    }

    public bool IsItMailDay()
    {
        if (mailDays.Contains(currentDate)) { 
            return true; 
        }
        else { 
            return false; 
        }
    }

        //public void ToggleTimeFormat()
        //{
        //    is24HourFormat = timeFormatToggle.isOn;
        //    UpdateUI();
        //}
 }
