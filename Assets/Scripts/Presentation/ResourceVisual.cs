using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class ResourceVisual : MonoBehaviour
{
    [SerializeField] GameResource resourceType;
    [SerializeField] ResourceBank resourceRank;
    [SerializeField] Text textComponent;

    void Start()
    {
        resourceRank = FindObjectOfType<ResourceBank>();
        if (resourceRank != null)
        {
            ObservableInt resource = resourceRank.GetResource(resourceType);
            resource.PropertyChanged += UpdateTextEvent;
            UpdateText(resource.Value);
        }
    }
    
    void UpdateText(int value)
    {
        textComponent.text = $"{value}";
    }
    
    void UpdateTextEvent(object sender,  PropertyChangedEventArgs e)
    {
        UpdateText(((ObservableInt)sender).Value);
    }
}