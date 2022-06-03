using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// To use a generic UnityEvent type you must override the generic type.
/// </summary>

[System.Serializable]
public class IntEventLs : UnityEvent<int>
{

}

/// <summary>
/// A flexible handler for int events in the form of a MonoBehaviour. Responses can be connected directly from the Unity Inspector.
/// </summary>

public class IntEventListener : MonoBehaviour
{
[Tooltip("Event to register")]
   public IntEvent intEvent;


   [Tooltip("Response when the event is raised")]
   public IntEventLs OnEventRaised;

   private void OnEnable()
   {
       if(intEvent != null)
       {
           intEvent.OnEventRaised += respond;
       }
   }

   private void OnDisable()
   {
       if(intEvent != null)
       {
           intEvent.OnEventRaised -= respond;
       }
   }

   private void respond(int value)
   {
       OnEventRaised.Invoke(value);
   }

}
