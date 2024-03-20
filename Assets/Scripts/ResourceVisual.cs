using UnityEngine;
using UnityEngine.UI;

public class ResourceVisual : MonoBehaviour
{
    private GameResource _resourceType;
    private Text _resourceText;
    private ResourceBank _resourceBank;

    private void Start()
    {
        _resourceBank = FindObjectOfType<ResourceBank>();
        UpdateResourceText();
    }

    private void UpdateResourceText()
    {
        int resourceValue = _resourceBank.GetResource(_resourceType);
        _resourceText.text = resourceValue.ToString();
    }
}
