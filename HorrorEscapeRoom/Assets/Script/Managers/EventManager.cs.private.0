using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    #region singleton
    private static EventManager instance = null;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static EventManager Instance => instance == null ? null : instance;

    #endregion

    public int eventNum = 0;
    public List<Event> eventList = new List<Event>();

    public void EventStart(int evNum)
    {
        GameManager.Instance.playerCanControl = false;
        CameraManager.Instance.EventCamOn();
    }
}
