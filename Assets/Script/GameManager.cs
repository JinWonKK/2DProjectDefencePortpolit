using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public enum SceneName
{
    IntroScene,
    TitleScene,
    LoadingScene,
    LobbyScene,
    BattleScene,
}

public class PlayerData
{
    public string userName;
    public int level;
    public string BS;
    public string BA;
    public string BG;
    public string BW;
    public int BS_HP;
    public int BS_ATK;
    public int BA_HP;
    public int BA_ATK;
    public int BG_HP;
    public int BG_ATK;
    public int BW_HP;
    public int BW_ATK;

    public string RS;
    public string RA;
    public string RG;
    public string RW;
    public int RS_HP;
    public int RS_ATK;
    public int RA_HP;
    public int RA_ATK;
    public int RG_HP;
    public int RG_ATK;
    public int RW_HP;
    public int RW_ATK;

    public int gold;
    public int clearStage;
    public int nextStage;
    public int initStage;

    public bool stage1;
    public bool stage2;
    public bool stage3;
    public bool stage4;
    public bool stage5;
    public bool stage6;

    public int stage1Star;
    public int stage2Star;
    public int stage3Star;
    public int stage4Star;
    public int stage5Star;
    public int stage6Star;

    public float bgm;
    public float sfx;

}

public class GameManager : Singleton<GameManager>
{
    #region LoadingLogic
    private SceneName nextScene;
    public SceneName NextScene
    {
        get { return nextScene; }
    }

    public void AsyncLoadNextScene(SceneName scene)
    {
        nextScene = scene;
        SceneManager.LoadScene(SceneName.LoadingScene.ToString());
    }
    #endregion

    private PlayerData pData;
    public PlayerData PlayerInfo
    {
        get { return pData; }
    }

    [SerializeField]
    private DefenceTable defenceTable;

    private List<TipClass> lobbyTip = new List<TipClass>();
    private List<TipClass> battleTip = new List<TipClass>();
    public Dictionary<int, StageClass> stageData = new Dictionary<int, StageClass>();

    private void Awake()
    {
        base.Awake();
        pData = new PlayerData();
        dataPath = Application.persistentDataPath + "/save";
        defenceTable = Resources.Load<DefenceTable>("DefenceTable");
        unitStats = GetComponent<UnitStats>();

        {
            for (int i = 0; i < defenceTable.tipData.Count; i++)
            {
                if (defenceTable.tipData[i].sceneName == SceneName.LobbyScene.ToString())
                    lobbyTip.Add(defenceTable.tipData[i]);
                else if (defenceTable.tipData[i].sceneName == SceneName.BattleScene.ToString())
                    battleTip.Add(defenceTable.tipData[i]);
            }
        }

        {
            for (int i = 0; i < defenceTable.stageData.Count; i++)
            {
                Debug.Log(i + " " + defenceTable.stageData[i].stage);
                stageData.Add(defenceTable.stageData[i].stage, defenceTable.stageData[i]);
            }
        }

        LoadData();
    }

    private int rand;

    public string GetTipMessage(SceneName scene)
    {
        string result = "";

        switch (scene)
        {
            case SceneName.LobbyScene:
                rand = Random.Range(0, lobbyTip.Count);
                result = lobbyTip[rand].tipText;
                break;
            case SceneName.BattleScene:
                rand = Random.Range(0, battleTip.Count);
                result = battleTip[rand].tipText;
                break;
        }
        return result;
    }

    #region saveDataLogic
    private string dataPath;

    public void SaveData() // 저장
    {
        string data = JsonUtility.ToJson(pData);
        File.WriteAllText(dataPath, data);
    }

    public bool LoadData() // 불러오기
    {
        if (File.Exists(dataPath))
        {
            string data = File.ReadAllText(dataPath);
            pData = JsonUtility.FromJson<PlayerData>(data);
            return true;
        }
        return false;
    }

    public bool CheckData() // 확인
    {
        if (File.Exists(dataPath))
        {
            return LoadData();
        }
        return false;
    }

    public void DeleteData() // 삭제
    {
        File.Delete(dataPath);
    }
    #endregion

    #region updateUserData
    public void UpdateUserName(string newUserName)
    {
        pData.userName = newUserName;
        SaveData();
    }

    private UnitStats unitStats;

    public void InitData()
    {
        pData.BS = "BS_1";
        pData.BA = "BA_1";
        pData.BG = "BG_1";
        pData.BW = "BW_1";

        pData.RS = "RS_1";
        pData.RA = "RA_1";
        pData.RG = "RG_1";
        pData.RW = "RW_1";

        pData.initStage = 1;
        pData.clearStage = 0;
        pData.nextStage = pData.clearStage + 1;
        
        pData.stage1 = false;
        pData.stage2 = false;
        pData.stage3 = false;
        pData.stage4 = false;
        pData.stage5 = false;
        pData.stage6 = false;

        pData.stage1Star = 0;
        pData.stage2Star = 0;
        pData.stage3Star = 0;
        pData.stage4Star = 0;
        pData.stage5Star = 0;
        pData.stage6Star = 0;

        pData.gold = 100;

        pData.bgm = 1f;
        pData.sfx = 1f;

        SaveData();

        Debug.Log("초기 Unit데이터 입력" + GameManager.Inst.PlayerInfo.BS);
        unitStats.SetDictionary();
    }

    public void UpgradeBunit()
    {
        unitStats.BUnitStats();
    }

    public void UpgradeRunit()
    {
        unitStats.RUnitStats();
    }

    #endregion



}
