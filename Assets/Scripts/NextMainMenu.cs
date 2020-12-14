using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextMainMenu : MonoBehaviour
{
    public Animator MenuAnimator;
    public Animator StartButtonAnimator;
    public bool direction;
    public MainMenuController MainMenuController;
    

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("position: " + MainMenuController.GetComponent<MainMenuController>().position);
        if (direction)
        {
            if (MainMenuController.GetComponent<MainMenuController>().position < 2)
            {
                MenuAnimator.SetTrigger("MoveRight");
                StartButtonAnimator.SetTrigger("MoveRight");
                MainMenuController.GetComponent<MainMenuController>().position++;
            }
        }
        else
        {
            if (MainMenuController.GetComponent<MainMenuController>().position > 0)
            {
                MenuAnimator.SetTrigger("MoveLeft");
                StartButtonAnimator.SetTrigger("MoveLeft");
                MainMenuController.GetComponent<MainMenuController>().position--;
            }
        }
    }
}
