using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance { get; private set; }

    [SerializeField] AudioSource sfxAudioSource;
    [SerializeField] UiSfxSO audioClips;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayRewardButtonSfx()
    {
        sfxAudioSource.PlayOneShot(audioClips.rewardButtonSfx);
    }

    public void PlayButtonClickSFX()
    {
        sfxAudioSource.PlayOneShot(audioClips.buttonClickSfx);
    }
}
