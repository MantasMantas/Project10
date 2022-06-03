using UnityEngine;

[CreateAssetMenu(fileName = "TimeToWait", menuName = "Scriptable Objects/TimeToWait")]
public class TimeToWait : ScriptableObject
{
    private float value = 0f;

    [HideInInspector]
    public bool timerSet;
    public void SetTimer(float value) 
    {
        this.timerSet = true;
        this.value = value;
    }

    public void CountdownTheTimer(float value) 
    {
        this.value -= value;   
    }

    public float GetTime() 
    {
        return this.value;
    }
}
