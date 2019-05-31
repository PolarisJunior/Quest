using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubscriberList : MonoBehaviour
{
    public List<PObserver> subscribers;

    public void NotifyAll(string e)
    {
        foreach (PObserver obs in subscribers)
        {
            if (obs != null)
            {
                obs.Run(e);
            }
        }
    }
}
