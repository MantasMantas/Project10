using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This class is used for Events that have one string argument
/// </summary>

[CreateAssetMenu(fileName="New String Event", menuName="EventSystem/Events/String Event")]
public class StringEvent : ScriptableObject
{
  public UnityAction<string> OnEventRaised;

   public void raiseEvent(string value)
   {
       if(OnEventRaised != null)
       {
           OnEventRaised.Invoke(value);
       }
   }
}
