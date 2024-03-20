using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] ResourceBank resourceBank;
    private void Awake()
    {
        resourceBank.resourceDictionary.Add(GameResource.Humans, new ObservableInt(10));
        resourceBank.resourceDictionary.Add(GameResource.Food, new ObservableInt(5));
        resourceBank.resourceDictionary.Add(GameResource.Wood, new ObservableInt(5));
    }
}