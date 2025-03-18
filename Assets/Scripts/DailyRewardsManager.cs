using UnityEngine;

public class DailyRewardsManager : MonoBehaviour
{
    [SerializeField] DailyRewardDataSO dailyRewardsData;
    [SerializeField] GameObject rewardItemPrefab;
    [SerializeField] Transform contentParent;

    private void Start()
    {

        // Populate the rewards by taking the data from dailyRewardsDataSO 
        PopulateRewards();
    }

    void PopulateRewards()
    {
        foreach (var reward in dailyRewardsData.rewards)
        {
            GameObject rewardGO = Instantiate(rewardItemPrefab, contentParent);
            DailyRewardUI rewardUI = rewardGO.GetComponent<DailyRewardUI>();
            rewardUI.Setup(reward); // pass the reward data to the dailyRewardUI script
        }
    }
}
