using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] ResourceBank resourceBank;
    private void Awake()
    {
        resourceBank.resourceDictionary.Add(GameResource.Humans, new ObservableInt(10));
        resourceBank.resourceDictionary.Add(GameResource.Food, new ObservableInt(5));
        resourceBank.resourceDictionary.Add(GameResource.Wood, new ObservableInt(5));
        resourceBank.resourceDictionary.Add(GameResource.Stone, new ObservableInt(0));
        resourceBank.resourceDictionary.Add(GameResource.Gold, new ObservableInt(0));
        resourceBank.resourceDictionary.Add(GameResource.HumansProdLvl, new ObservableInt(1));
        resourceBank.resourceDictionary.Add(GameResource.FoodProdLvl, new ObservableInt(1));
        resourceBank.resourceDictionary.Add(GameResource.WoodProdLvl, new ObservableInt(1));
        resourceBank.resourceDictionary.Add(GameResource.StoneProdLvl, new ObservableInt(1));
        resourceBank.resourceDictionary.Add(GameResource.GoldProdLvl, new ObservableInt(1));
    }
}