using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A flexible handler for void events in the form of a MonoBehaviour. Responses can be connected directly from the Unity Inspector.
/// </summary>

public class VoidEventListener : MonoBehaviour
{
   [Tooltip("Event to register")]
   public VoidEvent voidEvent;

   [Tooltip("Response when the event is raised")]
   public UnityEvent OnEventRaised;

   private void OnEnable()
   {
       if(voidEvent != null)
       {
           voidEvent.OnEventRaised += respond;
       }
   }

   private void OnDisable()
   {
       if(voidEvent != null)
       {
           voidEvent.OnEventRaised -= respond;
       }
   }

   private void respond()
   {
       OnEventRaised.Invoke();
   }
}
