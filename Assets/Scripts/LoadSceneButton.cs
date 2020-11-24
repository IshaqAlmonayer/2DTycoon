using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;



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

        //string path = Application.persistentDataPath + "/GameData.lol";
        //if (File.Exists(path))
        //{
        //    //Load Game
        //    SceneManager.LoadScene(2);
        //}
        //else
        //{
        //    //Load Tutorial
        //    SceneManager.LoadScene(1);
    //}

}

}
