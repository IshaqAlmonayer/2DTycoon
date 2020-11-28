using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapButton : MonoBehaviour
{

    public GameObject Panel;
    public MenuController MenuController;


    void OnMouseDown()
    {
        if (!MenuController.OpenPanel)
        {
            Panel.SetActive(true);
            MenuController.ChangePanelStatus();
        }
    }

}
