using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PanelOpenCheckButton : MonoBehaviour
{
    public GameObject Panel;
    public MenuController MenuController;

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (!MenuController.OpenPanel)
        {
            Panel.SetActive(true);
            MenuController.ChangePanelStatus();
        }
    }
}
