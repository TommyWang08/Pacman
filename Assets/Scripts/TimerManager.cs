using System;
using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour{
    public TextMeshProUGUI timerText;
    private float elapsedTime = 0f;
    private bool isTiming = false;

    void Start(){
        ResetTimer();
    }

    void Update(){

        if (isTiming){

            elapsedTime += Time.deltaTime;
            UpdateTimerDisplay();
        }
    }

    public void StartTimer(){

        isTiming = true;
    }

    public void StopTimer(){

        isTiming = false;
    }


    public void ResetTimer(){

        elapsedTime = 0f;
        UpdateTimerDisplay();
    }


    private void UpdateTimerDisplay(){

        TimeSpan timeSpan = TimeSpan.FromSeconds(elapsedTime);
        timerText.text = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds / 10);
    }
}
