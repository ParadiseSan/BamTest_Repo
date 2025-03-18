using UnityEngine;

[CreateAssetMenu(fileName = "DailyRewardsData", menuName = "Rewards/Daily Rewards Data")]
public class DailyRewardDataSO : ScriptableObject
{
    public DailyRewardInfo[] rewards;   // array to store the daily rewards info like day1, day2, day3 etc.
}
