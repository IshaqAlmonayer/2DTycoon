using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardEagle : MonoBehaviour
{
    public float speed = 0.5f;

    private GameObject LuckyDuckyPanel;
    private MenuController MenuController;
    private Button yesButton;
    private Button noButton;
    private Text RewardText;

    private Rigidbody2D _rigidbody;
    private Vector2 _movement;
    private float _direction = 1;
    private bool CLicked = false;
    private GameObject money;
    private bool paused;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        foreach (GameObject gObject in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        { 
            if(gObject.name == "LuckyDucky")
                LuckyDuckyPanel = gObject;
            if (gObject.name == "YesLuckyDucky")
                yesButton = gObject.GetComponent<Button>();
            if (gObject.name == "NoLuckyDucky")
                noButton = gObject.GetComponent<Button>();
            if (gObject.name == "RewardDuckText")
                RewardText = gObject.GetComponent<Text>();
        }

        MenuController = GameObject.Find("MenuController").GetComponent<MenuController>();
        
        money = GameObject.Find("Total Money");
        
        yesButton.onClick.AddListener(TaskOnClickYes);

        noButton.onClick.AddListener(TaskOnClickNo);

        RewardText.text = NormaliseMoneyText(money.GetComponent<Money>().totalRevenuePerMinute * 2) + "$";
    }

    void Update()
    {
        _movement = new Vector2(_direction, 0f);
    }

    void FixedUpdate()
    {
        float HorizontalVelocity = _movement.normalized.x * speed;
        _rigidbody.velocity = new Vector2(HorizontalVelocity, _rigidbody.velocity.y);
    }

    void OnMouseDown()
    {
        if (!CLicked)
        {
            LuckyDuckyPanel.SetActive(true);
            CLicked = true;
            paused = true;
            if(paused)
                PauseGame();
            MenuController.ChangePanelStatus();
        }
    }

    public void Proceed(bool agreed) {
        if (agreed)
        {
            Debug.Log("money.GetComponent<Money>().totalRevenuePerMinute * 2: " + money.GetComponent<Money>().totalRevenuePerMinute * 2);
            money.GetComponent<Money>()._totalMoney += money.GetComponent<Money>().totalRevenuePerMinute * 2;
            ResumeGame();
        }
        else
        {
            ResumeGame();
        }
    }


    void TaskOnClickYes() {
        Proceed(true);
    }

    void TaskOnClickNo()
    {
        Proceed(false);
    }


    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }

    private string NormaliseMoneyText(float amount)
    {
        if (amount < 1000)
            return amount.ToString();
        else
        {
            return ((int)amount / 1000).ToString() + "." + ((int)(amount % 1000) / 100).ToString() + "K";
        }
    }

}