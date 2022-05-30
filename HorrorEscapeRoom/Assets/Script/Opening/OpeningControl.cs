using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class OpeningControl : MonoBehaviour
{
    public GameObject playerObj;
    public GameObject virCam;
    public GameObject virStopCam;
    public GameObject eventCam;
    public float curTime = 0;
    public float maxTime = 5;
    public Image screenImage;
    public CinemachineDollyCart dollyCart;

    public bool bStart;
    public bool bOpeningStart;
    public float alpha;

    private void Start()
    {
        GameManager.Instance.playerCanControl = false;
        playerObj.SetActive(false);
        virCam.SetActive(false);
        virStopCam.SetActive(false);
        alpha = 1;
        DialogueManager.Instance.StartConversation(3);
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueManager.Instance.convs[3].isEnd)
        {
            bOpeningStart = true;
        }

        if (bStart)
        {
            curTime += Time.deltaTime;
            if (curTime > maxTime)
            {
                bStart = false;
                virCam.SetActive(true);
                virStopCam.SetActive(false);
                eventCam.SetActive(false);
                GameManager.Instance.playerCanControl = true;
                playerObj.SetActive(true);
            }
        }

        if (bOpeningStart)
        {
            if (screenImage.color.a > 0)
            {
                alpha -= (Time.deltaTime / 5);
                screenImage.color = new Color(1, 1, 1, alpha);
            }
            else
            {
                screenImage.enabled = false;
                bStart = true;
                dollyCart.m_Speed = 1;
            }
        }
    }
}
