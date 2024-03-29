using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseNeeds : MonoBehaviour
{
    public NeedsManager needsManager;
    private bool triggered;
    public List<string> needs = new List<string>();
    public List<Item> items = new List<Item>();
    public Item item;
    public Computer computer;
    public bool triggerComputer;

    void Start()
    {
        AddItems();
        triggerComputer = false;
    }

    private void Update()
    {
        // if action button pressed
        if (Input.GetKeyDown(KeyCode.E))

        { // if within trigger area of an object
            if (triggered)
            {
                if (triggerComputer)
                {
                    computer.StartComputer();
                    
                }
                else
                {
                    // increase the needs for that object
                    item.IncreaseNeeds();
                   
                }
                triggered = false; // reset bool

            }
        }
    }

    private void AddItems()
    {
        items.Clear();
        items.Add(new Item("Bath"));
        items.Add(new Item("Toilet"));
        items.Add(new Item("TV"));
        items.Add(new Item("Chair"));
        items.Add(new Item("Bench"));
        items.Add(new Item("Bed"));
        items.Add(new Item("Fridge"));
        items.Add(new Item("Stove"));


        // Bath Values
        items[0].SetNeedIncreaseValue("Hygiene", 100);
        items[0].SetNeedIncreaseValue("Pain", 70);

        // Toilet Values
        items[1].SetNeedIncreaseValue("Toilet", 110);

        // TV Values
        items[2].SetNeedIncreaseValue("Fun", 50);

        // Chair/Sofa Values
        items[3].SetNeedIncreaseValue("Fatigue", 40);
        items[3].SetNeedIncreaseValue("Pain", 10);

        // Bench Values
        items[4].SetNeedIncreaseValue("Fatigue", 40);

        // Bed Values
        items[5].SetNeedIncreaseValue("Fatigue", 40);
        items[5].SetNeedIncreaseValue("Sleep", 90);

        // Fridge Values
        items[6].SetNeedIncreaseValue("Hunger", 60);

        // Stove Values
        items[7].SetNeedIncreaseValue("Hunger", 90);


    }

    public void GetItem(string name)
    {
        foreach (Item i in items)
        {
            if (i.itemName == name)
            {
                item = i; 
                break;
            }
        }
    }


    public void OnTriggerEnter2D(Collider2D thing)
    {
        // if it doesnt hve a trigger collider, don't do anything
        if (!thing.isTrigger)
        {
            return;
        }
        if (thing.tag == "Computer")
        {
            triggerComputer = true;
            triggered = true;
        }
        else
        {
            GetItem(thing.name);
            
            if (item != null)
            {
                item.needsManager = needsManager;
                triggered = true;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D thing)
    {
        item = null;
        triggered = false;
        if (triggerComputer)
        {
            triggerComputer = false;
        }
    }
}
