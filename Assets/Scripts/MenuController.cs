using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    public bool OpenPanel = false;

    public void ChangePanelStatus()
    {
        OpenPanel = !OpenPanel;
    }
}
