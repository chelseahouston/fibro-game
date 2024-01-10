using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
[System.Serializable]
public class Item
{
    private Dictionary<string, int> needIncreases = new Dictionary<string, int>();
    public NeedsManager needsManager;
    public string itemName;

    void Start()
    {

    }

    public Item(string name)
    {
        this.itemName = name;
    }

    public void SetNeedIncreaseValue(string need, int value)
    {
        needIncreases[need] = value;
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


    public void IncreaseNeeds()
    {
        for (int i = 0; i < needIncreases.Count; i++) {
            KeyValuePair<string, int> need = GetElementAtIndex(needIncreases, i);
            int increaseValue = need.Value;
            needsManager.IncreaseNeeds(need.Key, increaseValue);
        }
    }
}
