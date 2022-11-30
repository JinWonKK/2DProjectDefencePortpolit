using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class BattleData
{
    public float castleLevel;
    public float battlePoint;
    public int rCastleHP;
    public int bCastleHP;
    public bool battleEnd;
    public string battleTime;
    public int clearMinute;
}

public class BattleScene : MonoBehaviour
{
    private static BattleData battleData;
    public static BattleData bData
    {
        get { return battleData; }
    }

    [SerializeField]
    private TextMeshProUGUI pointText;

    private DateTime prevTime;
    [SerializeField]
    private TextMeshProUGUI timeText;
    private TimeSpan elapsed;
    private int second;
    private int Minute;

    [SerializeField]
    private FadeInOut fade;

    [SerializeField]
    private TextMeshProUGUI castlePoint;
    [SerializeField]
    private TextMeshProUGUI castleLvText;

    private int castleUpPrice;

    [SerializeField]
    private List<Button> unitBtn = new List<Button>();

    private List<int> unitPrice = new List<int>(5);

    [SerializeField]
    private Button castleBtn;

    private EnemySpawnManager enemySpawnManager;

    /*[SerializeField]
    private TextMeshProUGUI bCastleHP;*/

    private void Awake()
    {
        enemySpawnManager = GetComponent<EnemySpawnManager>();
        SoundManager.Inst.ChangeBGM(BGM_Type.BGM_Battle);
        battleData = new BattleData();
        UnitPriceInit();
        BDataInit();
        //bCastleHP.text = battleData.bCastleHP.ToString();
        enemySpawnManager.InitStage();
        prevTime = DateTime.Now;
        fade.Fade_InOut(true, 3f);
    }

    private void BDataInit()
    {
        battleData.castleLevel = 1f;
        castleUpPrice = 20;
        castlePoint.text = castleUpPrice.ToString();
        castleLvText.text = "Lv. 1";
        battleData.battlePoint = 10; // Å×½ºÆ®
        battleData.battleEnd = false;
        battleData.clearMinute = 0;
    }

    private void UnitPriceInit()
    {
        unitPrice.Add(10);
        unitPrice.Add(15);
        unitPrice.Add(15);
        unitPrice.Add(25);
    }

    private void Update()
    {
        if(!battleData.battleEnd)
        {
            battleData.battlePoint += Time.deltaTime * battleData.castleLevel;
            pointText.text = ((int)battleData.battlePoint).ToString();
            PlayTime();
            BtnInteractable();
        }
    }

    private void PlayTime()
    {
        elapsed = (DateTime.Now - prevTime);
        second = elapsed.Seconds;
        battleData.clearMinute = elapsed.Minutes;
        battleData.battleTime = battleData.clearMinute.ToString() + " : " + second.ToString();
        timeText.text = battleData.battleTime;
    }

    private void BtnInteractable()
    {
        if (battleData.battlePoint < castleUpPrice || battleData.castleLevel == 3f)
            castleBtn.interactable = false;
        else
            castleBtn.interactable = true;
    
        for(int i = 0; i < unitBtn.Count; i++)
        {
            if (battleData.battlePoint >= unitPrice[i])
                unitBtn[i].interactable = true;
            else
                unitBtn[i].interactable = false;
        }
    }

    public void CastleUpgrade()
    {
        SoundManager.Inst.PlaySFX(SFX_Type.SFX_Click);
        if(battleData.battlePoint >= castleUpPrice)
        {
            battleData.castleLevel += 1f;
            battleData.battlePoint -= castleUpPrice;
            castleUpPrice += 30;
            if (battleData.castleLevel == 2f)
            {
                castleLvText.text = "Lv. 2";
                castlePoint.text = castleUpPrice.ToString();
            }
            else if (battleData.castleLevel == 3f)
            {
                castleLvText.text = "Lv. 3";
                castlePoint.text = "Max";
            }
                
        }
    }
}
