using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanel : MonoBehaviour
{

    public UnityEngine.UI.Button Button;
    public MenuController MenuController;

    void Start()
    {
        Button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        MenuController.ChangePanelStatus();
    }
}
