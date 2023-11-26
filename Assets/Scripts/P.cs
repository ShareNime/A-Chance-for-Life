using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFXHandler : MonoBehaviour
{
    [Header("SFX Clips")]
    [SerializeField] private AudioClip[] footstepSounds;
    [SerializeField] private AudioClip openDoorSounds;
    [SerializeField] private AudioClip stairsSounds;
    [SerializeField] private AudioClip OpenDoorSound;
    [SerializeField] private AudioClip doorBell;
    [SerializeField] private AudioClip doorClose;
    [SerializeField] private AudioClip pouringWater;
    [SerializeField] private AudioClip pouringFertilizer;
    [SerializeField] private AudioClip ambienceMorning;
    [SerializeField] private AudioClip ambienceNight;
    [SerializeField] private AudioClip buttonClicked;
    [SerializeField] private AudioClip waterSinkSound;


    [Header("SFX Interval")]
    [SerializeField] private float footstepInterval = 0.5f;

    private AudioSource audioSource;
    private float footstepTimer;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        ActivateFootstepSound();
    }

    private void ActivateFootstepSound()
    {
        // Check if the player is moving
        if (Input.GetAxisRaw("Horizontal") != 0f || Input.GetAxisRaw("Vertical") != 0f)
        {
            // Check if enough time has passed to play footstep sound
            if (footstepTimer <= 0f)
            {
                PlayFootstepSound();
                footstepTimer = footstepInterval;
            }
            else
            {
                footstepTimer -= Time.deltaTime;
            }
        }
        else
        {
            footstepTimer = 0f;
        }
    }

    private void PlayFootstepSound()
    {
        if (footstepSounds.Length == 0)
        {
            Debug.LogWarning("No footstep sounds assigned to the player.");
            return;
        }

        // Play a random footstep sound from the footstepSounds array
        int randomIndex = Random.Range(0, footstepSounds.Length);
        audioSource.clip = footstepSounds[randomIndex];
        audioSource.Play();
    }

    public void PlayOpenDoorSound()
    {
        if (openDoorSounds == null)
        {
            Debug.LogWarning("No door sounds assigned to the player.");
            return;
        }

        audioSource.clip = openDoorSounds;
        audioSource.Play();
    }

    public void DoorClose()
    {
        if (doorBell == null)
        {
            Debug.LogWarning("No door sounds assigned to the player.");
            return;
        }

        audioSource.clip = doorClose;
        audioSource.Play();
    }    

    public void DoorBell()
    {
        if (doorBell == null)
        {
            Debug.LogWarning("No door sounds assigned to the player.");
            return;
        }

        audioSource.clip = doorBell;
        audioSource.Play();
    }

    public void PouringWater()
    {
        if (openDoorSounds == null)
        {
            Debug.LogWarning("No door sounds assigned to the player.");
            return;
        }

        audioSource.clip = pouringWater;
        audioSource.Play();
    }

    public void PouringFertilizer()
    {
        if (openDoorSounds == null)
        {
            Debug.LogWarning("No door sounds assigned to the player.");
            return;
        }

        audioSource.clip = pouringFertilizer;
        audioSource.Play();
    }

    public void AmbienceMorning()
    {
        if (openDoorSounds == null)
        {
            Debug.LogWarning("No door sounds assigned to the player.");
            return;
        }

        audioSource.clip = ambienceMorning;
        audioSource.Play();
    }

    public void AmbienceNight()
    {
        if (openDoorSounds == null)
        {
            Debug.LogWarning("No door sounds assigned to the player.");
            return;
        }

        audioSource.clip = ambienceNight;
        audioSource.Play();
    }

    public void ButtonClicked()
    {
        if (openDoorSounds == null)
        {
            Debug.LogWarning("No door sounds assigned to the player.");
            return;
        }

        audioSource.clip = buttonClicked;
        audioSource.Play();
    }

    public void WaterSinkSound()
        {
        if (waterSinkSound == null)
        {
            Debug.LogWarning("No door sounds assigned to the player.");
            return;
        }

        audioSource.clip = waterSinkSound;
        audioSource.Play();
    }


}