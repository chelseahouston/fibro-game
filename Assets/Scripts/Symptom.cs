using UnityEngine;

[System.Serializable]
public class Symptom
{
    public string symptomName;
    public float minLevel;
    public float maxLevel;
    public float decreaseRate;
    public float increaseRate;
    public GameObject bar;
    public float currentValue;

    public Symptom(string name, float minLevel, float maxLevel, float decreaseRate, GameObject bar)
    {
        this.symptomName = name;
        this.minLevel = minLevel;
        this.maxLevel = maxLevel;
        this.decreaseRate = decreaseRate;
        this.bar = bar;
    }
}
