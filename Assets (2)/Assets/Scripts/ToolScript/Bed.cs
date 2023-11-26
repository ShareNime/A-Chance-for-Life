using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Bed : MonoBehaviour
{
    public GameObject popup;
    public PlayerMovement player;
    public bool canInteract;
    public WorldTime worldTime;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            canInteract = true;
            popup.SetActive(true);
            // if(player.isInteracting == true){
            //     StartCoroutine(doingTask());
            // }
            Debug.Log(player.canWalk);
        }
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(canInteract){
            if(player.isInteracting == true && worldTime.canSleep == false){
                player.isInteracting = false; 
                player.canWalk = true;
            }else if(player.isInteracting == true && worldTime.canSleep){
                StartCoroutine(Sleep());
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            popup.SetActive(false);
        }
    }
    IEnumerator Sleep(){
        canInteract = false;
        Debug.Log("Dah Tdiur");
        yield return new WaitForSeconds(2f);
        worldTime.TimeSkip(5,0);
        Debug.Log("ABIS TIMESKIP");
        player.isInteracting = false;
        player.canWalk = true;
        canInteract = true;
    }
}
