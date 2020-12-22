using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioOnOff : MonoBehaviour
{
    public AudioSource music;
    public GameObject OnButton;
    public GameObject OffButton;

    public bool musicStatus;

    private void Start()
    {
        if (musicStatus)
        {
            music.Stop();
        }
        else {
            music.Play();
        }
    }

    private void Update()
    {
        Debug.Log("musicStatus: " + musicStatus);
        if (musicStatus)
        {
            OnButton.SetActive(false);
            OffButton.SetActive(true);
            OffButton.GetComponent<Button>().onClick.AddListener(TaskOnClickOff);
        }
        else
        {
            OnButton.SetActive(true);
            OffButton.SetActive(false);
            OnButton.GetComponent<Button>().onClick.AddListener(TaskOnClickOn);
        }
    }

    void TaskOnClickOn()
    {
        music.Stop();
        musicStatus = true;
    }

    void TaskOnClickOff()
    {
        music.Play();
        musicStatus = false;
    }

    //public bool getMusicStatus() {
    //    return musicStatus;
    //}

    //public void setMusicStatus(bool musicStatus)
    //{
    //    this.musicStatus = musicStatus;
    //}
}







