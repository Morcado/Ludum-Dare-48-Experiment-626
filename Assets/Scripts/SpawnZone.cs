using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    private PlayerController _player;
    private CameraFollow _camera;
    [SerializeField] private Vector2 facingDirection = Vector2.zero;
    public string spawnName = "Name ID of my spawn zone";
    void Start()
    {
        _player = FindObjectOfType<PlayerController>();
        _camera = FindObjectOfType<CameraFollow>();

        if (!_player.nextPlaceName.Equals(spawnName)) return;   
        var position = this.transform.position;
        var transformCamera = _camera.transform;
        var transformPlayer = _player.transform;
        transformPlayer.position = new Vector3(position.x,position.y,transformPlayer.position.z);
        transformCamera.position = new Vector3(
            position.x,
            position.y,
            transformCamera.position.z
        );
        _player.lastMovement = facingDirection;
    }
}
