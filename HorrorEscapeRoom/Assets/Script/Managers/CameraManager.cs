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
    public CinemachineVirtualCamera virStopCam = null;
    public GameObject eventCam = null;


    private void Start()
    {
        
    }

    private void Update()
    {
        if(!GameManager.Instance.playerCanControl)
        {
            virStopCam = virCam;
            virStopCam.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_MaxSpeed = 0;
            virStopCam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = 0;
            virStopCam.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.Value = virCam.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.Value;
            virStopCam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.Value = virCam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.Value;
            virStopCam.Priority = 30;
        }
        else
        {
            //virCam = virStopCam;
            virCam.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_MaxSpeed = 300;
            virCam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = 300;
            virStopCam.Priority = 10;
        }
    }

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
