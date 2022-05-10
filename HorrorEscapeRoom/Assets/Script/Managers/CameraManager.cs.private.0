using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    #region singleton
    private static CameraManager instance = null;


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

    public static CameraManager Instance => instance == null ? null : instance;

    #endregion

    public CinemachineVirtualCamera virCam = null;
    public GameObject eventCam = null;

    public void CameraLocked(bool cameraLocked)
    {
        if(cameraLocked)
        {
            virCam.gameObject.SetActive(false);
        }
        else
        {
            virCam.gameObject.SetActive(true);
        }
    }
    public void EventCamOn()
    {
        eventCam.SetActive(true);
    }

    public void EventCamOff()
    {
        eventCam.SetActive(false);
    }
}
