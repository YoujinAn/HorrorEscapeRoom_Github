#pragma warning disable 0649
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "New conversation", menuName = "Dialogue/New Conversation")]
public class Conversation : ScriptableObject
{
    public int convNum;
    public DialogueLine[] allLines;

    public DialogueLine GetLineByIndex(int index)
    {
        return allLines[index];
    }

    public int GetLength()
    {
        return allLines.Length - 1;
    }
}
