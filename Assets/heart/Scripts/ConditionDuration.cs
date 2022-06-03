using UnityEngine;

[CreateAssetMenu(fileName = "ConditionDuration", menuName = "Scriptable Objects/Condition Duration")]
public class ConditionDuration : ScriptableObject
{
    [Range(0, 300)]
    public float duration;
}
