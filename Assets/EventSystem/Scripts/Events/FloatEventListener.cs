using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// To use a generic UnityEvent type you must override the generic type.
/// </summary>

[System.Serializable]
public class FloatEventLs : UnityEvent<float>
{

}

/// <summary>
/// A flexible handler for float events in the form of a MonoBehaviour. Responses can be connected directly from the Unity Inspector.
/// </summary>

public class FloatEventListener : MonoBehaviour
{
  [Tooltip("Event to register")]
   public FloatEvent floatEvent;


   [Tooltip("Response when the event is raised")]
   public FloatEventLs OnEventRaised;

   private void OnEnable()
   {
       if(floatEvent != null)
       {
           floatEvent.OnEventRaised += respond;
       }
   }

   private void OnDisable()
   {
       if(floatEvent != null)
       {
           floatEvent.OnEventRaised -= respond;
       }
   }

   private void respond(float value)
   {
       OnEventRaised.Invoke(value);
   }
}
