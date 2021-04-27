using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FinalNote : MonoBehaviour
{
    // Start is called before the first frame update
    private TilemapCollider2D exitMap;
    private TilemapRenderer exitMapRenderer;

    private Animator _doorAnimator;
    // Start is called before the first frame update
    void Start()
    {
        _doorAnimator = GameObject.FindGameObjectWithTag("Exit Door").GetComponent<Animator>();
        exitMap = GameObject.FindGameObjectWithTag("Exit Tilemap").GetComponent<TilemapCollider2D>();  
        exitMapRenderer = GameObject.FindGameObjectWithTag("Exit Tilemap").GetComponent<TilemapRenderer>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            exitMapRenderer.enabled = false;
            exitMap.enabled = false;
            _doorAnimator.SetBool("exit", true);
        }
    }

}
