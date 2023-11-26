using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField]
    private GameObject giveFertilizerButton;
    [SerializeField]
    private GameObject giveWaterButton;
    [SerializeField]
    private PlantStatus plantstatus;
    
    public void WhenPlantClick(){
        if(giveFertilizerButton.activeSelf && giveWaterButton.activeSelf){
            giveFertilizerButton.SetActive(false);
            giveWaterButton.SetActive(false);
        }else{
            giveFertilizerButton.SetActive(true);
            giveWaterButton.SetActive(true);
        }
        
    }
    public void whenFertilizerButtonClick(){
        plantstatus.FertilizerStatusIncrease(25);
        giveFertilizerButton.SetActive(false);
        giveWaterButton.SetActive(false);
    }
    public void whenWaterButtonClick(){
        plantstatus.WaterStatusIncrease(30);
        giveFertilizerButton.SetActive(false);
        giveWaterButton.SetActive(false);
    }
}
