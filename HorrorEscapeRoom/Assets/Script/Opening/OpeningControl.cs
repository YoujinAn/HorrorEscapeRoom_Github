using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningControl : MonoBehaviour
{
    public GameObject playerObj;
    public GameObject virCam;
    public GameObject virStopCam;
    public float curTime = 0;
    public float maxTime = 5;

    private bool bStart;

    private void Start()
    {
        bStart = true;
        GameManager.Instance.playerCanControl = false;
        playerObj.SetActive(false);
        virCam.SetActive(false);
        virStopCam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (bStart)
        {
            curTime += Time.deltaTime;
            if (curTime > maxTime)
            {
                bStart = false;
                virCam.SetActive(true);
                virStopCam.SetActive(true);
                GameManager.Instance.playerCanControl = true;
                playerObj.SetActive(true);
            }
        }
    }
}
