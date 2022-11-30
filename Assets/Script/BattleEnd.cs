using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BattleEnd : MonoBehaviour
{
    [SerializeField]
    private GameObject clearTitle;
    [SerializeField]
    public GameObject clearPopupBack;
    [SerializeField]
    public GameObject cloearHomeBtn;
    [SerializeField]
    public GameObject clearTime;
    [SerializeField]
    public GameObject clearHP;
    [SerializeField]
    public GameObject star1, star2, star3;
    [SerializeField]
    private GameObject timeObj;
    [SerializeField]
    private TextMeshProUGUI clearTimeText;
    [SerializeField]
    private TextMeshProUGUI clearHPText;

    [SerializeField]
    private GameObject loseTitle;
    [SerializeField]
    private TextMeshProUGUI loseTimeText;
    [SerializeField]
    public GameObject losePopupBack;
    [SerializeField]
    public GameObject loseHomeBtn;
    [SerializeField]
    public GameObject loseTime;
    [SerializeField]
    public GameObject loseHP;
    [SerializeField]
    public GameObject loseStar1, loseStar2, loseStar3;
    [SerializeField]
    private GameObject loseGoldObj;

    [SerializeField]
    private FadeInOut fade;

    private int star;
    private int gold;


    [SerializeField]
    private GameObject goldObj;
    [SerializeField]
    private TextMeshProUGUI goldtext;

    private void ClearStarGold()
    {
        star = 1;
        if (BattleScene.bData.clearMinute <= 6)
        {
            star += 1;
        }
            
        if (BattleScene.bData.bCastleHP >= 80)
        {
            star += 1;
        }
    }

    public void LoseUI()
    {
        SoundManager.Inst.ChangeBGM(BGM_Type.BGM_Lose);
        timeObj.SetActive(false);
        clearTimeText.text = BattleScene.bData.battleTime;
        loseTimeText.text = BattleScene.bData.battleTime;
        LeanTween.scale(loseTitle, new Vector3(1f, 1f, 1f), 2f).setDelay(0.5f)
                 .setEase(LeanTweenType.easeInOutElastic).setOnComplete(LosePopupBack);
        LeanTween.moveLocal(loseTitle, new Vector3(0f, 55f, 0f), 0.5f).setDelay(2f).setEase(LeanTweenType.easeInOutCubic);
    }

    public void LosePopupBack()
    {
        LeanTween.moveLocal(losePopupBack, new Vector3(0f, 5f, 0f), 0.5f).setEase(LeanTweenType.easeOutCirc)
                 .setOnComplete(LoseStarOn);
        LeanTween.scale(loseHomeBtn, new Vector3(1f, 1f, 1f), 2f).setDelay(1f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(loseTime, new Vector3(1f, 1f, 1f), 2f).setDelay(1.2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(loseHP, new Vector3(1f, 1f, 1f), 2f).setDelay(1.4f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(loseGoldObj, new Vector3(1f, 1f, 1f), 2f).setDelay(1.6f).setEase(LeanTweenType.easeOutElastic);
    }

    public void LoseStarOn()
    {
        LeanTween.scale(loseStar1, new Vector3(0.2f, 0.2f, 0.2f), 2f).setDelay(0.1f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(loseStar2, new Vector3(0.2f, 0.2f, 0.2f), 2f).setDelay(0.2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(loseStar3, new Vector3(0.25f, 0.25f, 0.25f), 2f).setDelay(0.3f).setEase(LeanTweenType.easeOutElastic);
    }

        public void SetBattleEndUI()
    {
        SoundManager.Inst.ChangeBGM(BGM_Type.BGM_Victory);
        timeObj.SetActive(false);
        ClearStarGold();
        clearHPText.text = (BattleScene.bData.bCastleHP).ToString();
        clearTimeText.text = BattleScene.bData.battleTime;
        LeanTween.scale(clearTitle, new Vector3(1f, 1f, 1f), 2f).setDelay(0.5f)
                 .setEase(LeanTweenType.easeInOutElastic).setOnComplete(PopupBack);
        LeanTween.moveLocal(clearTitle, new Vector3(0f, 55f, 0f), 0.5f).setDelay(2f).setEase(LeanTweenType.easeInOutCubic);
    }

    public void PopupBack()
    {
        LeanTween.moveLocal(clearPopupBack, new Vector3(0f, 5f, 0f), 0.5f).setEase(LeanTweenType.easeOutCirc)
                 .setOnComplete(StarOnGold);
        LeanTween.scale(cloearHomeBtn, new Vector3(1f, 1f, 1f), 2f).setDelay(1f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(clearTime, new Vector3(1f, 1f, 1f), 2f).setDelay(1.2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(clearHP, new Vector3(1f, 1f, 1f), 2f).setDelay(1.4f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(goldObj, new Vector3(1f, 1f, 1f), 2f).setDelay(1.6f).setEase(LeanTweenType.easeOutElastic);
    }

    public void StarOnGold()
    {
        LeanTween.scale(star1, new Vector3(0.2f, 0.2f, 0.2f), 2f).setDelay(0.1f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(star2, new Vector3(0.2f, 0.2f, 0.2f), 2f).setDelay(0.2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(star3, new Vector3(0.25f, 0.25f, 0.25f), 2f).setDelay(0.3f).setEase(LeanTweenType.easeOutElastic);
        switch (star)
        {
            case 1:
                {
                    star1.transform.GetChild(0).gameObject.SetActive(true);
                    break;
                }
            case 2:
                {
                    star1.transform.GetChild(0).gameObject.SetActive(true);
                    star2.transform.GetChild(0).gameObject.SetActive(true);
                    break;
                }
            case 3:
                {
                    star1.transform.GetChild(0).gameObject.SetActive(true);
                    star2.transform.GetChild(0).gameObject.SetActive(true);
                    star3.transform.GetChild(0).gameObject.SetActive(true);
                    break;
                }
        }
        StageClear(GameManager.Inst.PlayerInfo.initStage);
        StageGold(GameManager.Inst.PlayerInfo.initStage);
        StageBtnStar(GameManager.Inst.PlayerInfo.initStage);
        GameManager.Inst.SaveData();
    }

    private void StageClear(int stage)
    {
        switch(stage)
        {
            case 1:
                {
                    if(GameManager.Inst.PlayerInfo.clearStage < 1)
                    {
                        GameManager.Inst.PlayerInfo.stage1 = true;
                        GameManager.Inst.PlayerInfo.clearStage = 1;
                        GameManager.Inst.PlayerInfo.nextStage = 2;
                    }
                    break;
                }
            case 2:
                {
                    if (GameManager.Inst.PlayerInfo.clearStage < 2)
                    {
                        GameManager.Inst.PlayerInfo.stage2 = true;
                        GameManager.Inst.PlayerInfo.clearStage = 2;
                        GameManager.Inst.PlayerInfo.nextStage = 3;
                    }
                    break;
                }
            case 3:
                {
                    if (GameManager.Inst.PlayerInfo.clearStage < 3)
                    {
                        GameManager.Inst.PlayerInfo.stage3 = true;
                        GameManager.Inst.PlayerInfo.clearStage = 3;
                        GameManager.Inst.PlayerInfo.nextStage = 4;
                    }
                    break;
                }
            case 4:
                {
                    if (GameManager.Inst.PlayerInfo.clearStage < 4)
                    {
                        GameManager.Inst.PlayerInfo.stage4 = true;
                        GameManager.Inst.PlayerInfo.clearStage = 4;
                        GameManager.Inst.PlayerInfo.nextStage = 5;
                    }
                    break;
                }
            case 5:
                {
                    if (GameManager.Inst.PlayerInfo.clearStage < 5)
                    {
                        GameManager.Inst.PlayerInfo.stage5 = true;
                        GameManager.Inst.PlayerInfo.clearStage = 5;
                        GameManager.Inst.PlayerInfo.nextStage = 6;
                    }
                    break;
                }
            case 6:
                {
                    if (GameManager.Inst.PlayerInfo.clearStage < 6)
                    {
                        GameManager.Inst.PlayerInfo.stage6 = true;
                        GameManager.Inst.PlayerInfo.clearStage = 6;
                    }
                    break;
                }
        }
    }

    private void StageBtnStar(int stage)
    {
        switch(stage)
        {
            case 1:
                {
                    if(GameManager.Inst.PlayerInfo.stage1Star != 3)
                        GameManager.Inst.PlayerInfo.stage1Star = star;
                    break;
                }
            case 2:
                {
                    if(GameManager.Inst.PlayerInfo.stage2Star != 3)
                        GameManager.Inst.PlayerInfo.stage2Star = star;
                    break;
                }
            case 3:
                {
                    if (GameManager.Inst.PlayerInfo.stage3Star != 3)
                        GameManager.Inst.PlayerInfo.stage3Star = star;
                    break;
                }
            case 4:
                {
                    if (GameManager.Inst.PlayerInfo.stage4Star != 3)
                        GameManager.Inst.PlayerInfo.stage4Star = star;
                    break;
                }
            case 5:
                {
                    if (GameManager.Inst.PlayerInfo.stage5Star != 3)
                        GameManager.Inst.PlayerInfo.stage5Star = star;
                    break;
                }
            case 6:
                {
                    if (GameManager.Inst.PlayerInfo.stage6Star != 3)
                        GameManager.Inst.PlayerInfo.stage6Star = star;
                    break;
                }
        }
    }

    public void StageGold(int stage)
    {
        switch (stage)
        {
            case 1:
                {
                    switch (star - GameManager.Inst.PlayerInfo.stage1Star)
                    {
                        case 0:
                            {
                                gold = 0;
                                break;
                            }

                        case 1:
                            {
                                gold = 50;
                                break;
                            }
                        case 2:
                            {
                                gold = 100;
                                break;
                            }
                        case 3:
                            {
                                gold = 150;
                                break;
                            }
                    }
                    break;

                }
            case 2:
                {
                    if (GameManager.Inst.PlayerInfo.stage2Star < star)
                    {
                        switch (star - GameManager.Inst.PlayerInfo.stage2Star)
                        {
                            case 1:
                                {
                                    gold = 50;
                                    break;
                                }
                            case 2:
                                {
                                    gold = 100;
                                    break;
                                }
                            case 3:
                                {
                                    gold = 150;
                                    break;
                                }
                        }
                    }
                    else
                    {
                        gold = 0;
                    }
                    break;
                }
            case 3:
                {
                    if (GameManager.Inst.PlayerInfo.stage3Star < star)
                    {
                        switch (star - GameManager.Inst.PlayerInfo.stage3Star)
                        {
                            case 1:
                                {
                                    gold = 50;
                                    break;
                                }
                            case 2:
                                {
                                    gold = 100;
                                    break;
                                }
                            case 3:
                                {
                                    gold = 150;
                                    break;
                                }
                        }
                    }
                    else
                    {
                        GameManager.Inst.PlayerInfo.stage3Star = 3;
                        gold = 0;
                    }
                    break;
                }
            case 4:
                {
                    if (GameManager.Inst.PlayerInfo.stage4Star < star)
                    {
                        switch (star - GameManager.Inst.PlayerInfo.stage4Star)
                        {
                            case 1:
                                {
                                    gold = 50;
                                    break;
                                }
                            case 2:
                                {
                                    gold = 100;
                                    break;
                                }
                            case 3:
                                {
                                    gold = 150;
                                    break;
                                }
                        }
                    }
                    else
                    {
                        GameManager.Inst.PlayerInfo.stage4Star = 3;
                        gold = 0;
                    }
                    break;
                }
            case 5:
                {
                    if (GameManager.Inst.PlayerInfo.stage5Star < star) 
                    {
                        switch (star - GameManager.Inst.PlayerInfo.stage5Star)
                        {
                            case 1:
                                {
                                    gold = 50;
                                    break;
                                }
                            case 2:
                                {
                                    gold = 100;
                                    break;
                                }
                            case 3:
                                {
                                    gold = 150;
                                    break;
                                }
                        }
                    }
                    else
                    {
                        GameManager.Inst.PlayerInfo.stage5Star = 3;
                        gold = 0;
                    }
                    break;
                }
            case 6:
                {
                    if (GameManager.Inst.PlayerInfo.stage6Star < star) 
                    {
                        switch (star - GameManager.Inst.PlayerInfo.stage6Star)
                        {
                            case 1:
                                {
                                    gold = 50;
                                    break;
                                }
                            case 2:
                                {
                                    gold = 100;
                                    break;
                                }
                            case 3:
                                {
                                    gold = 150;
                                    break;
                                }
                        }
                    }
                    else
                    {
                        GameManager.Inst.PlayerInfo.stage6Star = 3;
                        gold = 0;
                    }
                    break;
                }
        }
        goldtext.text = gold.ToString();
        GameManager.Inst.PlayerInfo.gold += gold;
    }

    public void ReturnToLobby_Btn()
    {
        GameManager.Inst.SaveData();
        fade.Fade_InOut(false, 3.0f);
        Invoke("LoadScene", 3f);
    }

    private void LoadScene()
    {
        GameManager.Inst.AsyncLoadNextScene(SceneName.LobbyScene);
    }


}
