using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour
{
    public SFXSound sFXSound;

    public GameObject popup;
    public PlayerMovement player;
    public PlayerStatus playerStatus;
    public bool canInteract;
    private void Awake() {
    }
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
            if(player.isInteracting == true){
                StartCoroutine(doingSinkTask());
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            popup.SetActive(false);
        }
    }
    IEnumerator doingSinkTask(){
        canInteract = false;
        Debug.Log("DARI ATAS");

        sFXSound.WaterSinkSound();

        yield return new WaitForSeconds(2f);
        playerStatus.waterRestock();
        Debug.Log("DARI BAWAH");
        player.isInteracting = false;
        player.canWalk = true;
        canInteract = true;
    }
}
