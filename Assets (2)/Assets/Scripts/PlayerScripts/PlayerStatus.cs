using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int playerMoney = 100;
    public int maxFertilizerStock = 100;
    public int maxWaterStock = 100;
    public int currFertilizerStock;
    public int currWaterStock;
    bool canUseFertilizer;
    bool canUseWater;
    // Start is called before the first frame update
    private void Awake() {
        currFertilizerStock = maxFertilizerStock;
        currWaterStock = maxWaterStock;
        canUseFertilizer = true;
        canUseWater = true;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void waterRestock(){
        currWaterStock = maxWaterStock;
        canUseWater = true;
    }
    public void fertilizerRestock(){
        currFertilizerStock = maxFertilizerStock;
        canUseFertilizer = true;
    }
    public void waterStockDecrease(int cost){
        // CHECK APAKAH cost > CURR STOCK
        // IF TRUE KELUARIN cost, jika tidak KELUARIN curr stock
        if(currWaterStock >= cost){
            currWaterStock -= cost;
        }else{
            canUseWater = false;
        }
        if(currWaterStock < 0){
            currWaterStock = 0;
        }
    }
    public void fertilizerStockDecrease(int cost){
        // CHECK APAKAH cost > CURR STOCK
        // IF TRUE KELUARIN cost, jika tidak KELUARIN curr stock
        if(currFertilizerStock >= cost){
            currFertilizerStock -= cost;
        }else{
            canUseFertilizer = false;
        }
        if(currFertilizerStock < 0){
            currFertilizerStock = 0;
        }
    }
    public void moneyDecrease(int cost){
        playerMoney -= cost;
    }
    public bool canSpendMoney(int cost){
        if(playerMoney >= cost){
            return true;
        }
        return false;
    }
}
