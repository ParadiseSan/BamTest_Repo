using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DailyRewardInfo
{
    public int day;
    public string rewardType;
    public Sprite rewardImage;
    public int rewardAmount;
    public bool isLocked;
}