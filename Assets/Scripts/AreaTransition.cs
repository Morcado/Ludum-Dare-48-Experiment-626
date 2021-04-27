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

    private BoxCollider2D transitions;

    // Start is called before the first frame update
    void Start()
    {
        _cameraFollow = Camera.main.GetComponent<CameraFollow>();
        player = GameObject.FindGameObjectWithTag("Player");
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
            }
            //transitions.enabled = false;
            _cameraFollow.transform.position = Vector3.Lerp(cameraStartPosition, cameraEndPosition, perc);
            //player.transform.position = Vector3.Lerp(playerStartPosition, playerEndPosition, perc);
        }
        else {
            //transitions.enabled = true;
            currentMoveTime = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") {

            cameraEndPosition = _cameraFollow.transform.position + new Vector3(directionX, directionY, -10.5f);
            cameraStartPosition = _cameraFollow.transform.position;

            playerEndPosition = other.transform.position + new Vector3(playerDirectionX, playerDirectionY, other.transform.position.z);
            playerStartPosition = other.transform.position;

            cameraIsMoving = true;
            //transitions.enabled = false;
            other.transform.position += new Vector3(playerDirectionX, playerDirectionY, other.transform.position.z);
        }
    }
}
