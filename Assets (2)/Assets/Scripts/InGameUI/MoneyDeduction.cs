using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyDeduction : MonoBehaviour
{
    public PlayerStatus playerStatus;
    [SerializeField] private TextMeshProUGUI moneyText;


    public void Start()
    {
        playerStatus = GameObject.FindAnyObjectByType<PlayerStatus>();  
    }

    public void OnButtonClick(int cost)
    {
        if (playerStatus.canSpendMoney(cost))
        {
            playerStatus.moneyDecrease(cost);
            UpdateMoney();
        }
    }
    private void UpdateMoney() 
    {
        moneyText.text = playerStatus.playerMoney.ToString();
    }
}
