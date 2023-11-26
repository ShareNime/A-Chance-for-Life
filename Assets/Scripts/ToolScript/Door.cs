using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    private SpriteRenderer sr;
    public GameObject popup;
    public PlayerMovement player;
    public PlayerStatus playerStatus;
    public Computer computer;
    public bool canInteract;
    public bool isPacketCome = false;
    public bool waitToOpen = false;
    private Animator doorAnim;

    public SFXSound sfxSound;

    private void Start() {
        sr = this.gameObject.GetComponent<SpriteRenderer>();
        doorAnim = GetComponent<Animator>();
    }
    private void Update() {
        if(waitToOpen){
            //Play Sound Gedor Pintu
        }
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
        if(canInteract && isPacketCome){
            if(player.isInteracting == true){
                Debug.Log("player buka pintu doang");
                StartCoroutine(takePacket());
            }
        }else if(!isPacketCome){
            if(player.isInteracting){
                Debug.Log("Player buka pintu tapi gaada apa aap");
                player.isInteracting = false; 
                player.canWalk = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            popup.SetActive(false);
        }
    }

    public IEnumerator courierLeave(){
        Debug.Log("Courier wait to Leave");

        sfxSound.DoorBell();

        yield return new WaitForSeconds(10f);

        sfxSound.GetComponent<AudioSource>().loop = false;

        Debug.Log("Courier Left");
        waitToOpen = false;
        isPacketCome = false;
        
    }

    IEnumerator takePacket(){ 
        computer.StopCoroutine(computer.courierLeaveCoroutine); // Stop the courierLeaveCoroutine
        // computer.StopCoroutine(computer.courierLeaveCoroutine);
        // StopCoroutine(computer.courierLeaveCoroutine);
        // StopCoroutine(courierLeave());
        Debug.Log("player buka piontu dan kurir nunggu");
        waitToOpen = false;
        canInteract = false;
        // Paket Datang
        // Dimasukan ke Inven
        // Curr Fertilizer++
        doorAnim.SetBool("Open",true);
        sfxSound.GetComponent<AudioSource>().loop = false;
        sfxSound.PlayOpenDoorSound();
        yield return new WaitForSeconds(3f);

        sfxSound.DoorClose();
        sfxSound.DoorBell();

        doorAnim.SetBool("Open",false);
        playerStatus.fertilizerRestock();
        isPacketCome = false;
        player.isInteracting = false;
        player.canWalk = true;
        canInteract = true;
        

    }
}
