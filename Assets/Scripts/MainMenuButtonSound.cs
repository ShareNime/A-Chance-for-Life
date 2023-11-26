using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtonSound : MonoBehaviour
{ 
    [SerializeField] private AudioClip buttonClicked;
    

    private AudioSource audioSource;
    private float footstepTimer;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    

    public void ButtonClicked()
    {
        if (buttonClicked == null)
        {
            Debug.LogWarning("No door sounds assigned to the player.");
            return;
        }

        audioSource.clip = buttonClicked;
        audioSource.Play();
    }

    

}
