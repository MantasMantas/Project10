using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This class is used for Events that have one int argument
/// </summary>

[CreateAssetMenu(fileName="New Int Event", menuName="EventSystem/Events/Int Event")]
public class IntEvent : ScriptableObject
{
   public UnityAction<int> OnEventRaised;

   public void raiseEvent(int value)
   {
       if(OnEventRaised != null)
       {
           OnEventRaised.Invoke(value);
       }
   }

}
