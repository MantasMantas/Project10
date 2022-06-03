using UnityEngine;

[CreateAssetMenu(fileName = "New flag", menuName = "Scriptable Objects/Events/Flag/New Flag")]
public class Flag : ScriptableObject
{
    private bool enabled = false;

    public void EnableFlag()
    {
        enabled = true;
    }

    public void DisableFlag()
    {
        enabled = false;
    }

    public bool GetFlag()
    {
        return enabled;
    }
}
