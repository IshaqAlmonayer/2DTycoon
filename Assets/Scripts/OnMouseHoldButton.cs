using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OnMouseHoldButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public GameObject Panel;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(this.gameObject.name + " Was Clicked.");
        Panel.SetActive(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log(this.gameObject.name + " Was Released.");
        Panel.SetActive(false);
    }
}
