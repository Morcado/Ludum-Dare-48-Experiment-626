using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    private GameObject screenNote;
    private GameObject menuNote;

    private AudioSource noteSound;
    // Start is called before the first frame update
    void Start()
    {
        noteSound = GetComponent<AudioSource>();
        screenNote = GameObject.Find(name.Substring(0, 7));
        menuNote = GameObject.Find(name.Substring(0, 7) + "-menu");
        screenNote.SetActive(false);
        menuNote.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            noteSound.Play();
            screenNote.SetActive(true);
            menuNote.SetActive(true);

           
        }
    }

    private void OnTriggerExit2D(Collider2D collider){
        if (collider.tag == "Player")
        {
            screenNote.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
