    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTransition : MonoBehaviour
{
    private CameraFollow _cameraFollow;
    public float directionX;
    public float directionY;
    public float playerDirectionX;
    public float playerDirectionY;
    private float moveTime = 0.6f;
    private bool cameraIsMoving = false;
    private float currentMoveTime;
    private Vector3 cameraEndPosition;
    private Vector3 cameraStartPosition;
    private Vector3 playerEndPosition;
    private Vector3 playerStartPosition;
    private GameObject player;
    private PlayerController playerController;

    private BoxCollider2D transitions;

    // Start is called before the first frame update
    void Start()
    {
        _cameraFollow = Camera.main.GetComponent<CameraFollow>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        transitions = GameObject.Find("Transitions").GetComponentInChildren<BoxCollider2D>();
    }
    
    void Update()
    {
        if (cameraIsMoving)
        {
            currentMoveTime += Time.deltaTime;
            float perc = currentMoveTime / moveTime; //express as percentage (0 to 1)
             
             //check: is timer complete?
            if (currentMoveTime > moveTime) {
                perc = 1f;
                cameraIsMoving = false;
                playerController.speed = 300f;
            }
            _cameraFollow.transform.position = Vector3.Lerp(cameraStartPosition, cameraEndPosition, perc);
        }
        else {
            currentMoveTime = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") {
            cameraIsMoving = true;
            cameraStartPosition = _cameraFollow.transform.position;
            playerController.speed = 0;

            if (playerController.lastMovement.y == 0 || name.Contains("LeftRight"))    // y = 0
            {
                if (playerController.lastMovement.x == 1)    // x = 1
                {
                    cameraEndPosition = _cameraFollow.transform.position + new Vector3(directionX, 0, 0);
                    other.transform.position += new Vector3(playerDirectionX, 0, 0);
                }
                else    // x = -1
                {
                    cameraEndPosition = _cameraFollow.transform.position + new Vector3(-directionX, 0, 0);
                    other.transform.position += new Vector3(-playerDirectionX, 0, 0);
                }
            }
            else  // y = 1 o -1
            {
                if (playerController.lastMovement.x == 0 || name.Contains("TopDown"))
                {
                    if (playerController.lastMovement.y == 1) // y = 1   
                    {

                        cameraEndPosition = _cameraFollow.transform.position + new Vector3(0, directionY, 0);
                        other.transform.position += new Vector3(0, playerDirectionY, 0);
                    }
                    else // y = -1
                    {
                        cameraEndPosition = _cameraFollow.transform.position + new Vector3(0, -directionY, 0);
                        other.transform.position += new Vector3(0, -playerDirectionY, 0);
                    }
                }
            }
        }
    }
}
