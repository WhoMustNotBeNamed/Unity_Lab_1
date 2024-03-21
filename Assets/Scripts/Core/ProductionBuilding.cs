using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ProductionBuilding : MonoBehaviour
{
    public float productionTime ;
    [SerializeField] GameResource resource;
    [SerializeField] ResourceBank bank;
    [SerializeField] Button button;
    [SerializeField] Slider progressSlider;
    [SerializeField] ProductionBuilding productionBuilding;
    private bool isProducting = false;
    private float time;

    public IEnumerator ProductionResourceCoroutine()
    {
        bank.ChangeRecources(resource, 1);
        yield return new WaitForSeconds(productionTime);
    }
    
    public void Start()
    {
        progressSlider.gameObject.SetActive(false);
        time  = productionBuilding.productionTime;
        Debug.Log("Start: " + time);
    }

    public void StartProduction()
    {
        if (!isProducting)
        {
            isProducting = true;
            button.interactable = false;
            StartCoroutine(ProduceResource());
        }
    }

    IEnumerator ProduceResource()
    {
        float timer = 0f;
        progressSlider.value = 0f;

        progressSlider.gameObject.SetActive(true);

        while (timer < productionBuilding.productionTime)
        {
            timer += Time.deltaTime;    
            progressSlider.value = timer / productionBuilding.productionTime;
            yield return null;
        }

        bank.StartCoroutine(productionBuilding.ProductionResourceCoroutine());
        progressSlider.gameObject.SetActive(false); 
        isProducting = false;
        button.interactable = true;
    }

    public void LvlUp()
    {
        Debug.Log("Click: " + time);
        bank.ChangeRecources(resource, 10);
        productionBuilding.productionTime = time * (1f - (float)bank.resourceDictionary[resource].Value / 100f);
    }
}
