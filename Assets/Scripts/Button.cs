using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    public GameObject Panel;

    void OnMouseDown()
    {
        Panel.SetActive(true);
    }

}
