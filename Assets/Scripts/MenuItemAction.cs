using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuItemAction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private GameObject ScreenNote;

    // Start is called before the first frame update
    void Start()
    {
        ScreenNote = GameObject.Find(gameObject.name.Substring(0, 7));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        ScreenNote.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        ScreenNote.SetActive(false);
    }
}
