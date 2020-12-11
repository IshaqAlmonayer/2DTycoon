using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;



public class LoadSceneButton : MonoBehaviour
{
    public Animator transition;
    public UnityEngine.UI.Button Button;
    public int sceneNo;
    private float waitTime = 1f;

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
                    StartCoroutine(LoadLevel(2));
                }
                else
                {
                    //Load Tutorial
                    StartCoroutine(LoadLevel(1));
                }
                break;
            case 2:
                //Load first map
                StartCoroutine(LoadLevel(2));
                break;
            case 3:
                //load second map
                StartCoroutine(LoadLevel(3));
                break;
            case 4:
                //load second map
                StartCoroutine(LoadLevel(4));
                break;
        }
    }

    IEnumerator LoadLevel(int SceneNumber)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene(SceneNumber);
    }

}
