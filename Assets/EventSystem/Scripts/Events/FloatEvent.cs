using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This class is used for Events that have one float argument
/// </summary>

[CreateAssetMenu(fileName="New Float Event", menuName="EventSystem/Events/Float Event")]
public class FloatEvent : ScriptableObject
{
   public UnityAction<float> OnEventRaised;

   public void raiseEvent(float value)
   {
       if(OnEventRaised != null)
       {
           OnEventRaised.Invoke(value);
       }
   }
}
