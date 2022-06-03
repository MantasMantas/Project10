using UnityEngine;

[CreateAssetMenu(fileName = "Conditions", menuName = "Scriptable Objects/Conditions")]
public class Conditions : ScriptableObject
{
    // Condition 0 - synchronized
    // Condition 1 - unsynchronized
    // Condition 2 - manipulated

    [Range(0,2)]
    private int index = 0;
    private int[] randomizedList;

    public int GetCondition() 
    {
        return randomizedList[index];
    }

    public void IncreamentIndex() 
    {
        index += 1;
    }

    public void Randomize()
    {
        index = 0;
        randomizedList = new int[]{0,1,2};
        Randomizer.Shuffle(randomizedList);

    }
    
}
