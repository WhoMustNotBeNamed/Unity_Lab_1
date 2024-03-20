using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ProductionBuilding : MonoBehaviour
{
    public float productionTime;
    [SerializeField] GameResource resource;
    [SerializeField] ResourceBank bank;
    [SerializeField] Button button;
    [SerializeField] Slider progressSlider;
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
        time  = productionTime;
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

        while (timer < productionTime)
        {
            timer += Time.deltaTime;    
            progressSlider.value = timer / productionTime;
            yield return null;
        }

        bank.StartCoroutine(ProductionResourceCoroutine());
        progressSlider.gameObject.SetActive(false); 
        isProducting = false;
        button.interactable = true;
    }
}
