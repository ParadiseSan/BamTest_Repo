using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class DailyRewardUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dayText;
    [SerializeField] TextMeshProUGUI rewardTypeText;  
    [SerializeField] TextMeshProUGUI rewardAmountText;
    [SerializeField] Image rewardImage;
    [SerializeField] Button rewardButton;
    [SerializeField] GameObject tickImage;
    [SerializeField] GameObject rewardLockedPanel;
    [SerializeField] GameObject rewardParticles;
    bool isRewardLocked = true;         // by default every reward is locked
    private DailyRewardInfo rewardInfo;
    

    public void Setup(DailyRewardInfo info)
    {
        isRewardLocked = info.isLocked;
        if(isRewardLocked)
        {
            rewardParticles.SetActive(false);
            ButtonLocked();
        }
        AddRewardDataToUi(info);


        rewardButton.onClick.AddListener(OnRewardClick); // If the reward button is clicked then OnRewardClick method is called

    }

    // if button is locked then disable the button and show the locked panel
    void ButtonLocked()
    {
        rewardButton.interactable = false;
        rewardLockedPanel.SetActive(true);
    }


    // All the reward data is added to respective UI elements
    void AddRewardDataToUi(DailyRewardInfo info)
    {
        rewardInfo = info;
        dayText.text = $"Day {info.day}";
        rewardImage.sprite = info.rewardImage;
        rewardAmountText.text = info.rewardAmount.ToString();
    }
    private void OnRewardClick()
    {
        Debug.Log($"[Reward Clicked] Day {rewardInfo.day} | Type: {rewardInfo.rewardType} | Amount: {rewardInfo.rewardAmount}");


        AudioManager.Instance.PlayRewardButtonSfx();
        GetComponent<Button>().interactable = false;    // disable the button after clicking so that it cannot be clicked multiple times   

        // Fade out reward image and reward amount text
        rewardImage.DOFade(0f, 0.5f).OnComplete(() => Destroy(rewardImage.gameObject));
        rewardAmountText.DOFade(0f, 0.5f).OnComplete(() => Destroy(rewardAmountText.gameObject));
        Destroy(rewardParticles);

        // Pop out the tick image
        tickImage.transform.localScale = Vector3.zero;
        tickImage.SetActive(true);
        tickImage.transform.DOScale(1f, 0.5f).SetEase(Ease.OutBack);

    }
}
