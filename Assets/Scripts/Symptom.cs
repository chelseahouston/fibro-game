using UnityEngine;

[System.Serializable]
public class Symptom
{
    public string symptomName;
    public float minLevel;
    public float maxLevel;
    public float increaseRate;
    public GameObject bar;
    public float currentValue;

    public Symptom(string name, float minLevel, float maxLevel, float increaseRate, GameObject bar)
    {
        this.symptomName = name;
        this.minLevel = minLevel;
        this.maxLevel = maxLevel;
        this.increaseRate = increaseRate;
        this.bar = bar;
    }
}
