using UnityEngine;

[System.Serializable]
public class Need
{
    public string needName;
    public float minLevel;
    public float maxLevel;
    public float decreaseRate;
    public GameObject bar;
    public float currentValue;

    public Need(string name, float minLevel, float maxLevel, float decreaseRate, GameObject bar)
    {
        this.needName = name;
        this.minLevel = minLevel;
        this.maxLevel = maxLevel;
        this.decreaseRate = decreaseRate;
        this.bar = bar;
    }
}
