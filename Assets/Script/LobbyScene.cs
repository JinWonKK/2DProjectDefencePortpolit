using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class LobbyScene : MonoBehaviour
{
    [SerializeField]
    private GameObject stageUI;
    [SerializeField]
    private GameObject stageBtnGroup;
    [SerializeField]
    private GameObject upgradeUI;
    [SerializeField]
    private GameObject soundSettingUI;

    private bool setting;

    [SerializeField]
    private FadeInOut fade;


    private void Awake()
    {
        fade.Fade_InOut(true, 3f);
        SoundInit();
        setting = false;
    }

    private void SoundInit()
    {
        SoundManager.Inst.ChangeBGM(BGM_Type.BGM_Lobby);
        bgm_Slider.value = GameManager.Inst.PlayerInfo.bgm;
        sfx_Slider.value = GameManager.Inst.PlayerInfo.sfx;
        bgm_Text.text = (GameManager.Inst.PlayerInfo.bgm).ToString();
        sfx_Text.text = (GameManager.Inst.PlayerInfo.sfx).ToString();
    }

    public void SoundSettingUI()
    {
        SoundManager.Inst.PlaySFX(SFX_Type.SFX_Click);
        if (!setting)
        {
            LeanTween.scale(soundSettingUI, Vector3.one, 0.7f).setEase(LeanTweenType.easeInOutElastic);
            setting = true;
        }
        else if(setting)
        {
            LeanTween.scale(soundSettingUI, Vector3.zero, 0.7f).setEase(LeanTweenType.easeInOutElastic);
            setting = false;
        }
    }

    public void StageUIBtn()
    {
        SoundManager.Inst.PlaySFX(SFX_Type.SFX_Click);
        LeanTween.moveLocalY(stageUI.gameObject, -250f, 0.7f);
    }

    public void UpgradeUIBtn()
    {
        SoundManager.Inst.PlaySFX(SFX_Type.SFX_Click);
        LeanTween.moveLocalY(upgradeUI.gameObject, -250f, 0.7f);
    }

    public void ExitBtn()
    {
        SoundManager.Inst.PlaySFX(SFX_Type.SFX_Click);
        LeanTween.moveLocalY(stageUI.gameObject, -1000f, 0.7f);
        LeanTween.moveLocalY(upgradeUI.gameObject, -1000f, 0.7f);
    }

    public void RightBtn()
    {
        SoundManager.Inst.PlaySFX(SFX_Type.SFX_BtnPage);
        LeanTween.moveLocalX(stageBtnGroup.gameObject, -600f, 0.7f);
    }

    public void LeftBtn()
    {
        SoundManager.Inst.PlaySFX(SFX_Type.SFX_BtnPage);
        LeanTween.moveLocalX(stageBtnGroup.gameObject, 0, 0.7f);
    }

    public void NextScene()
    {
        GameManager.Inst.AsyncLoadNextScene(SceneName.BattleScene);
    }

    public void Fade(int stage)
    {
        SoundManager.Inst.PlaySFX(SFX_Type.SFX_Click);
        GameManager.Inst.PlayerInfo.initStage = stage;
        GameManager.Inst.SaveData();
        fade.Fade_InOut(false, 3f);
        Invoke("NextScene", 3.0f);
    }

    public void LogOut()
    {
        SoundManager.Inst.PlaySFX(SFX_Type.SFX_Click);
        fade.Fade_InOut(false, 3.0f);
        GameManager.Inst.SaveData();
        Invoke("TitleScene", 3.0f);
    }

    public void TitleScene()
    {
        SoundManager.Inst.ChangeBGM(BGM_Type.BGM_Title);
        SceneManager.LoadScene("TitleScene");
    }

    [SerializeField]
    private AudioMixer audioMixer;
    [SerializeField]
    private TextMeshProUGUI sfx_Text;

    [SerializeField]
    private Slider sfx_Slider;

    private float valueF;

    public void SFX_ValueChange(float value)
    {
        GameManager.Inst.PlayerInfo.sfx = value;
        GameManager.Inst.SaveData();
        ChangeVolume(sfx_Text, sfx_Slider, Sound_Type.SFX, value);
    }

    void ChangeVolume(TextMeshProUGUI text, Slider slider, Sound_Type type, float newVolume)
    {
        text.text = newVolume.ToString("N2");
        slider.value = newVolume;

        valueF = newVolume * 30f - 30f;
        if (valueF < -29f)
            valueF = -80f;
        audioMixer.SetFloat(type.ToString(), valueF);
    }

    [SerializeField]
    private TextMeshProUGUI bgm_Text;

    [SerializeField]
    private Slider bgm_Slider;

    public void BGM_ValueChange(float value)
    {
        GameManager.Inst.PlayerInfo.bgm = value;
        GameManager.Inst.SaveData();
        ChangeVolume(bgm_Text, bgm_Slider, Sound_Type.BGM, value);
    }
}
