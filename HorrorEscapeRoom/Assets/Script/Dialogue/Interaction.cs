using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;

public enum AXIS
{
    XMOVE,
    YMOVE,
    ZMOVE
}
public enum INTERACTION
{
    ITEM,
    MOVE,
    ROTATION,
    TRIGGER
}

public class Interaction : MonoBehaviour
{
    [EnumPaging]
    public INTERACTION interType;
    public bool isConversation;
    [ShowIf("interType", INTERACTION.ITEM)]
    public Item item;
    [EnumPaging, ShowIf("interType", INTERACTION.MOVE)]
    public AXIS moveAxis;
    [ShowIf("interType", INTERACTION.MOVE)]
    public float moveDist;
    [ShowIf("interType", INTERACTION.MOVE)]
    public Transform moveTF;
    [ShowIf("interType", INTERACTION.ROTATION)]
    public Transform rotateTF;
    [ShowIf("interType", INTERACTION.ROTATION)]
    public float goalRotation;
    [ShowIf("interType", INTERACTION.TRIGGER)]
    public bool trigger;
    [ShowIf("isConversation", true)]
    public int convNum;

    public float time;

    private Transform moveOrigin;
    [SerializeField]
    private bool activeObj;

    private void Start()
    {
        moveOrigin = moveTF;
        activeObj = true;
    }

    void ReStartControl()
    {
        GameManager.Instance.playerCanControl = true;
    }

    public void StartItemEvent()
    {
        InventoryManager.Instance.AddItem(item);

        if (isConversation)
        {
            GameManager.Instance.playerCanControl = false;
            DialogueManager.Instance.StartConversation(convNum);
        }

        Destroy(gameObject);
    }

    public void StartRotationEvent()
    {
        GameManager.Instance.playerCanControl = false;

        if (activeObj)
        {
            rotateTF.DORotate(new Vector3(rotateTF.rotation.x, goalRotation, rotateTF.rotation.z), time);
            activeObj = false;
        }
        else
        {
            rotateTF.DORotate(new Vector3(rotateTF.rotation.x, 0, rotateTF.rotation.z), time);
            activeObj = true;
        }

        if (isConversation)
        {
            DialogueManager.Instance.StartConversation(convNum);
        }
        else
        {
            Invoke("ReStartControl", time);
        }
    }

    public void StartMoveEvent()
    {
        GameManager.Instance.playerCanControl = false;

        if (activeObj)
        {
            if(moveAxis == AXIS.XMOVE)
            {
                Debug.Log("move");
                activeObj = false;
                moveTF.DOMoveX(moveDist, time);
            }
            else if (moveAxis == AXIS.YMOVE)
            {
                Debug.Log("move");
                activeObj = false;
                moveTF.DOMoveY(moveDist, time);
            }
            if (moveAxis == AXIS.ZMOVE)
            {
                Debug.Log("move");
                activeObj = false;
                moveTF.DOMoveZ(moveDist, time);
            }
        }
        else
        {
            if (moveAxis == AXIS.XMOVE)
            {
                Debug.Log("minus move");
                activeObj = true;
                moveTF.DOMoveX(moveOrigin.position.x - moveDist, time);
            }
            else if (moveAxis == AXIS.YMOVE)
            {
                Debug.Log("minus move");
                activeObj = true;
                moveTF.DOMoveY(moveOrigin.position.y - moveDist, time);
            }
            if (moveAxis == AXIS.ZMOVE)
            {
                Debug.Log("minus move");
                activeObj = true;
                moveTF.DOMoveZ(moveOrigin.position.z - moveDist, time);
            }
        }

        if (isConversation)
        {
            DialogueManager.Instance.StartConversation(convNum);
        }
        else
        {
            Invoke("ReStartControl", time);
        }
    }
    public void StartTriggerEvent()
    {

        //GameManager.Instance.playerCanControl = false;

        //if (activeObj)
        //{
        //    closetTf.DORotate(new Vector3(deskTf.rotation.x, 0, deskTf.rotation.z), time);
        //    activeObj = false;
        //}
        //else
        //{
        //    closetTf.DORotate(new Vector3(deskTf.rotation.x, goalRotation, deskTf.rotation.z), time);
        //    activeObj = true;
        //}

        //if (isConversation)
        //{
        //    DialogueManager.Instance.StartConversation(convNum);
        //}
        //else
        //{
        //    Invoke("ReStartControl", time);
        //}
    }
}
