using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMSound : MonoBehaviour
{


    [SerializeField] private AudioClip ambienceMorning;
    [SerializeField] private AudioClip ambienceNight;
  

    private AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void AmbienceMorning()
    {
        if (ambienceMorning == null)
        {
            Debug.LogWarning("No door sounds assigned to the player.");
            return;
        }

        audioSource.clip = ambienceMorning;
        audioSource.Play();
    }

    public void AmbienceNight()
    {
        if (ambienceNight == null)
        {
            Debug.LogWarning("No door sounds assigned to the player.");
            return;
        }

        audioSource.clip = ambienceNight;
        audioSource.Play();
    }
}
