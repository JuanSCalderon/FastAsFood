using UnityEngine;
using UnityEngine.UI;

public class WeightBarController : MonoBehaviour
{
    public Slider sliderHealth;
    public Slider sliderBad;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.Instance;
        sliderHealth.maxValue = 1;
        sliderBad.maxValue = 1;
    }

    void Update()
    {
        float weightPoints = gameManager.weightPoints;
        float normalizedWeight = gameManager.NormalizedWeight(weightPoints);

        if (normalizedWeight >= 0.45f && normalizedWeight <= 0.55f)
        {
            sliderHealth.value = 0;
            sliderBad.value = 0;
        }
        else if (normalizedWeight < 0.45f)
        {
            sliderHealth.value = 0;
            sliderBad.value = 1 - normalizedWeight / 0.45f;
        }
        else
        {
            sliderHealth.value = (normalizedWeight - 0.55f) / 0.45f;
            sliderBad.value = 0;
        }
    }
}