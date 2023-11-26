using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar_Water : MonoBehaviour
{
    public PlayerStatus playerStatus;
    public Slider slider;

    public int minSliderValue = 0;
    public int maxSliderValue;

    public Gradient gradient;

    private void Awake() {
        maxSliderValue = playerStatus.maxWaterStock;
    }
    private void Update()
    {
        if (playerStatus != null && slider != null)
        {
            // Update the slider value based on the current water stock
            float currentWaterStock = playerStatus.currWaterStock;

            // Ensure the value is within the specified range
            float clampedValue = Mathf.Clamp(currentWaterStock, minSliderValue, maxSliderValue);

            // Calculate the slider value as a percentage of the range
            float normalizedValue = (clampedValue - minSliderValue) / (maxSliderValue - minSliderValue);

            // Set the slider's value
            slider.value = normalizedValue;
        }
    }
}
