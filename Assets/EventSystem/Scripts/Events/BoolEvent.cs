using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This class is used for Events that have one bool argument
/// </summary>

[CreateAssetMenu(fileName="New Bool Event", menuName="EventSystem/Events/Bool Event")]
public class BoolEvent : ScriptableObject
{
  public UnityAction<bool> OnEventRaised;

   public void raiseEvent(bool value)
   {
       if(OnEventRaised != null)
       {
           OnEventRaised.Invoke(value);
       }
   }
}
