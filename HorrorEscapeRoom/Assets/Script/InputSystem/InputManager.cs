using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PLAYERSTATUS
{
    IDLE,
    WALK,
    RUN,
    BACKWALK,
    ACTION,
}

public class InputManager : MonoBehaviour
{
    private PlayerControls playerControls;
    private bool isWalking;
    private bool isBackWalking;
    private bool isRunning;
    private PLAYERSTATUS playerStatus;

    #region singleton
    private static InputManager instance = null;


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

        playerControls = new PlayerControls();
    }

    public static InputManager Instance => instance == null ? null : instance;

    #endregion

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        GetPlayerStatus();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public Vector2 GetPlayerMovement()
    {
        return playerControls.Player.Movement.ReadValue<Vector2>();
    }

    public Vector2 GetMouseDelta()
    {
        return playerControls.Player.Look.ReadValue<Vector2>();
    }

    public bool PlayerRunning()
    {

        return playerControls.Player.Run.IsPressed();
    }

    public bool PlayerAction()
    {
        return playerControls.Player.Action.triggered;
    }

    public PLAYERSTATUS GetPlayerStatus()
    {
        if (GetPlayerMovement().x > 0 || GetPlayerMovement().y > 0)
        {
            if (!PlayerRunning())
            {
                playerStatus = PLAYERSTATUS.WALK;
            }
            else
            {
                playerStatus = PLAYERSTATUS.RUN;
            }
        }
        else if (GetPlayerMovement().x < 0 || GetPlayerMovement().y < 0)
        {
            playerStatus = PLAYERSTATUS.BACKWALK;
        }
        else
        {
            playerStatus = PLAYERSTATUS.IDLE;
        }

        return playerStatus;
    }
}
