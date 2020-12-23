using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;


public class RewardEagle : MonoBehaviour
{
    //Google Adds
    private RewardBasedVideoAd rewardBasedVideoAd;

    public float speed = 0.5f;

    private GameObject LuckyDuckyPanel;
    private MenuController MenuController;
    private Button yesButton;
    private Button noButton;
    private Text RewardText;

    private NitificationSwitch NitificationSwitch;


    private Rigidbody2D _rigidbody;
    private Vector2 _movement;
    private float _direction = 1;
    private bool CLicked = false;
    private GameObject money;
    private bool paused;
    private bool Rewarded = false;

    void Start()
    {
        //Google Adds
        rewardBasedVideoAd = RewardBasedVideoAd.Instance;

        rewardBasedVideoAd.OnAdRewarded += HandleOnAdRewarded;
        rewardBasedVideoAd.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        rewardBasedVideoAd.OnAdLeavingApplication += HandleOnAdLeavingApplication;
        rewardBasedVideoAd.OnAdLoaded += HandleOnAdLoaded;
        rewardBasedVideoAd.OnAdOpening += HandleOnAdOpenning;
        rewardBasedVideoAd.OnAdStarted += HandleOnAdStarted;

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
            if (gObject.name == "NotificationPanel")
                NitificationSwitch = gObject.GetComponent<NitificationSwitch>();
        }

        MenuController = GameObject.Find("MenuController").GetComponent<MenuController>();
        
        money = GameObject.Find("Total Money");
        
        yesButton.onClick.AddListener(TaskOnClickYes);

        noButton.onClick.AddListener(TaskOnClickNo);
        RewardText.text = "You just catched a lucky duck! would you like to watch a short ad and make " + 
            NormaliseMoneyText(money.GetComponent<Money>().totalRevenuePerMinute * 2) + "$ Instantly";

        LoadRewardBasedAdd();
    }

    void Update()
    {
        _movement = new Vector2(_direction, 0f);

        if (Rewarded) {
            Rewarded = false;
            money.GetComponent<Money>()._totalMoney += money.GetComponent<Money>().totalRevenuePerMinute * 2;
            ResumeGame();
            NitificationSwitch.TriggerNotification("You Just Been Rewarded");
        }
    }

    void FixedUpdate()
    {
        float HorizontalVelocity = _movement.normalized.x * speed;
        _rigidbody.velocity = new Vector2(HorizontalVelocity, _rigidbody.velocity.y);
    }

    void OnMouseDown()
    {
        if (!MenuController.OpenPanel)
        {
            if (!CLicked)
            {
                LuckyDuckyPanel.SetActive(true);
                CLicked = true;
                paused = true;
                if (paused)
                    PauseGame();
                MenuController.ChangePanelStatus();
            }
        }
    }

    public void Proceed(bool agreed) {
        if (agreed)
        {
            ShowRewardBasedAdd();
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

    private void LoadRewardBasedAdd()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-5800456106473201/3209336280";
        #elif UNITY_IPHONE
                string adUnitId = "ca-app-pub-5800456106473201/3209336280";
#else
                string adUnitId = "unexpected_platform";
#endif

        AdRequest request = new AdRequest.Builder().Build();

        rewardBasedVideoAd.LoadAd(request, adUnitId);
    }

    private void ShowRewardBasedAdd()
    {
        if (rewardBasedVideoAd.IsLoaded())
        {
            rewardBasedVideoAd.Show();
        }
        else {
            Debug.Log("Add Not Loaded Yet");
            NitificationSwitch.TriggerNotification("we couldnt load an ad for you at this moment");
        }
    }


    public void HandleOnAdLoaded(object Sender, EventArgs args) {
        Debug.Log("Add Loaded");
    }

    public void HandleOnAdFailedToLoad(object Sender, AdFailedToLoadEventArgs args)
    {
        //ResumeGame();
        Debug.Log("Add Failed To Load");
    }

    public void HandleOnAdOpenning(object Sender, EventArgs args)
    {
        Debug.Log("Add Openning");
    }

    public void HandleOnAdStarted(object Sender, EventArgs args)
    {
        Debug.Log("Add Started");
    }

    public void HandleOnAdClosed(object Sender, EventArgs args)
    {
        Debug.Log("Add Closed");
        ResumeGame();
    }

    public void HandleOnAdLeavingApplication(object Sender, EventArgs args)
    {
        Debug.Log("Application Closed");
    }

    public void HandleOnAdRewarded(object Sender, Reward args) {
        Debug.Log("Add Rewarded");
        Rewarded = true;
    }

    public bool getClickedStatus() {
        return CLicked;
    }
}