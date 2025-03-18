using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// Scriptable Object to store the UI SFX audio clips so that the AudioManager can access them and work without any direct dependencies
[CreateAssetMenu(fileName = "UI_SFX_AudioClips", menuName = "UI_SFX/AudioClips_Ref")]
public class UiSfxSO : ScriptableObject
{
    [Header("Reward Button SFX")]
    public AudioClip rewardButtonSfx;

    [Header("Button Click SFX")]
    public AudioClip buttonClickSfx;

}
