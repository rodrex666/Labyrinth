using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class showTimer : MonoBehaviour
{
    public TMP_Text timeCounter;
    private TimeSpan timePlaying;
    private bool _timerGoing;
    private float _elapsedTime;

    private void OnEnable()
    {
        enterPlayer.OnStart_T += BeginTimer;
        outPlayer.OnEnd_T += EndTimer;
    }
    private void OnDisable()
    {
        enterPlayer.OnStart_T -= BeginTimer;
        outPlayer.OnEnd_T -= EndTimer;
    }

    void Start()
    {
        timeCounter.text = "Time: 00:00.00";
        _timerGoing = false;
    }
   
    public void BeginTimer()
    {
        _timerGoing = true;
        _elapsedTime = 0f;
        StartCoroutine(UpdateTimer());

    }
    public void EndTimer()
    {
        _timerGoing = false;
    }
    private IEnumerator UpdateTimer()
    {
        while (_timerGoing)
        {
            _elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(_elapsedTime);
            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timePlayingStr;
            yield return null;

        }
    }
}
