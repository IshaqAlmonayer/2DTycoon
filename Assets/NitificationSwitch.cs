using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NitificationSwitch : MonoBehaviour
{
    public Text NotificationText;
    private Animator animator;

    public void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void TriggerNotification(string text)
    {
        NotificationText.text = text;
        animator.SetTrigger("FadeIn");
    }


}
