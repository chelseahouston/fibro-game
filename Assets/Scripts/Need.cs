using UnityEngine;

[System.Serializable]
public class Need
{
    public string name;
    public float minLevel;
    public float maxLevel;
    public float decreaseRate;
    public float increaseRate;
    public GameObject bar;
    public float currentValue;

    public Need(string name, float minLevel, float maxLevel, float decreaseRate, GameObject bar)
    {
        this.name = name;
        this.minLevel = minLevel;
        this.maxLevel = maxLevel;
        this.decreaseRate = decreaseRate;
        this.bar = bar;
    }
}
