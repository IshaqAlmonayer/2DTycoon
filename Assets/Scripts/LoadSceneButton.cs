using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LoadSceneButton : MonoBehaviour
{

    public UnityEngine.UI.Button Button;

    void Start()
    {
        Button.onClick.AddListener(TaskOnClick);
    }


    public void TaskOnClick()
    {
        SceneManager.LoadScene(1);
    }

}
