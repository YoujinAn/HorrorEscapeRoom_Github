using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event1 : MonoBehaviour
{
    public float curTime = 0;
    public float maxTime = 4;

    private bool bStart;

    private void OnEnable()
    {
        bStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(bStart)
        {
            curTime += Time.deltaTime;
            if (curTime > maxTime)
            {
                bStart = false;
                gameObject.SetActive(false);
                //GameManager.Instance.playerCanControl = true;
            }
        }
    }
}
