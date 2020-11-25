using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadFirstScene : MonoBehaviour
{

    public UnityEngine.UI.Button Button;

    void Start()
    {
        Button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene(2);
    }
}
