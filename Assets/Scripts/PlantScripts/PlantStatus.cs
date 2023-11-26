using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using JetBrains.Annotations;
public class PlantStatus : MonoBehaviour
{
    public SFXSound sFXSound;

    // cari cara untuk save status.
    int MaxPlantHealth = 150;
    int MaxWaterStatus = 150;
    int MaxFertilizerStatus = 150;
    int MaxSunlightStatus = 150;
    //current Status
    int currPlantHealth = 100;
    [SerializeField]
    int currWaterStatus = 100;
    int currFertilizerStatus = 100;
    int currSunlightStatus = 100;
    [SerializeField]
    private TMP_Text plantNeeds;
    [SerializeField]
    private TMP_Text plantWater;
    [SerializeField]
    private TMP_Text plantFertilizer;
    [SerializeField]
    private PlayerStatus player;

    [SerializeField]
    private int PlantStage = 1;
    //1 = Stage 1: Baby
    //2 = Stage 2: Grow
    //3 = Stage 3: Grow
    //4 = Stage 4: Final Phase
    [SerializeField]
    private int PlantStatusOverall = 1;
    //0 = Die
    //1 = Normal
    //2 = Very Healthy
    public int plantExperience = 0;

    [SerializeField]
    private List<GameObject> Stage1Sprite = new List<GameObject>(3);
    [SerializeField]
    private List<GameObject> Stage2Sprite = new List<GameObject>(3);
    [SerializeField]
    private List<GameObject> Stage3Sprite = new List<GameObject>(3);
    [SerializeField]
    private List<GameObject> Stage4Sprite = new List<GameObject>(3);
    public WorldTime worldTime;
    public string state;

    [SerializeField]
    private GameObject GameOverUI;
    [SerializeField]
    private GameObject GameWin;


    // Start is called before the first frame update
    void Start()
    {
        SetupPlantStatusSchedule();
    }

    // Update is called once per frame
    void Update()
    {
        PlantStageCalculate();
        CalculatePlantHealth();
        PlantStageSpriteShow();
        Debug.Log("Plant Status overall" + PlantStatusOverall);
        Debug.Log("Plant Experience" + plantExperience);

        if (worldTime != null)
        {
            worldTime.InvokeScheduledEvents();
        }
        plantWater.text = "Plant Water: " + currWaterStatus.ToString();
        plantFertilizer.text = "Plant Fertilizer: " + currFertilizerStatus.ToString();

        if (PlantStatusOverall == 0)
        {
            Gameover();
        }

        if (worldTime.daysPassed == 15)
        {
            GameFinish();
        }

    }

    public void GameFinish()
    {
        GameWin.SetActive(true);
    }
    public void Gameover()
    {
        GameOverUI.SetActive(true);
    }

    void WaterStatusDecrease(int value){
        currWaterStatus -= value;
    }
    void FertilizerStatusDecrease(int value){
        currFertilizerStatus -= value;
    }
    void currSunlightStatusDecrease(int value){

    }
    public void WaterStatusIncrease(int value){
        if(player.currWaterStock >= value){

            sFXSound.PouringWater();

            player.currWaterStock -= value;
            // currWaterStatus += value;
            currWaterStatus = Math.Clamp(currWaterStatus + value, 0,MaxWaterStatus);
            Debug.Log("Player give " + value + " to water plant");
        }else{
            Debug.Log("Player not enough water");
        }
    }
    public void FertilizerStatusIncrease(int value){
        if(player.currFertilizerStock >= value){

            sFXSound.PouringFertilizer();
            player.currFertilizerStock -= value;
            // currFertilizerStatus += value;
            currFertilizerStatus = Math.Clamp(currFertilizerStatus + value, 0,MaxFertilizerStatus);
            Debug.Log("Player give " + value + " to Fertilize plant");
        }else{
            Debug.Log("Player not enough Fertilizer");
        }
    }
    void SunlightStatusIncrease(int value){

    }
    void CalculatePlantHealth(){
        if(currWaterStatus >= 75 && currFertilizerStatus >= 75){
            state = "healthy"; // Default to "healthy"
        }
        if(currFertilizerStatus < 75){
            state = "needFertilizer";
        }
        if (currWaterStatus < 75)
        {
            state = "dehydrated";
        }
        if (currFertilizerStatus < 40)
        {
            if (state == "dehydrated")
            {
                state = "wilting";
            }
        }

        // Display the plant's state in the TMP_Text component
        plantNeeds.text = "Plant State: " + state;
    }
    private void WaterDecreaseAt8AM()
    {
        WaterStatusDecrease(25);
        Debug.Log("WaterDecreaseAt8AM");
        // Your logic to update the plant's status based on the schedule
        // You can use currPlantHealth, currWaterStatus, and currFertilizerStatus as needed.
    }
    private void WaterDecreaseAt4PM()
    {
        WaterStatusDecrease(45);
        Debug.Log("WaterDecreaseAt4PM");
        // Your logic to update the plant's status based on the schedule
        // You can use currPlantHealth, currWaterStatus, and currFertilizerStatus as needed.
    }
    private void FertilizerDecreaseAt12PM(){
        FertilizerStatusDecrease(30);
        Debug.Log("FertilizerDecreaseAt12PM");
    }
    private void FertilizerDecreaseAt4PM(){
        FertilizerStatusDecrease(30);
        Debug.Log("FertilizerDecreaseAt4PM");
    }
    private void SetupPlantStatusSchedule(){
        worldTime.schedule.Add(new WorldTime.ScheduleEvent
        {
            hour = 8, // Adjust to the time you want to schedule
            minute = 0,
            action = WaterDecreaseAt8AM, // This is the method to update the plant's status
            executed = false
        });
        worldTime.schedule.Add(new WorldTime.ScheduleEvent
        {
            hour = 12, // Adjust to the time you want to schedule
            minute = 0,
            action = FertilizerDecreaseAt12PM, // This is the method to update the plant's status
            executed = false
        });
        worldTime.schedule.Add(new WorldTime.ScheduleEvent
        {
            hour = 16, // Adjust to the time you want to schedule
            minute = 0,
            action = WaterDecreaseAt4PM, // This is the method to update the plant's status
            executed = false
        });
        
        worldTime.schedule.Add(new WorldTime.ScheduleEvent
        {
            hour = 16, // Adjust to the time you want to schedule
            minute = 0,
            action = FertilizerDecreaseAt4PM, // This is the method to update the plant's status
            executed = false
        });
        worldTime.schedule.Add(new WorldTime.ScheduleEvent
        {
            hour = 23, // Adjust to the time you want to schedule
            minute = 59,
            action = CalculatePlantStatusOverall, // This is the method to update the plant's status
            executed = false
        });
        worldTime.schedule.Add(new WorldTime.ScheduleEvent
        {
            hour = 0, // Adjust to the time you want to schedule
            minute = 0,
            action = CalculatePlantExperience, // This is the method to update the plant's status
            executed = false
        });
    }
    void CalculatePlantStatusOverall(){
        if (currWaterStatus <= 0 || currFertilizerStatus <= 0)
        {
            PlantStatusOverall = 0; // Die
        }
        else if ((currWaterStatus >= 1 && currWaterStatus <= 100) && (currFertilizerStatus >= 1 && currFertilizerStatus <= 100))
        {
            PlantStatusOverall = 1; // Normal
        }
        else if ((currWaterStatus >= 100 && currWaterStatus <= 150) && (currFertilizerStatus >= 100 && currFertilizerStatus <= 150))
        {
            PlantStatusOverall = 2; // Very Healthy
        }
    }
    void CalculatePlantExperience(){
        if (PlantStatusOverall == 0)
        {
            Debug.Log("The plant has died, and the game has ended.");
            // You can end the game or perform any other necessary actions here.
        }
        else if (PlantStatusOverall == 1)
        {
            plantExperience += 100;
        }
        else if (PlantStatusOverall == 2)
        {
            plantExperience += 200;
        }
    }
    void PlantStageCalculate(){
        if(plantExperience <= 300){
            PlantStage = 1;
        }else if(plantExperience <= 500){
            PlantStage = 2;
        }else if(plantExperience <= 750){
            PlantStage = 3;
        }else if(plantExperience >= 1000){
            PlantStage = 4;
        }
    }
    void PlantStageSpriteShow(){
        if(PlantStage == 1){
            if(state == "healthy"){
                Stage1Sprite[0].SetActive(true);
                Stage1Sprite[1].SetActive(false);
                Stage1Sprite[2].SetActive(false);
            }else if(state == "dehydrated"){
                Stage1Sprite[0].SetActive(false);
                Stage1Sprite[1].SetActive(true);
                Stage1Sprite[2].SetActive(false);
            }else{
                Stage1Sprite[0].SetActive(false);
                Stage1Sprite[1].SetActive(false);
                Stage1Sprite[2].SetActive(true);
            }
        }
        if(PlantStage == 2){
            foreach(GameObject i in Stage1Sprite){
                i.SetActive(false);
            }
            if(state == "healthy"){
                Stage2Sprite[0].SetActive(true);
                Stage2Sprite[1].SetActive(false);
                Stage2Sprite[2].SetActive(false);
            }else if(state == "dehydrated"){
                Stage2Sprite[0].SetActive(false);
                Stage2Sprite[1].SetActive(true);
                Stage2Sprite[2].SetActive(false);
            }else{
                Stage2Sprite[0].SetActive(false);
                Stage2Sprite[1].SetActive(false);
                Stage2Sprite[2].SetActive(true);
            }
        }
        if(PlantStage == 3){
            foreach(GameObject i in Stage2Sprite){
                i.SetActive(false);
            }
            if(state == "healthy"){
                Stage3Sprite[0].SetActive(true);
                Stage3Sprite[1].SetActive(false);
                Stage3Sprite[2].SetActive(false);
            }else if(state == "dehydrated"){
                Stage3Sprite[0].SetActive(false);
                Stage3Sprite[1].SetActive(true);
                Stage3Sprite[2].SetActive(false);
            }else{
                Stage3Sprite[0].SetActive(false);
                Stage3Sprite[1].SetActive(false);
                Stage3Sprite[2].SetActive(true);
            }
        }
        if(PlantStage == 4){
            foreach(GameObject i in Stage3Sprite){
                i.SetActive(false);
            }
            if(state == "healthy"){
                Stage4Sprite[0].SetActive(true);
                Stage4Sprite[1].SetActive(false);
                Stage4Sprite[2].SetActive(false);
            }else if(state == "dehydrated"){
                Stage4Sprite[0].SetActive(false);
                Stage4Sprite[1].SetActive(true);
                Stage4Sprite[2].SetActive(false);
            }else{
                Stage4Sprite[0].SetActive(false);
                Stage4Sprite[1].SetActive(false);
                Stage4Sprite[2].SetActive(true);
            }
        }
    }
}
