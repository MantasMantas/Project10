using UnityEngine;

[CreateAssetMenu(fileName ="FileName", menuName = "Scriptable Objects/File Name")]
public class FileName : ScriptableObject
{
    [TextArea]
    public string textHint;

    public string fileName;
    public int number = 1;

    public string Get() 
    {
        return fileName + "_" +number.ToString();
    }

    public void increment()
    {
        number += 1;
    }
}
