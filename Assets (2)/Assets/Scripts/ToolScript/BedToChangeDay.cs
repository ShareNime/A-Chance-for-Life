using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedToChangeDay : MonoBehaviour
{
    public GameObject popup;
    public PlayerMovement player;
    public PlayerStatus playerStatus;
    public PlantStatus plantStatus;

    public bool canInteract;


    private void Awake()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canInteract = true;
            popup.SetActive(true);
            Debug.Log(player.canWalk);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (canInteract)
        {
            if (player.isInteracting == true)
            {
                StartCoroutine(GoToBed());
                RollForAnomaly();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            popup.SetActive(false);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void RollForAnomaly()
    {
        int randomNumber = Random.Range(0, 2);
        Debug.Log("Random Number: " + randomNumber);

        if (randomNumber == 0)
        {
           // plantStatus.WeatherKemarau();
        }
        if (randomNumber == 1) 
        {
           // plantStatus.Malnourshied();
        }
    }

    //public void Dehydrated()
    //{
    //    
    //}

    //public void Malnoursihed()
    //{
//
   // }

    IEnumerator GoToBed()
    {
        canInteract = false;
        Debug.Log("DARI ATAS");
        yield return new WaitForSeconds(2f);
        Debug.Log("DARI BAWAH");
        player.isInteracting = false;
        
        canInteract = true;
        player.canWalk = true;
    }
}
