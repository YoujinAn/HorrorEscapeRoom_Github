using UnityEngine;
using Cinemachine;

[CreateAssetMenu(fileName = "Event Data", menuName = "ScriptableObject/Event")]
public class Event : ScriptableObject
{
    public int eventNum;
    public string[] dialogue;
}
