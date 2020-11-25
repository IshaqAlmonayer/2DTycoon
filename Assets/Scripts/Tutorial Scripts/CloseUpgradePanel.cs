using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseUpgradePanel : MonoBehaviour
{
    public GameObject panel;

    private void OnMouseDown()
    {
        panel.SetActive(false);
    }
}
