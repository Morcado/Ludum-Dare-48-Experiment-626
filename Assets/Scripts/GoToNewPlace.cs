using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoToNewPlace : MonoBehaviour
{
    [SerializeField] private string newPlaceName = "New Scene name here";
    public string goToPlaceName = "Name of the spawn point that i should go";
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        FindObjectOfType<PlayerController>().nextPlaceName = goToPlaceName;
        SceneManager.LoadScene(newPlaceName);
    }
}
