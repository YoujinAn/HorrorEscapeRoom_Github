using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
public enum INTERACTION
{
    ROTATE,
    Move,
    TRIGGER,
    ITEM
}
public enum MOVEAXIS
{
    XMOVE,
    YMOVE,
    ZMOVE
}
public class Interaction : MonoBehaviour
{
    [EnumPaging]
    public INTERACTION interType;
    public bool isConversation;
    [ShowIf("interType", INTERACTION.ROTATE)]
    public Transform rotateTf;
    [ShowIf("interType", INTERACTION.Move)]
    public Transform moveTf;
    [ShowIf("interType", INTERACTION.Move)]
    public MOVEAXIS moveAxis;
    [ShowIf("interType", INTERACTION.TRIGGER)]
    public int triggerIdx;
    [ShowIf("interType", INTERACTION.ITEM)]
    public Item item;
    [ShowIf("isConversation", true)]
    public int convNum;

    public float moveGoal;
    public float time;

    private bool activeObj;

    void OnTriggerStay(Collider other)
    {

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

    public void StartRotateEvent()
    {
        GameManager.Instance.playerCanControl = false;

        if (activeObj)
        {
            rotateTf.DORotate(new Vector3(rotateTf.rotation.x, 0, rotateTf.rotation.z), time);
            activeObj = false;
        }
        else
        {
            rotateTf.DORotate(new Vector3(rotateTf.rotation.x, moveGoal, rotateTf.rotation.z), time);
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
            if(moveAxis == MOVEAXIS.XMOVE)
            {
                moveTf.DOMoveX(moveTf.position.x + moveGoal, time);
            }
            else if (moveAxis == MOVEAXIS.YMOVE)
            {
                moveTf.DOMoveY(moveTf.position.y + moveGoal, time);
            }
            else
            {
                moveTf.DOMoveZ(moveTf.position.z + moveGoal, time);
            }
            activeObj = false;
            GameManager.Instance.playerCanControl = false;
            Invoke("ReStartControl", time);
        }
        else
        {
            if (moveAxis == MOVEAXIS.XMOVE)
            {
                moveTf.DOMoveX(moveTf.position.x - moveGoal, time);
            }
            else if (moveAxis == MOVEAXIS.YMOVE)
            {
                moveTf.DOMoveY(moveTf.position.y - moveGoal, time);
            }
            else
            {
                moveTf.DOMoveZ(moveTf.position.z - moveGoal, time);
            }
            activeObj = true;
            GameManager.Instance.playerCanControl = false;
            Invoke("ReStartControl", time);
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

        GameManager.Instance.playerCanControl = false;

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

        if (isConversation)
        {
            DialogueManager.Instance.StartConversation(convNum);
        }
        else
        {
            Invoke("ReStartControl", time);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;

public class Interaction : MonoBehaviour
{
    [EnumPaging]
    public INTERACTION interType;
    public bool isConversation;
    [ShowIf("interType", INTERACTION.DOOR)]
    public Transform doorTf;
    [ShowIf("interType", INTERACTION.CLOSET)]
    public Transform closetTf;
    [ShowIf("interType", INTERACTION.DESK)]
    public Transform deskTf;
    [ShowIf("interType", INTERACTION.ITEM)]
    public Item item;
    [ShowIf("isConversation", true)]
    public int convNum;

    public float goalRotation;
    public float time;

    private bool activeObj;

    void OnTriggerStay(Collider other)
    {
       
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

    public void StartDoorEvent()
    {
        GameManager.Instance.playerCanControl = false;

        if (activeObj)
        {
            doorTf.DORotate(new Vector3(doorTf.rotation.x, 0, doorTf.rotation.z), time);
            activeObj = false;
        }
        else
        {
            doorTf.DORotate(new Vector3(doorTf.rotation.x, goalRotation, doorTf.rotation.z), time);
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

    public void StartClosetEvent()
    {
        Debug.Log("Closet");
        GameManager.Instance.playerCanControl = false;

        if (activeObj)
        {
            closetTf.DORotate(new Vector3(closetTf.rotation.x, 0, closetTf.rotation.z), time);
            activeObj = false;
        }
        else
        {
            closetTf.DORotate(new Vector3(closetTf.rotation.x, goalRotation, closetTf.rotation.z), time);
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
    public void StartDeskEvent()
    {

        GameManager.Instance.playerCanControl = false;

        if (activeObj)
        {
            closetTf.DORotate(new Vector3(deskTf.rotation.x, 0, deskTf.rotation.z), time);
            activeObj = false;
        }
        else
        {
            closetTf.DORotate(new Vector3(deskTf.rotation.x, goalRotation, deskTf.rotation.z), time);
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
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;

public class Interaction : MonoBehaviour
{
    [EnumPaging]
    public INTERACTION interType;
    public bool isConversation;
    [ShowIf("interType", INTERACTION.DOOR)]
    public Transform doorTf;
    [ShowIf("interType", INTERACTION.CLOSET)]
    public Transform closetTf;
    [ShowIf("interType", INTERACTION.DESK)]
    public Transform deskTf;
    [ShowIf("interType", INTERACTION.ITEM)]
    public Item item;
    [ShowIf("isConversation", true)]
    public int convNum;

    public float goalRotation;
    public float time;

    private bool activeObj;

    void OnTriggerStay(Collider other)
    {
       
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

    public void StartDoorEvent()
    {
        GameManager.Instance.playerCanControl = false;

        if (activeObj)
        {
            doorTf.DORotate(new Vector3(doorTf.rotation.x, 0, doorTf.rotation.z), time);
            activeObj = false;
        }
        else
        {
            doorTf.DORotate(new Vector3(doorTf.rotation.x, goalRotation, doorTf.rotation.z), time);
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

    public void StartClosetEvent()
    {
        Debug.Log("Closet");
        GameManager.Instance.playerCanControl = false;

        if (activeObj)
        {
            closetTf.DORotate(new Vector3(closetTf.rotation.x, 0, closetTf.rotation.z), time);
            activeObj = false;
        }
        else
        {
            closetTf.DORotate(new Vector3(closetTf.rotation.x, goalRotation, closetTf.rotation.z), time);
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
    public void StartDeskEvent()
    {

        GameManager.Instance.playerCanControl = false;

        if (activeObj)
        {
            closetTf.DORotate(new Vector3(deskTf.rotation.x, 0, deskTf.rotation.z), time);
            activeObj = false;
        }
        else
        {
            closetTf.DORotate(new Vector3(deskTf.rotation.x, goalRotation, deskTf.rotation.z), time);
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
}
