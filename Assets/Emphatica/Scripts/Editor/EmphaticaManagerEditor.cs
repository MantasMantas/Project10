using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EmphaticaManager))]
public class EmphaticaManagerEditor : Editor
{
    public override void OnInspectorGUI() 
    {
        DrawDefaultInspector();

        EmphaticaManager emphaticaManager = (EmphaticaManager)target;

        if(GUILayout.Button("Set Up")) 
        {
            emphaticaManager.SetUp();
        }

        if(GUILayout.Button("Connect Device")) 
        {
            emphaticaManager.ConnectDevice();
        }
        if (GUILayout.Button("Subscribe")) 
        {
            emphaticaManager.Subscribe();
        }
        if (GUILayout.Button("Unsubscribe"))
        {
            emphaticaManager.Unsubscribe();
        }
        if (GUILayout.Button("Disconect device")) 
        {
            emphaticaManager.Disconect();
        }
    }
}
