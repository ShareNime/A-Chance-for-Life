using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [HideInInspector] public float horizontal;
    private float speed = 5f;
    public bool isFacingRight = true;
    [SerializeField] private Rigidbody2D rb;
    public PlayerInputActions playerControls;
    private InputAction move;
    private InputAction interact;
    private Animator playerAnim;

    public bool isWalking = false;
    public bool isInteracting = false;
    public bool canWalk = true;
    public bool isInteractingButtonDown;

    private void Awake() {
        playerControls = new PlayerInputActions();
        playerAnim = this.GetComponent<Animator>();
    }
    private void OnEnable() {
        move = playerControls.Player.Move;
        interact = playerControls.Player.Interact;
        move.Enable();
        interact.Enable();
    }
    private void OnDisable() {
        move.Disable();
        interact.Disable();

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool isInteractingButtonDown = playerControls.Player.Interact.ReadValue<float>() > 0.1;
        if(isInteractingButtonDown){
            isInteracting = true;
        }
        if(!isInteracting && canWalk){
            Flip();
            horizontal = move.ReadValue<Vector2>().x;  
        }
        if(isInteracting){
            canWalk = false;
        }
        AnimationUpdate();
    }
    private void FixedUpdate() {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    void AnimationUpdate(){
        if(horizontal !=0 ){
            playerAnim.SetBool("isWalking", true);
        }else{
            playerAnim.SetBool("isWalking", false);
        }
    }
    private void Flip(){
        if (isFacingRight && horizontal < 0f){
            Vector3 localScale = transform.localScale;
            localScale.x = -1f;
            transform.localScale = localScale;
            isFacingRight = false;
        }
        if (!isFacingRight && horizontal > 0f){
            Vector3 localScale = transform.localScale;
            localScale.x = 1f;
            transform.localScale = localScale;
            isFacingRight = true;
        }
    }
    private void Interact(){
        
        // isInteracting = true;
        // Debug.Log("TEMP FROM adadad"+ temp);
        //pas udh selesai interact, set isInteracting = False dan canWalk = True;
        // isInteracting = false;
        // canWalk = true;
    }
}
