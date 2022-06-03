using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceManager : MonoBehaviour
{
    // dependencies
    public Conditions conditions;

    // events
    public VoidEvent conditionStart;
    public VoidEvent questionnaireStart;

    // Start is called before the first frame update
    void Start()
    {
        conditions.Randomize();
    }

    public void StartCondition() 
    {
        conditionStart.raiseEvent();
    }

    public void StartQuestionaire() 
    {
        questionnaireStart.raiseEvent();
    }
}
