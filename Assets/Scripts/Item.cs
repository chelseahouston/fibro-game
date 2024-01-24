using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[System.Serializable]
public class Item
{
    public Dictionary<string, int> needIncreases;
    public Dictionary<string, int> symptomDecreases;
    public NeedsManager needsManager;
    public string itemName;

    public Item(string name)
    {
        this.itemName = name;
        this.needIncreases = new Dictionary<string, int>();
    }

    public void SetNeedIncreaseValue(string need, int value)
    {
        needIncreases.Add(need, value);

    }

    public void SetSymptomDecreaseValue(string symptom, int value)
    {
        symptomDecreases.Add(symptom, value);

    }

    public void IncreaseNeeds()
    {
        
        if (needsManager != null)
        {
            
            Debug.Log("needs to increase: " + needIncreases.Count);
            for (int i = 0; i < needIncreases.Count; i++)
            {
                Debug.Log("Increasing needs for " + itemName);
                KeyValuePair<string, int> need = GetElementAtIndex(needIncreases, i);
                int increaseValue = need.Value;
                needsManager.IncreaseNeeds(need.Key, increaseValue);
            }
        }
        else
        {
            Debug.LogError("NeedsManager not assigned to Item: " + itemName);
        }
    }

    public void DecreaseSymptom()
    {

        if (needsManager != null)
        {

            Debug.Log("symptom to increase: " + symptomDecreases.Count);
            for (int i = 0; i < symptomDecreases.Count; i++)
            {
                Debug.Log("Decreasing symptoms for " + itemName);
                KeyValuePair<string, int> symptom= GetElementAtIndex(symptomDecreases, i);
                int decreaseValue = symptom.Value;
                needsManager.DecreaseSymptoms(symptom.Key, decreaseValue);
            }
        }
        else
        {
            Debug.LogError("NeedsManager not assigned to Item: " + itemName);
        }
    }

    static KeyValuePair<TKey, TValue> GetElementAtIndex<TKey, TValue>(Dictionary<TKey, TValue> dictionary, int index)
    {
        if (index < 0 || index >= dictionary.Count)
        {
            throw new IndexOutOfRangeException("Index is out of range");
        }

        // Convert the dictionary to a list of key-value pairs
        List<KeyValuePair<TKey, TValue>> list = new List<KeyValuePair<TKey, TValue>>(dictionary);

        // Access the element by index in the list
        return list[index];
    }
}
