using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 minPosition;
    public Vector3 maxPosition;
    /*
    [SerializeField] private GameObject followTarget;
    [SerializeField] private Vector3 targetPosition;
    [SerializeField] private float  cameraSpeed = 4.0f;*/
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
    }
/*
    void FollowTarget()
    {
        var position = this.transform.position;
        var positionTarget = followTarget.transform.position;
        targetPosition = new Vector3(positionTarget.x, positionTarget.y,
            position.z);
        position = Vector3.Lerp(position, targetPosition, cameraSpeed * Time.deltaTime);
        this.transform.position = position;
    }*/
}
