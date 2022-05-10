using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Sirenix.OdinInspector;
using DG.Tweening;
using Cinemachine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private GameObject flashLight;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool runPlayer;
    private bool walkPlayer;
    private bool idlePlayer;
    private bool isFlashOn;
    private Animator anim;
    private RaycastHit hit;

    public Transform cameraTransform;

    private void Start()
    {

        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (GameManager.Instance.playerCanControl)
        {
            PlayerMoving();
            CameraManager.Instance.EventCamOff();
        }
        else
        {
            CameraManager.Instance.EventCamOn();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (GameManager.Instance.playerCanControl)
                GameManager.Instance.playerCanControl = false;
            else
                GameManager.Instance.playerCanControl = true;
        }
    }

    private void PlayerMoving()
    {
        // player y axis fix
        if (playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        if (InputManager.Instance.GetPlayerStatus() == PLAYERSTATUS.WALK)
        { 
            if (!walkPlayer)
            {
                playerSpeed = 2.0f;
                walkPlayer = true;
                idlePlayer = false;
                runPlayer = false;
                anim.SetInteger("Status", (int)InputManager.Instance.GetPlayerStatus());
            }
        }

        if (InputManager.Instance.GetPlayerStatus() == PLAYERSTATUS.RUN)
        {
            if (!runPlayer)
            {
                playerSpeed = 4.0f;
                anim.SetInteger("Status", (int)InputManager.Instance.GetPlayerStatus());
                walkPlayer = false;
                idlePlayer = false;
                runPlayer = true;
            }
        }

        if (InputManager.Instance.GetPlayerStatus() == PLAYERSTATUS.BACKWALK)
        {
            if (!walkPlayer)
            {
                playerSpeed = 1.0f;
                walkPlayer = true;
                idlePlayer = false;
                runPlayer = false;
                anim.SetInteger("Status", (int)InputManager.Instance.GetPlayerStatus());
            }
        }

        if(InputManager.Instance.GetPlayerStatus() == PLAYERSTATUS.IDLE)
        {
            if (!idlePlayer)
            {
                playerSpeed = 2.0f;
                idlePlayer = true;
                walkPlayer = false;
                runPlayer = false;
                anim.SetInteger("Status", (int)InputManager.Instance.GetPlayerStatus());
            }
        }

        if (InputManager.Instance.PlayerAction())
        {
            if(isFlashOn)
            {
                isFlashOn = false;
                flashLight.SetActive(false);
            }
            else
            {
                isFlashOn = true;
                flashLight.SetActive(true);
            }
        }

        Vector2 movement = InputManager.Instance.GetPlayerMovement();
        Vector3 move = new Vector3(movement.x, 0, movement.y);
        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        move.y = 0;

        gameObject.transform.rotation = new Quaternion(gameObject.transform.rotation.x, cameraTransform.rotation.y, 0, cameraTransform.transform.rotation.w);
        controller.Move(move * Time.deltaTime * playerSpeed);

        //playerVelocity.y += gravityValue * Time.deltaTime;
        //controller.Move(playerVelocity * Time.deltaTime);
    }
}
