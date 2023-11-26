using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBGM : MonoBehaviour
{
   [SerializeField] private AudioClip BGM;
    

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    

    public void ButtonClicked()
    {
        if (BGM == null)
        {
            Debug.LogWarning("No door sounds assigned to the player.");
            return;
        }

        audioSource.clip = BGM;
        audioSource.Play();
    }
}
