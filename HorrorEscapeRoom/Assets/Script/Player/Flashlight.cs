using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Flashlight : MonoBehaviour
{
    [SerializeField]
    private float blinkTimer;
    [SerializeField]
    private float stuckTimer = 0.2f;
    [SerializeField]
    private float curTime;
    [SerializeField]
    private float minTime = 3;
    [SerializeField]
    private float maxTime = 10;

    public bool flashOn;

    private Light light;

    void Start()
    {
        flashOn = true;
        light = GetComponent<Light>();
    }

    void Update()
    {
        if (GameManager.Instance.playerCanControl)
        {
            if (flashOn)
            {
                light.enabled = true;
                curTime += Time.deltaTime;
                if (curTime > blinkTimer)
                {
                    flashOn = false;
                    curTime = 0;
                    blinkTimer = Random.Range(minTime, maxTime);
                }
            }
            else
            {
                light.enabled = false;
                curTime += Time.deltaTime;
                if (curTime > stuckTimer)
                {
                    flashOn = true;
                    curTime = 0;
                }
            }

            var pov = CameraManager.Instance.virCam.GetCinemachineComponent<CinemachinePOV>();
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(pov.m_VerticalAxis.Value, pov.m_HorizontalAxis.Value, 0));
        }
    }
}
