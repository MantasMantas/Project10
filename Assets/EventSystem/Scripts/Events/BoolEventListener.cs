using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// To use a generic UnityEvent type you must override the generic type.
/// </summary>

[System.Serializable]
public class BoolEventLs : UnityEvent<bool>
{

}

/// <summary>
/// A flexible handler for bool events in the form of a MonoBehaviour. Responses can be connected directly from the Unity Inspector.
/// </summary>

public class BoolEventListener : MonoBehaviour
{
    [Tooltip("Event to register")]
   public BoolEvent boolEvent;


   [Tooltip("Response when the event is raised")]
   public BoolEventLs OnEventRaised;

   private void OnEnable()
   {
       if(boolEvent != null)
       {
           boolEvent.OnEventRaised += respond;
       }
   }

   private void OnDisable()
   {
       if(boolEvent != null)
       {
           boolEvent.OnEventRaised -= respond;
       }
   }

   private void respond(bool value)
   {
       OnEventRaised.Invoke(value);
   }
}
