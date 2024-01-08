using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseNeeds : MonoBehaviour
{
    public NeedsManager needsManager;

    public void OnTriggerEnter2D(Collider2D thing)
    {
        if (!thing.isTrigger)
        {
            return;
        }

        needsManager.IncreaseNeeds(thing.tag);
    }
}
