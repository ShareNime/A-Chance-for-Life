using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WorldTime : MonoBehaviour
{

    public BGMSound bgmsound;

    [SerializeField]
    public PlayerStatus playerStatus;
    public bool canSleep = false;
    public event EventHandler<TimeSpan> WorldTimeChanged;
    [SerializeField]
    private float _dayLength;
    public TimeSpan _currentTime;
    private float _minuteLength => _dayLength / WorldTimeConstant.MinuteInDay;
    public List<ScheduleEvent> schedule = new List<ScheduleEvent>();
    public int daysPassed = 0;
    private bool audioPlayed = false;
    [Serializable]
    public class ScheduleEvent
    {
        public int hour;
        public int minute;
        public Action action;
        public bool executed;
    }
    [SerializeField]
    private TMP_Text dayCountText;
    private IEnumerator AddMinute(){
        _currentTime += TimeSpan.FromMinutes(1);
        if (_currentTime.TotalMinutes >= WorldTimeConstant.MinuteInDay){
            ChangeDay();
        }
        WorldTimeChanged?.Invoke(this, _currentTime);
        yield return new WaitForSeconds(_minuteLength);
        StartCoroutine(AddMinute());
    }
    // Start is called before the first frame update
    void Start()
    { 
        StartCoroutine(AddMinute());
        bgmsound.AmbienceMorning();
    }

    // Update is called once per frame
    void Update()
    {
        if(_currentTime.Hours > 21){
            canSleep = true;
        }else{
            canSleep = false;
        }
        
        if(_currentTime.Hours == 5 && _currentTime.Minutes == 0)
        {
            bgmsound.AmbienceMorning();
        }
        if(_currentTime.Hours == 19 && _currentTime.Minutes == 0)
        {
            bgmsound.AmbienceNight();
        }
    }
    public void InvokeScheduledEvents()
    {
        foreach (var scheduledEvent in schedule)
        {
            if (!scheduledEvent.executed && scheduledEvent.hour == _currentTime.Hours && scheduledEvent.minute == _currentTime.Minutes)
            {
                scheduledEvent.action.Invoke();
                scheduledEvent.executed = true;
            }
        }
    }
    public void ResetScheduleFlags()
    {
        foreach (var scheduledEvent in schedule)
        {
            scheduledEvent.executed = false;
        }
    }
    public void TimeSkip(int hour, int minute)
    {
        ChangeDay();
        // Set the current time to the specified hour and minute
        _currentTime = new TimeSpan(hour, minute, 0);
    }
    void ChangeDay(){
        _currentTime = _currentTime.Subtract(TimeSpan.FromMinutes(WorldTimeConstant.MinuteInDay));
        daysPassed++; // Increment the day count
        dayCountText.text = "Day: " + (daysPassed+1).ToString();
        playerStatus.playerMoney += 100;
        ResetScheduleFlags();
    }
}
