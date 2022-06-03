using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TimeToWait timeToWait;
    public ConditionDuration conditionDuration;

    public VoidEvent timeOut;
    // Update is called once per frame
    void Update()
    {
        if (timeToWait.timerSet) 
        {
            if(timeToWait.GetTime() > 0) 
            {
                timeToWait.CountdownTheTimer(Time.deltaTime);
                //Debug.Log(timeToWait.GetTime());
            }
            else 
            {
                // trigger the timer event here
                //Debug.Log("Timer ran out!");
                timeToWait.timerSet = false;
                timeOut.raiseEvent();
            }

        }
    }

    public void SetTimer() 
    {
        timeToWait.SetTimer(conditionDuration.duration);
    }
}
