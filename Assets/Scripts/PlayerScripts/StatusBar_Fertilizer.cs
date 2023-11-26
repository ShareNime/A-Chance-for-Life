using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar_Fertilizer : MonoBehaviour
{
    public PlayerStatus playerStatus;
    public Slider fertilizerSlider;

    public int minSliderValue = 0;
    public int maxSliderValue;

    public Gradient gradient;
    private void Awake() {
        maxSliderValue = playerStatus.maxFertilizerStock;
    }
    private void Update()
    {
        if (playerStatus != null && fertilizerSlider != null)
        {
            float currentFertilizerStock = playerStatus.currFertilizerStock;
            float clampedValue = Mathf.Clamp(currentFertilizerStock, minSliderValue, maxSliderValue);
            float normalizedValue = (clampedValue - minSliderValue) / (maxSliderValue - minSliderValue);

            fertilizerSlider.value = normalizedValue;
        }
      
    }
}
