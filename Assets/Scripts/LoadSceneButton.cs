using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;



public class LoadSceneButton : MonoBehaviour
{

    public UnityEngine.UI.Button Button;
    public int sceneNo;

    void Start()
    {
        Button.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {
        switch (sceneNo)
        {
            case 1:
                string path = Application.persistentDataPath + "/GameDataMap1.lol";
                if (File.Exists(path))
                {
                    //Load first map
                    SceneManager.LoadScene(2);
                }
                else
                {
                    //Load Tutorial
                    SceneManager.LoadScene(1);
                }
                break;
            case 2:
                //Load first map
                SceneManager.LoadScene(2);
                break;
            case 3:
                //load second map
                SceneManager.LoadScene(3);
                break;
        }
       
            

    }
}
