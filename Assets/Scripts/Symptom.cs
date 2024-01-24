using UnityEngine;

[System.Serializable]
public class Symptom
{
    public string needName;
    public float minLevel;
    public float maxLevel;
    public float decreaseRate;
    public float increaseRate;
    public GameObject bar;
    public float currentValue;

    public Symptom(string name, float minLevel, float maxLevel, float decreaseRate, GameObject bar)
    {
        this.needName = name;
        this.minLevel = minLevel;
        this.maxLevel = maxLevel;
        this.decreaseRate = decreaseRate;
        this.bar = bar;
    }
}
