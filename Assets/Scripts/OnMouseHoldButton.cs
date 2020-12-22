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
        Panel.SetActive(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Panel.SetActive(false);
    }
}
