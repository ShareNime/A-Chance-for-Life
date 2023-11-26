using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Computer : MonoBehaviour
{
    public GameObject popup;
    public PlayerMovement player;
    public PlayerStatus playerStatus;
    public bool canInteract;
    public GameObject computerUIGameobject;
    public Door door;
    int fertilizerPrice = 50;
    public Coroutine courierLeaveCoroutine;
    private void Awake() {
        door = door.GetComponent<Door>();

    }
    private void Start() {
        
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
                OpenComputerWindow();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            popup.SetActive(false);
        }
    }
    void OpenComputerWindow(){
        canInteract = false;
        computerUIGameobject.SetActive(true);
    }
    public void CloseComputerwindow(){
        player.isInteracting = false;
        player.canWalk = true;
        canInteract = true;
    }
    IEnumerator doingTask(){
        canInteract = false;
        Debug.Log("DARI ATAS");
        yield return new WaitForSeconds(5f);
        Debug.Log("DARI BAWAH");
        player.isInteracting = false;
        player.canWalk = true;
        canInteract = true;
    }
    public void clickBuyFertilizer(){
        if(canBuy(fertilizerPrice)){
            StartCoroutine(buyFertilizer());
        }else{
            Debug.Log("MISKIN!");
        }
    }
    private bool canBuy(int cost){
        if(playerStatus.playerMoney > cost){
            return true;
        }
        return false;
    }
    IEnumerator buyFertilizer(){
        // Close UI
        yield return new WaitForSeconds(5f);
        // WaitForSecond
        // Kirim signal ke pintu agar bisa dibuka
        door.isPacketCome = true;
        door.waitToOpen = true;
        //Play Sound Bell
        courierLeaveCoroutine = StartCoroutine(door.courierLeave());
    }
}
