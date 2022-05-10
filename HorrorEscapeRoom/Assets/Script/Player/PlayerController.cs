using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 5.0f;
    [SerializeField]
    private GameObject flashLight;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool runPlayer;
    private bool walkPlayer;
    private bool idlePlayer;
    private bool isFlashOn;
    private Animator anim;
    //private RaycastHit hit;
    
    public Transform cameraTransform;

    // boxcast var
    float m_MaxDistance;
    bool m_HitDetect;
    RaycastHit m_Hit;

    private void Start()
    {

        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

        //Choose the distance the Box can reach to
        m_MaxDistance = 1.5f;
    }
    private void FixedUpdate()
    {
        //Test to see if there is a hit using a BoxCast
        //Calculate using the center of the GameObject's Collider(could also just use the GameObject's position), half the GameObject's size, the direction, the GameObject's rotation, and the maximum distance as variables.
        //Also fetch the hit data
        m_HitDetect = Physics.BoxCast(CameraManager.Instance.virCam.transform.position, transform.localScale / 5, cameraTransform.forward, out m_Hit, transform.rotation, m_MaxDistance);

        //Output the name of the Collider your Box hit
        //Debug.Log("Hit : " + m_Hit.collider.name);

        if (m_HitDetect)
        {
            if (m_Hit.transform.CompareTag("Item") && Input.GetKeyDown(KeyCode.C))
            {
                m_Hit.transform.GetComponent<Interaction>().StartItemEvent();
            }

            if (m_Hit.transform.CompareTag("Closet") && Input.GetKeyDown(KeyCode.C))
            {
                m_Hit.transform.GetComponent<Interaction>().StartClosetEvent();
            }

            if (m_Hit.transform.CompareTag("Door") && Input.GetKeyDown(KeyCode.C))
            {
                m_Hit.transform.GetComponent<Interaction>().StartDoorEvent();
            }


            if (m_Hit.transform.CompareTag("Desk") && Input.GetKeyDown(KeyCode.C))
            {
                m_Hit.transform.GetComponent<Interaction>().StartDeskEvent();
            }
        }
    }
    private void Update()
    {
        if (GameManager.Instance.playerCanControl)
        {
            PlayerMoving();
        }
        else
        {

        }

        //if (Physics.Raycast(transform.position, transform.forward, out hit)) 
        //{ 
        //    Debug.DrawRay(CameraManager.Instance.virCam.transform.position,
        //        cameraTransform.forward * hit.distance, Color.blue);
        //} 
        //else 
        //{
        //    Debug.DrawRay(CameraManager.Instance.virCam.transform.position,
        //        cameraTransform.forward * hit.distance, Color.blue);
        //}

        //if (hit.collider != null)
        //{ 
        //    Debug.Log(hit.collider.name);
        //}
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

        if (Input.GetKeyDown(KeyCode.L))
        {
            if (isFlashOn)
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

        if (Input.GetKeyDown(KeyCode.I))
        {
            

        }

            Vector2 movement = InputManager.Instance.GetPlayerMovement();
        Vector3 move = new Vector3(movement.x, 0, movement.y);
        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        move.y = 0;

        gameObject.transform.rotation = new Quaternion(gameObject.transform.rotation.x, cameraTransform.rotation.y, 0, cameraTransform.transform.rotation.w);
        controller.Move(move * Time.deltaTime * playerSpeed);
    }

    private void OnTriggerStay(Collider other)
    {
        //if (m_HitDetect)
        //{
        //    if (m_Hit.transform.CompareTag("Item") && Input.GetKeyDown(KeyCode.C))
        //    {
        //        Debug.Log("Item Raycast");
        //        InventoryManager.Instance.AddItem(other.GetComponent<Interaction>().item);

        //        if (other.GetComponent<Interaction>().isConversation)
        //        {
        //            GameManager.Instance.playerCanControl = false;
        //            DialogueManager.Instance.StartConversation(other.GetComponent<Interaction>().convNum);
        //        }
        //        Destroy(other.gameObject);
        //    }
        //}
    }

    //Draw the BoxCast as a gizmo to show where it currently is testing. Click the Gizmos button to see this
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        //Check if there has been a hit yet
        if (m_HitDetect)
        {
            //Draw a Ray forward from GameObject toward the hit
            Gizmos.DrawRay(CameraManager.Instance.virCam.transform.position, cameraTransform.forward * m_Hit.distance);
            //Draw a cube that extends to where the hit exists
            Gizmos.DrawWireCube(CameraManager.Instance.virCam.transform.position + cameraTransform.forward * m_Hit.distance, transform.localScale / 5);
        }
        //If there hasn't been a hit yet, draw the ray at the maximum distance
        else
        {
            
        }
    }
}
