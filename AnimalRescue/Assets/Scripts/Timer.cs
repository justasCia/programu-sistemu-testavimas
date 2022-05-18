using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float initialMin = 1f;
    public float initialSec = 10f;
    public float timeRemaining;
    public bool IsRuning = false;
    public TextMeshProUGUI timer;
    public UnityEvent OutOfTime;


    // Start is called before the first frame update
    void Start()
    {
        //timer = GetComponent<TextMeshProUGUI>();
        Time.timeScale = 1f;
        timeRemaining = initialMin * 60 + initialSec;
    }

    // Update is called once per frame
    void Update()
    {
        DisplayTime(timeRemaining);
        if (IsRuning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                IsRuning = false;
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
                OnNoTimeRemaining();
            }

        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float min = Mathf.FloorToInt(timeToDisplay / 60);
        float sec = Mathf.FloorToInt(timeToDisplay % 60);
        timer.text = string.Format("{0:00}:{1:00}", min, sec);
    }

    public void StartTimer()
    {
        IsRuning = true;
    }

    void OnNoTimeRemaining()
    {
        OutOfTime.Invoke();
    }
}
