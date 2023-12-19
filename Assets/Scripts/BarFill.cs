using UnityEngine;
using UnityEngine.UI;

public class BarFill : MonoBehaviour
{
    public float maxValue;
    public Image fill;

    public float CurrentValue { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        maxValue = 110; // (11 blocks in the bar, 10 value each)
        fill.fillAmount = 1;
    }

    public void SetValue(float value)
    {
        CurrentValue = Mathf.Clamp(value, 0, maxValue);
        fill.fillAmount = CurrentValue / maxValue;
    }


}
