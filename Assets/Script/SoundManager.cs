using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum BGM_Type
{
    BGM_Title = 0,
    BGM_Lobby = 1,
    BGM_Battle = 2,
    BGM_Victory = 3,
    BGM_Lose = 4,
}

public enum SFX_Type
{
    SFX_Sword,
    SFX_Guard,
    SFX_Archer,
    SFX_Wizard,
    SFX_Click,
    SFX_Upgrade,
    SFX_BtnPage,
}

public enum Sound_Type
{
    BGM,
    SFX,
}

public class SoundManager : Singleton<SoundManager>
{

    private void Awake()
    {
        base.Awake();
    }

    [SerializeField]
    private AudioSource bgmAudio;
    [SerializeField]
    private List<AudioClip> bgmList;

    [SerializeField]
    private AudioMixer audioMixer;

    public void ChangeBGM(BGM_Type BGM)
    {
        StartCoroutine(ChangeBGMClip(bgmList[(int)BGM]));
    }

    float current;
    float percent;

    IEnumerator ChangeBGMClip(AudioClip audioClip)
    {
        current = 0;
        percent = 0;
        while (percent < 1f)
        {
            current += Time.deltaTime;
            percent = current / 1f;
            bgmAudio.volume = Mathf.Lerp(1f, 0f, percent);
            yield return null;
        }

        bgmAudio.clip = audioClip;
        bgmAudio.Play();
        current = 0;
        percent = 0;
        while (percent < 1f)
        {
            current += Time.deltaTime;
            percent = current / 1f;
            bgmAudio.volume = Mathf.Lerp(0f, GameManager.Inst.PlayerInfo.bgm, percent);
            yield return null;
        }
    }

    private int cursur = 0;

    [SerializeField]
    private List<AudioSource> sfxPlayers;

    [SerializeField]
    private List<AudioClip> sfxList;

    public void PlaySFX(SFX_Type SFX)
    {
        sfxPlayers[cursur].clip = sfxList[(int)SFX];
        sfxPlayers[cursur].Play();

        cursur++;
        if (cursur > 9)
            cursur = 0;
    }

}
