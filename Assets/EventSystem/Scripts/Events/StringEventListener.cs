using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// To use a generic UnityEvent type you must override the generic type.
/// </summary>

[System.Serializable]
public class StringEventLs : UnityEvent<string>
{

}

/// <summary>
/// A flexible handler for string events in the form of a MonoBehaviour. Responses can be connected directly from the Unity Inspector.
/// </summary>

public class StringEventListener : MonoBehaviour
{
   [Tooltip("Event to register")]
   public StringEvent stringEvent;


   [Tooltip("Response when the event is raised")]
   public StringEventLs OnEventRaised;

   private void OnEnable()
   {
       if(stringEvent != null)
       {
           stringEvent.OnEventRaised += respond;
       }
   }

   private void OnDisable()
   {
       if(stringEvent != null)
       {
           stringEvent.OnEventRaised -= respond;
       }
   }

   private void respond(string value)
   {
       OnEventRaised.Invoke(value);
   }

}
