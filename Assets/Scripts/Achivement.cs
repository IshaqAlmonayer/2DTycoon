using UnityEngine;

public class Achivement : MonoBehaviour
{
    public Stand Stand;
    public GameObject Achievement;
    public Money money;
    public bool moneyAchivement;
    public AchievementController AchievementController;

    void Update()
    {
        if (Stand != null)
        {
            if (Stand.TotalStandRevenue >= 1000)
            {
                gameObject.SetActive(false);
                Achievement.SetActive(true);
                AchievementController.AchievementCount++;
            }
            else
            {
                gameObject.SetActive(true);
                Achievement.SetActive(false);
            }
        }
        else if (moneyAchivement)
        {
            if (money.totalShopExpenses >= 10000)
            {
                gameObject.SetActive(false);
                Achievement.SetActive(true);
                AchievementController.AchievementCount++;
            }
            else
            {
                gameObject.SetActive(true);
                Achievement.SetActive(false);
            }
        }
        else
        {
            if (AchievementController.AchievementCount == AchievementController.AchievementsNumber)
            {
                gameObject.SetActive(false);
                Achievement.SetActive(true);
            }
            else
            {
                gameObject.SetActive(true);
                Achievement.SetActive(false);
            }
        }
        Debug.Log("AchievementController.AchievementCount:" + AchievementController.AchievementCount);
    }
}
