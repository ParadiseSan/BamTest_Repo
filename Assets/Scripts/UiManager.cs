using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [Header("Reward UI")]
    [SerializeField] GameObject rewardPanel;   
    [SerializeField] float animationDuration = 0.5f;
    [SerializeField] GameObject dimmedBg;     // here the dimmed background image is taken as a gameobject so that it can be activated and deactivated it after fading.
    [SerializeField] string bamLogoURL;       // the URL to open when the BAM logo is clicked
    Image dimmedBGImage;        // the cache the image component of the dimmedBackground Image 
    Vector3 originalScale;      // original scale of the reward panel


    private void Start()
    {
        // Cache original scale
        originalScale = rewardPanel.transform.localScale;

        // the panel is initially hidden
        rewardPanel.transform.localScale = Vector3.zero;
        rewardPanel.SetActive(false);
        dimmedBg.SetActive(false);
        dimmedBGImage = dimmedBg.GetComponent<Image>();
    }


    #region Reward Panel

    // Connected to the reward button 
    public void ShowRewardPanel()
    {

        AudioManager.Instance.PlayButtonClickSFX();
        rewardPanel.SetActive(true);
        rewardPanel.transform.localScale = Vector3.zero;

        dimmedBg.SetActive(true);
        dimmedBGImage.DOFade(1f, animationDuration);
        rewardPanel.transform.DOScale(originalScale, animationDuration)
            .SetEase(Ease.OutBack);
    }


    // Connected to the close button
    public void HideRewardPanel()
    {
        AudioManager.Instance.PlayButtonClickSFX();
        dimmedBGImage.DOFade(0f, animationDuration).OnComplete(() =>
        {
            dimmedBg.SetActive(false);
        });

        rewardPanel.transform.DOScale(Vector3.zero, animationDuration)
            .SetEase(Ease.InBack)
            .OnComplete(() =>
            {
                rewardPanel.SetActive(false);
            });
    }


    #endregion
    public void OpenBamWebsite()
    {
        Application.OpenURL(bamLogoURL);
    }
}
