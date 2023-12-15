using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarFill : MonoBehaviour
{
    public int maxValue;
    public Image fill;
    private int currentValue;

    // Start is called before the first frame update
    void Start()
    {
        currentValue = maxValue;
        fill.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Add(int value)
    {
        currentValue += value;
        if (currentValue >= maxValue)
        {
            currentValue = maxValue;
        }

        fill.fillAmount = (float)currentValue/maxValue;
    }

    public void Deduct(int value)
    {
        currentValue -= value;
        if (currentValue <= 0)
        {
            currentValue = 0;
        }

        fill.fillAmount = (float)currentValue / maxValue;
    }

}
