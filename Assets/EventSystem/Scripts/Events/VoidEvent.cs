using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This class is used for Events that have no arguments (Example: Exit game event)
/// </summary>

[CreateAssetMenu(fileName="New Void event", menuName="EventSystem/Events/Void Event")]
public class VoidEvent : ScriptableObject
{
    public UnityAction OnEventRaised;

    public void raiseEvent()
    {
        if(OnEventRaised != null)
        {
            OnEventRaised.Invoke();
        }
    }
}
