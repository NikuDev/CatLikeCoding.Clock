using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public Transform HoursTransform, MinutesTransform, SecondsTransform;
    public bool Continuous;

    private readonly float _degreesPerHour = 30f;
    private readonly float _degreesPerMinute = 6f;
    private readonly float _degreesPerSecond = 6f;

    void Awake()
    {
        // log the time on awake for debugging purposes
        Debug.Log(DateTime.Now);

        // use the function to set the arms to the current time
        this.TransformArmsToCurrentTimeDiscrete();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // use the appropriate function to update the rotation of the arms
        if (this.Continuous)
        {
            this.TransformArmsToCurrentTimeContinuous();
        }
        else
        {
            this.TransformArmsToCurrentTimeDiscrete();
        }
    }

    private void TransformArmsToCurrentTimeDiscrete()
    {
        DateTime currentTime = DateTime.Now;
        this.HoursTransform.localRotation =
            Quaternion.Euler(0, currentTime.Hour * _degreesPerHour, 0);
        this.MinutesTransform.localRotation =
            Quaternion.Euler(0, currentTime.Minute * _degreesPerMinute, 0);
        this.SecondsTransform.localRotation =
            Quaternion.Euler(0, currentTime.Second * _degreesPerSecond, 0);
    }
    private void TransformArmsToCurrentTimeContinuous()
    {
        TimeSpan currentTimePrecise = DateTime.Now.TimeOfDay;
        this.HoursTransform.localRotation =
            Quaternion.Euler(0, (float)currentTimePrecise.TotalHours * _degreesPerHour, 0);
        this.MinutesTransform.localRotation =
            Quaternion.Euler(0, (float)currentTimePrecise.TotalMinutes * _degreesPerMinute, 0);
        this.SecondsTransform.localRotation =
            Quaternion.Euler(0, (float)currentTimePrecise.TotalSeconds * _degreesPerSecond, 0);
    }
}
