using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdvertiseButton : MonoBehaviour
{
    public CustomerSpawner[] Spawners;
    private int _activeSpawnersCount;
    public string AdType;
    public Button button;
    public GameObject[] AllAdButtons;
    public float adDuration;
    public GameObject addController;
    public float adPrice;
    public Money money;
    public Text currentRunningAdText;
    public Text customerMultiplierText;
    public Text timerText;
    private float _timer;

    void Start()
    {
        button.onClick.AddListener(TaskOnClick);

        foreach (CustomerSpawner spawner in Spawners)
        {
            if(spawner.GetComponent<CustomerSpawner>().isActive)
                _activeSpawnersCount++;
        }

        switch (_activeSpawnersCount)
        {
            case 1:
                currentRunningAdText.text = "Current Runnning Add: Good Advertisement";
                customerMultiplierText.text = "Customer Multiplier: x2";
                break;
            case 2:
                currentRunningAdText.text = "Current Runnning Add: Better Advertisement";
                customerMultiplierText.text = "Customer Multiplier: x3";
                break;
            case 3:
                currentRunningAdText.text = "Current Runnning Add: Best Advertisement";
                customerMultiplierText.text = "Customer Multiplier: x4";
                break;
        }

        _activeSpawnersCount = 0;
    }

    void Update()
    {
        if (_timer > 0)
            _timer -= Time.deltaTime;

        _timer = addController.GetComponent<AdvertiseController>().AddTimer;


        if (addController.GetComponent<AdvertiseController>().AddTimer <= 0)
        {
            currentRunningAdText.text = "Current Runnning Add: None";
            customerMultiplierText.text = "Customer Multiplier: x1";
            timerText.text = "Time Left for add: " + 0;
            foreach (GameObject button in AllAdButtons)
            if (money._totalMoney >= button.GetComponent<AdvertiseButton>().adPrice)
            {
                button.GetComponent<Button>().interactable = true;
            }
            else
            {
                button.GetComponent<Button>().interactable = false;
            }
        }
        else
        {
            foreach (GameObject button in AllAdButtons)
                button.GetComponent<Button>().interactable = false;
            if((int)_timer  < 60)
                timerText.text = "Time Left for add: " + (int)_timer + " Seconds";
            else
            {
                timerText.text = "Time Left for add: " + ((int)_timer) / 60 + " Minuets " + 
                    ((int)_timer) % 60 + " Seconds";
            }
        }

    }

    void TaskOnClick()
    {
        switch (AdType)
        {
            case "Good":
                money._totalMoney -= adPrice;
                addController.GetComponent<AdvertiseController>().AddTimer = adDuration;
                Spawners[0].GetComponent<CustomerSpawner>().isActive = true;
                foreach(GameObject button in AllAdButtons)
                    button.GetComponent<Button>().interactable = false;
                currentRunningAdText.text = "Current Runnning Add: Good Advertisement";
                customerMultiplierText.text = "Customer Multiplier: x2";
                break;
            case "Better":
                money._totalMoney -= adPrice;
                addController.GetComponent<AdvertiseController>().AddTimer = adDuration;
                Spawners[0].GetComponent<CustomerSpawner>().isActive = true;
                Spawners[1].GetComponent<CustomerSpawner>().isActive = true;
                foreach (GameObject button in AllAdButtons)
                    button.GetComponent<Button>().interactable = false;
                currentRunningAdText.text = "Current Runnning Add: Better Advertisement";
                customerMultiplierText.text = "Customer Multiplier: x3";
                break;
            case "Best":
                money._totalMoney -= adPrice;
                addController.GetComponent<AdvertiseController>().AddTimer = adDuration;
                Spawners[0].GetComponent<CustomerSpawner>().isActive = true;
                Spawners[1].GetComponent<CustomerSpawner>().isActive = true;
                Spawners[2].GetComponent<CustomerSpawner>().isActive = true;
                foreach (GameObject button in AllAdButtons)
                    button.GetComponent<Button>().interactable = false;
                currentRunningAdText.text = "Current Runnning Add: Best Advertisement";
                customerMultiplierText.text = "Customer Multiplier: x4";
                break;
        }
    }
}
