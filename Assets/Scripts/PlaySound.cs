using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    AudioSource[] footsteps;

    // Start is called before the first frame update
    void Start()
    {
        footsteps = GameObject.Find("Player").GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlayFootstepSound() 
    {
        footsteps[0].Play();
    }

    private void PlayFootstepSound2() 
    {
        footsteps[1].Play();
    }
}
