using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class TitleScene : MonoBehaviour
{
    [SerializeField]
    private     TextMeshProUGUI         welocmText;
    [SerializeField]
    private     GameObject              nickNamePopup;
    private     bool                    havePlayerInfo;

    [SerializeField]
    private FadeInOut fade;

    [SerializeField]
    private AudioMixer audioMixer;

    private AudioSource bgmAuido;

    private void Awake()
    {
        bgmAuido = GameObject.Find("SoundManager").transform.GetChild(0).GetComponent<AudioSource>();
        
        SoundInit();
        InitTitleScene();
        fade.Fade_InOut(true, 3.0f);
    }

    private void SoundInit()
    {
        if (!bgmAuido.playOnAwake)
        {
            bgmAuido.playOnAwake = true;
            bgmAuido.Play();
        }
            

        //SoundManager.Inst.ChangeBGM(BGM_Type.BGM_Title);
        if (havePlayerInfo)
        {
            Debug.Log("정보있음");
            audioMixer.SetFloat(Sound_Type.BGM.ToString(), GameManager.Inst.PlayerInfo.bgm);
            audioMixer.SetFloat(Sound_Type.SFX.ToString(), GameManager.Inst.PlayerInfo.sfx);
            //SoundManager.Inst.ChangeBGM(BGM_Type.BGM_Lobby);
        }
        else
        {
            Debug.Log("정보없음");
            audioMixer.SetFloat(Sound_Type.BGM.ToString(), 1f);
            audioMixer.SetFloat(Sound_Type.SFX.ToString(), 1f);
            //SoundManager.Inst.ChangeBGM(BGM_Type.BGM_Lobby);
        }
    }

    private void InitTitleScene()
    {
        if (GameManager.Inst.CheckData())
        {
            welocmText.text = GameManager.Inst.PlayerInfo.userName + "님 환영합니다.\n 터치시 시작";
            havePlayerInfo = true;
        }
        else
        {
            welocmText.text = "계속 하려면 터치 하세요.";
            havePlayerInfo = false;
        }
    }

    public void DeleteBtn()
    {
        SoundManager.Inst.PlaySFX(SFX_Type.SFX_Click);
        GameManager.Inst.DeleteData();
        SoundInit();
        InitTitleScene();
    }

    public void SaveBtn() // 유저데이터가 없을때 새로 생성하는 팝업에서 호출
    {
        SoundManager.Inst.PlaySFX(SFX_Type.SFX_Click);
        if (havePlayerInfo)
            GameManager.Inst.AsyncLoadNextScene(SceneName.LobbyScene);
        else
        {
            LeanTween.scale(nickNamePopup, Vector3.one, 0.7f).setEase(LeanTweenType.easeOutElastic);
            welocmText.enableAutoSizing = false;
        }
    }

    private string newUserName = "";

    public void InputField(string input)
    {
        newUserName = input;
    }

    public void CreateUserInfo()
    {
        SoundManager.Inst.PlaySFX(SFX_Type.SFX_Click);
        if (newUserName.Length >= 2)
        {
            LeanTween.scale(nickNamePopup, Vector3.zero, 0.7f).setEase(LeanTweenType.easeOutElastic);
            welocmText.enabled = true;
            GameManager.Inst.UpdateUserName(newUserName);
            GameManager.Inst.InitData();
            InitTitleScene();
        }
        else
            WarningText();
    }

    #region WarningText
    [SerializeField]
    private TextMeshProUGUI warningText;

    private void WarningText()
    {
        Color fromColor = Color.red;
        Color toColor = Color.red;
        fromColor.a = 0f;
        toColor.a = 1f;

        LeanTween.value(warningText.gameObject, updateValue, fromColor, toColor, 1f)
            .setEase(LeanTweenType.easeInOutQuad);
        LeanTween.value(warningText.gameObject, updateValue, toColor, fromColor, 1f)
            .setDelay(1f).setEase(LeanTweenType.easeInOutQuad);
    }

    private void updateValue(Color val)
    {
        warningText.color = val;
    }
    #endregion

    public void GameExitBtn()
    {
        SoundManager.Inst.PlaySFX(SFX_Type.SFX_Click);
        GameManager.Inst.SaveData();
        Application.Quit();
    }
}
