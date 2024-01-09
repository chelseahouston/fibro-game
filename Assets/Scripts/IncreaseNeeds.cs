using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseNeeds : MonoBehaviour
{
    public NeedsManager needsManager;
    private bool triggered;
    public new string tag;


    private void Update()
    {
        // if action button pressed
        if (Input.GetKeyDown(KeyCode.E))

        { // if within trigger area of an object
            if (triggered)
            {
                // increase the needs for that object
                needsManager.IncreaseNeeds(tag);
                triggered = false; // reset bool
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
        else
        {
            triggered = true;
            tag = thing.tag;
            // set tag for use in Update method to increase needs for the item
        }
    }
}
