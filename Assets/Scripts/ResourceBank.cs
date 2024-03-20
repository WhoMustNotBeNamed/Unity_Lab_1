using System;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBank : MonoBehaviour
{
    public Dictionary<GameResource, ObservableInt> resourceDictionary = new Dictionary<GameResource, ObservableInt>();
    
    public void ChangeResource(GameResource resource, int value)
    {
        resourceDictionary[resource].Value += value;
    }

    public ObservableInt GetResource(GameResource resource)
    {
        return resourceDictionary[resource];
    }
}