using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleAnimationController : MonoBehaviour
{
    public Animator animator;
    public GameObject candles;
    public bool isAnimating;

    void Start()
    {
        ChangeView();
    }

    void OnEnable()
    {
        ChangeView();
    }

    public void ChangeView()
    {
        isAnimating = (PlayerPrefs.GetInt("CandlesPlaying") != 0);
        animator = candles.GetComponent<Animator>();
        animator.keepAnimatorStateOnDisable = true;
        animator.SetBool("Play", isAnimating);
    }

    public void OnClick()
    {
        isAnimating = !isAnimating;
        PlayerPrefs.SetInt("CandlesPlaying", (isAnimating ? 1 : 0));
        animator.SetBool("Play", isAnimating);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("CandlesPlaying", (false ? 1 : 0));
    }

}

