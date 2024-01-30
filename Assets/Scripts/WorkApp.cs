using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WorkApp : MonoBehaviour
{
    public GameObject clockInOb, mainWorkScreen, bugBorder;
    public TextMeshProUGUI clockIn;
    public Animator workAnimator;

    private void Start()
    {
        clockInOb.SetActive(false);
        workAnimator.SetBool("ClockingIn", false);
        mainWorkScreen.SetActive(false);
        bugBorder.SetActive(false);

    }
    public void loadWorkApp(AnimationEvent animationEvent)
    {
        clockInOb.SetActive(true);
    }

    public void ClockIn()
    {
        clockInOb.SetActive(false);
        workAnimator.SetBool("ClockingIn", true);
    }

    public void ClockedIn(AnimationEvent animationEvent)
    {
        mainWorkScreen.SetActive(true);
        bugBorder.SetActive(true);
    }



}
