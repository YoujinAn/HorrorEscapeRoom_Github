#pragma warning disable 0649
using UnityEngine;
using Sirenix.OdinInspector;

[System.Serializable]
public class DialogueLine
{
    // dialogue
    [BoxGroup("Dialogue")]
    [TextArea]
    public string[] dialogue;
}
