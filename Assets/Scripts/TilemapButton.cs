using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapButton : MonoBehaviour
{

    public GameObject Panel;

    void OnMouseDown()
    {
        Panel.SetActive(true);
    }

}
