using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Balcony : MonoBehaviour
{
    public GameObject popup;
    public PlayerMovement player;
    public bool canInteract;
    [SerializeField]
    CinemachineVirtualCamera vcam_outdoor;
    [SerializeField]
    GameObject BalconyUI;
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
                changecinemachinepriority(11);
                BalconyUI.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            popup.SetActive(false);
        }
    }
    public void changecinemachinepriority(int x){
        vcam_outdoor.m_Priority = x;
    }
    public void exitbalcony(int x){
        vcam_outdoor.m_Priority = x;
        player.isInteracting = false;
        player.canWalk = true;
        canInteract = true;
        Debug.Log("memek balkoni rusak");
    }
}
