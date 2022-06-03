using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QManager : MonoBehaviour
{
    public ToggleGroup[] toggleGroups;
    public Button submitButton;
    public GameObject Questionnnaire;
    public Conditions conditions;
    public FileName fileName;
    public VoidEvent conditionStart;

    private CSVTool csvTool;
    private string loggingHeader = "Question, Answer";
    private ScrollRect scrollRect;

    private void Start()
    {
        scrollRect = Questionnnaire.GetComponent<ScrollRect>();
    }

    public void OnEnabled()
    {
        Questionnnaire.SetActive(true);
        submitButton.enabled = false;
        scrollRect.verticalNormalizedPosition = 1;

        foreach(ToggleGroup toggleGroup in toggleGroups) 
        {
            toggleGroup.SetAllTogglesOff();
        }
    }

    public void OnToggled() 
    {
        bool ready = true;

        foreach (ToggleGroup toggleGroup in toggleGroups)
        {
            if (!toggleGroup.AnyTogglesOn())
            {
                ready = false;
                return;
            }
        }

        if (ready) 
        {
            submitButton.enabled = true;
        }
    }

    public void OnSubmited() 
    {
        csvTool = new CSVTool(fileName.Get() + "_Condition_" + conditions.GetCondition().ToString() + "_Q", loggingHeader);

        foreach (ToggleGroup toggleGroup in toggleGroups)
        {
            foreach (Toggle toggle in toggleGroup.ActiveToggles())
            {
                csvTool.WriteLine(toggleGroup.name + "," + toggle.name + "\n");
            }
        }

        Questionnnaire.SetActive(false);
        conditionStart.raiseEvent();
        conditions.IncreamentIndex();
    }
}
