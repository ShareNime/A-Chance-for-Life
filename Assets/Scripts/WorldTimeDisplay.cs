using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
[RequireComponent(typeof(TMP_Text))]
public class WorldTimeDisplay : MonoBehaviour
{
    [SerializeField]
    private WorldTime world_Time;
    private TMP_Text _text;
    private void Awake() {
        _text = GetComponent<TMP_Text>();
        world_Time.WorldTimeChanged += OnWorldTimeChanged;
    }
    private void OnDestroy() {
        world_Time.WorldTimeChanged -= OnWorldTimeChanged;
    }
    private void OnWorldTimeChanged(object sender, TimeSpan newTime){
        _text.SetText(newTime.ToString(format:@"hh\:mm"));
    }
}
