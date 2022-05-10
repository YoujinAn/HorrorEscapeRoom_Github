using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform PlayerObj;
    private bool moveR;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerObj.position = new Vector3(PlayerObj.position.x, PlayerObj.position.y + 1.4f, PlayerObj.position.z);

        if (InputManager.Instance.GetPlayerStatus() == PLAYERSTATUS.WALK)
        {
            CameraWalkMove();
        }
        else
        {
            transform.DOMove(new Vector3(PlayerObj.position.x, PlayerObj.position.y, PlayerObj.position.z), 0.1f);
        }

        if(transform.position.x < -0.29f)
        {
            moveR = false;
        }
        else if (transform.position.x > 0.29f)
        {
            moveR = true;
        }
    }

    private void CameraWalkMove()
    {
        if (moveR)
        {
            transform.DOMove(new Vector3(PlayerObj.position.x - 0.3f, PlayerObj.position.y + 0.1f, PlayerObj.position.z), 1.0f);
        }
        else
        {
            transform.DOMove(new Vector3(PlayerObj.position.x + 0.3f, PlayerObj.position.y + 0.1f, PlayerObj.position.z), 1.0f);
        }
    }
}
