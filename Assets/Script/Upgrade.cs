using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI bS_LVtext;
    [SerializeField]
    private TextMeshProUGUI bS_ATKtext;
    [SerializeField]
    private TextMeshProUGUI bS_HPtext;
    
    
    [SerializeField]
    private TextMeshProUGUI bA_LVtext;
    [SerializeField]
    private TextMeshProUGUI bA_ATKtext;
    [SerializeField]
    private TextMeshProUGUI bA_HPtext;

    [SerializeField]
    private TextMeshProUGUI bG_LVtext;
    [SerializeField]
    private TextMeshProUGUI bG_ATKtext;
    [SerializeField]
    private TextMeshProUGUI bG_HPtext;

    [SerializeField]
    private TextMeshProUGUI bW_LVtext;
    [SerializeField]
    private TextMeshProUGUI bW_ATKtext;
    [SerializeField]
    private TextMeshProUGUI bW_HPtext;

    [SerializeField]
    private GameObject upgradeClickUI;

    [SerializeField]
    private TextMeshProUGUI prevLvtext;
    [SerializeField]
    private TextMeshProUGUI nextLvtext;
    [SerializeField]
    private TextMeshProUGUI prevATKtext;
    [SerializeField]
    private TextMeshProUGUI nextATKtext;
    [SerializeField]
    private TextMeshProUGUI prevHPtext;
    [SerializeField]
    private TextMeshProUGUI nextHPtext;

    [SerializeField]
    private List<GameObject> prevUI = new List<GameObject>();
    [SerializeField]
    private List<GameObject> nextUI = new List<GameObject>();

    [SerializeField]
    private List<Button> upBtn = new List<Button>();
    [SerializeField]
    private List<TextMeshProUGUI> upBtntext = new List<TextMeshProUGUI>();

    [SerializeField]
    private TextMeshProUGUI goldtext;

    private int playerGold;

    [SerializeField]
    private TextMeshProUGUI scarcetext;

    private void Awake()
    {
        InitUpgradeStat();
        Debug.Log(GameManager.Inst.PlayerInfo.BS);
    }

    private void InitUpgradeStat()
    {
        #region Gold
        PlayerGold();
        goldtext.text = playerGold.ToString();
        #endregion
        #region Level
        switch (GameManager.Inst.PlayerInfo.BS)
        {
            case "BS_1":
                {
                    bS_LVtext.text = "Lv. 1";
                    break;
                }
            case "BS_2":
                {
                    bS_LVtext.text = "Lv. 2";
                    break;
                }
            case "BS_3":
                {
                    bS_LVtext.text = "Lv. 3";
                    upBtn[0].interactable = false;
                    upBtntext[0].text = "Max";
                    upBtntext[0].color = Color.red;
                    break;
                }
        }
        switch (GameManager.Inst.PlayerInfo.BA)
        {
            case "BA_1":
                {
                    bA_LVtext.text = "Lv. 1";
                    break;
                }
            case "BA_2":
                {
                    bA_LVtext.text = "Lv. 2";
                    break;
                }
            case "BA_3":
                {
                    bA_LVtext.text = "Lv. 3";
                    upBtn[1].interactable = false;
                    upBtntext[1].text = "Max";
                    upBtntext[1].color = Color.red;
                    break;
                }
        }
        switch (GameManager.Inst.PlayerInfo.BG)
        {
            case "BG_1":
                {
                    bG_LVtext.text = "Lv. 1";
                    break;
                }
            case "BG_2":
                {
                    bG_LVtext.text = "Lv. 2";
                    break;
                }
            case "BG_3":
                {
                    bG_LVtext.text = "Lv. 3";
                    upBtn[2].interactable = false;
                    upBtntext[2].text = "Max";
                    upBtntext[2].color = Color.red;
                    break;
                }
        }
        switch (GameManager.Inst.PlayerInfo.BW)
        {
            case "BW_1":
                {
                    bW_LVtext.text = "Lv. 1";
                    break;
                }
            case "BW_2":
                {
                    bW_LVtext.text = "Lv. 2";
                    break;
                }
            case "BW_3":
                {
                    bW_LVtext.text = "Lv. 3";
                    upBtn[3].interactable = false;
                    upBtntext[3].text = "Max";
                    upBtntext[3].color = Color.red;
                    break;
                }
        }
        #endregion
        #region ATK
        bS_ATKtext.text = "ATK : " + (GameManager.Inst.PlayerInfo.BS_ATK).ToString();
        bA_ATKtext.text = "ATK : " + (GameManager.Inst.PlayerInfo.BA_ATK).ToString();
        bG_ATKtext.text = "ATK : " + (GameManager.Inst.PlayerInfo.BG_ATK).ToString();
        bW_ATKtext.text = "ATK : " + (GameManager.Inst.PlayerInfo.BW_ATK).ToString();
        #endregion
        #region HP
        bS_HPtext.text = "HP : " + (GameManager.Inst.PlayerInfo.BS_HP).ToString();
        bA_HPtext.text = "HP : " + (GameManager.Inst.PlayerInfo.BA_HP).ToString();
        bG_HPtext.text = "HP : " + (GameManager.Inst.PlayerInfo.BG_HP).ToString();
        bW_HPtext.text = "HP : " + (GameManager.Inst.PlayerInfo.BW_HP).ToString();
        #endregion
    }

    private void PlayerGold()
    {
        playerGold = GameManager.Inst.PlayerInfo.gold;
    }

    private void UpgradeStat(string unitType)
    {
        for (int i = 0; i < prevUI.Count; i++)
        {
            prevUI[i].SetActive(false);
            nextUI[i].SetActive(false);
        }

        switch(unitType)
        {
            case "BS":
                {
                    switch (GameManager.Inst.PlayerInfo.BS)
                    {
                        case "BS_2":
                            {
                                nextLvtext.text = bS_LVtext.text = "Lv. 2";
                                break;
                            }
                        case "BS_3":
                            {
                                nextLvtext.text = bS_LVtext.text = "Lv. 3";
                                break;
                            }
                    }
                    prevUI[0].SetActive(true);
                    nextUI[0].SetActive(true);
                    nextATKtext.text = bS_ATKtext.text = "ATK : " + (GameManager.Inst.PlayerInfo.BS_ATK).ToString();
                    nextHPtext.text = bS_HPtext.text = "HP : " + (GameManager.Inst.PlayerInfo.BS_HP).ToString();
                    break;
                }
            case "BA":
                {
                    switch (GameManager.Inst.PlayerInfo.BA)
                    {
                        case "BA_2":
                            {
                                nextLvtext.text = bA_LVtext.text = "Lv. 2";
                                break;
                            }
                        case "BA_3":
                            {
                                nextLvtext.text = bA_LVtext.text = "Lv. 3";
                                break;
                            }
                    }
                    prevUI[1].SetActive(true);
                    nextUI[1].SetActive(true);
                    nextATKtext.text = bA_ATKtext.text = "ATK : " + (GameManager.Inst.PlayerInfo.BA_ATK).ToString();
                    nextHPtext.text = bA_HPtext.text = "HP : " + (GameManager.Inst.PlayerInfo.BA_HP).ToString();
                    break;
                }
            case "BG":
                {
                    switch (GameManager.Inst.PlayerInfo.BG)
                    {
                        case "BG_2":
                            {
                                nextLvtext.text = bG_LVtext.text = "Lv. 2";
                                break;
                            }
                        case "BG_3":
                            {
                                nextLvtext.text = bG_LVtext.text = "Lv. 3";
                                break;
                            }
                    }
                    prevUI[2].SetActive(true);
                    nextUI[2].SetActive(true);
                    nextATKtext.text = bG_ATKtext.text = "ATK : " + (GameManager.Inst.PlayerInfo.BG_ATK).ToString();
                    nextHPtext.text = bG_HPtext.text = "HP : " + (GameManager.Inst.PlayerInfo.BG_HP).ToString();
                    break;
                }
            case "BW":
                {
                    switch (GameManager.Inst.PlayerInfo.BW)
                    {
                        case "BW_2":
                            {
                                nextLvtext.text = bW_LVtext.text = "Lv. 2";
                                break;
                            }
                        case "BW_3":
                            {
                                nextLvtext.text = bW_LVtext.text = "Lv. 3";
                                break;
                            }
                    }
                    prevUI[3].SetActive(true);
                    nextUI[3].SetActive(true);
                    nextATKtext.text = bW_ATKtext.text = "ATK : " + (GameManager.Inst.PlayerInfo.BW_ATK).ToString();
                    nextHPtext.text = bW_HPtext.text = "HP : " + (GameManager.Inst.PlayerInfo.BW_HP).ToString();
                    break;
                }
        }
    }

    public void UpgradeBtn(string unitType)
    {
        SoundManager.Inst.PlaySFX(SFX_Type.SFX_Upgrade);
        if (playerGold >= 100)
        {
            #region Upgrade
            if (unitType == "BS")
            {
                if (GameManager.Inst.PlayerInfo.BS == "BS_1")
                {
                    prevLvtext.text = "Lv. 1";
                    prevATKtext.text = "ATK : " + (GameManager.Inst.PlayerInfo.BS_ATK).ToString();
                    prevHPtext.text = "HP : " + (GameManager.Inst.PlayerInfo.BS_HP).ToString();
                    GameManager.Inst.PlayerInfo.BS = "BS_2";
                }
                else if (GameManager.Inst.PlayerInfo.BS == "BS_2")
                {
                    prevLvtext.text = "Lv. 2";
                    prevATKtext.text = "ATK : " + (GameManager.Inst.PlayerInfo.BS_ATK).ToString();
                    prevHPtext.text = "HP : " + (GameManager.Inst.PlayerInfo.BS_HP).ToString();
                    GameManager.Inst.PlayerInfo.BS = "BS_3";
                    upBtn[0].interactable = false;
                    upBtntext[0].text = "Max";
                    upBtntext[0].color = Color.red;
                }
            }
            else if (unitType == "BA")
            {
                if (GameManager.Inst.PlayerInfo.BA == "BA_1")
                {
                    prevLvtext.text = "Lv. 1";
                    prevATKtext.text = "ATK : " + (GameManager.Inst.PlayerInfo.BA_ATK).ToString();
                    prevHPtext.text = "HP : " + (GameManager.Inst.PlayerInfo.BA_HP).ToString();
                    GameManager.Inst.PlayerInfo.BA = "BA_2";
                }
                else if (GameManager.Inst.PlayerInfo.BA == "BA_2")
                {
                    prevLvtext.text = "Lv. 2";
                    prevATKtext.text = "ATK : " + (GameManager.Inst.PlayerInfo.BA_ATK).ToString();
                    prevHPtext.text = "HP : " + (GameManager.Inst.PlayerInfo.BA_HP).ToString();
                    GameManager.Inst.PlayerInfo.BA = "BA_3";
                    upBtn[1].interactable = false;
                    upBtntext[1].text = "Max";
                    upBtntext[1].color = Color.red;
                }
            }
            else if (unitType == "BG")
            {
                if (GameManager.Inst.PlayerInfo.BG == "BG_1")
                {
                    prevLvtext.text = "Lv. 1";
                    prevATKtext.text = "ATK : " + (GameManager.Inst.PlayerInfo.BG_ATK).ToString();
                    prevHPtext.text = "HP : " + (GameManager.Inst.PlayerInfo.BG_HP).ToString();
                    GameManager.Inst.PlayerInfo.BG = "BG_2";
                }
                else if (GameManager.Inst.PlayerInfo.BG == "BG_2")
                {
                    prevLvtext.text = "Lv. 2";
                    prevATKtext.text = "ATK : " + (GameManager.Inst.PlayerInfo.BG_ATK).ToString();
                    prevHPtext.text = "HP : " + (GameManager.Inst.PlayerInfo.BG_HP).ToString();
                    GameManager.Inst.PlayerInfo.BG = "BG_3";
                    upBtn[2].interactable = false;
                    upBtntext[2].text = "Max";
                    upBtntext[2].color = Color.red;
                }
            }
            else if (unitType == "BW")
            {
                if (GameManager.Inst.PlayerInfo.BW == "BW_1")
                {
                    prevLvtext.text = "Lv. 1";
                    prevATKtext.text = "ATK : " + (GameManager.Inst.PlayerInfo.BW_ATK).ToString();
                    prevHPtext.text = "HP : " + (GameManager.Inst.PlayerInfo.BW_HP).ToString();
                    GameManager.Inst.PlayerInfo.BW = "BW_2";
                }
                else if (GameManager.Inst.PlayerInfo.BW == "BW_2")
                {
                    prevLvtext.text = "Lv. 2";
                    prevATKtext.text = "ATK : " + (GameManager.Inst.PlayerInfo.BW_ATK).ToString();
                    prevHPtext.text = "HP : " + (GameManager.Inst.PlayerInfo.BW_HP).ToString();
                    GameManager.Inst.PlayerInfo.BW = "BW_3";
                    upBtn[3].interactable = false;
                    upBtntext[3].text = "Max";
                    upBtntext[3].color = Color.red;
                }
            }
            GameManager.Inst.PlayerInfo.gold -= 100;
            GameManager.Inst.SaveData();
            GameManager.Inst.UpgradeBunit();
            PlayerGold();
            goldtext.text = playerGold.ToString();
            UpgradeStat(unitType);
            UpgradeClickOpen();
            #endregion
        }
        else
        {
            scarceText();
        }
    }

    private void scarceText()
    {
        Color fromColor = Color.red;
        Color toColor = Color.red;
        fromColor.a = 0f;
        toColor.a = 1f;

        LeanTween.value(scarcetext.gameObject, updateValue, fromColor, toColor, 1f)
            .setEase(LeanTweenType.easeInOutQuad);
        LeanTween.value(scarcetext.gameObject, updateValue, toColor, fromColor, 1f)
            .setDelay(1f).setEase(LeanTweenType.easeInOutQuad);
    }

    private void updateValue(Color val)
    {
        scarcetext.color = val;
    }

    private void UpgradeClickOpen()
    {
        SoundManager.Inst.PlaySFX(SFX_Type.SFX_Click);
        LeanTween.scale(upgradeClickUI, new Vector3(1f, 1f, 1f), 0.7f).setEase(LeanTweenType.easeOutElastic);
    }

    public void UpgradeClickClose()
    {
        SoundManager.Inst.PlaySFX(SFX_Type.SFX_Click);
        LeanTween.scale(upgradeClickUI, new Vector3(0f, 0f, 0f), 0.7f);
    }
}
