using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStats : MonoBehaviour
{
    /*private void Awake()
    {
        SetDictionary();
    }*/

    #region UnitDataLogic
    [SerializeField]
    private DefenceTable defenceTable;
    [SerializeField]
    public Dictionary<string, BUnitClass> bUnitData = new Dictionary<string, BUnitClass>();
    [SerializeField]
    public Dictionary<string, RUnitClass> rUnitData = new Dictionary<string, RUnitClass>();

    public void SetDictionary()
    {
        bUnitData.Clear();
        rUnitData.Clear();
        {
            for (int i = 0; i < defenceTable.BUnit.Count; i++)
            {
                bUnitData.Add(defenceTable.BUnit[i].unitName, defenceTable.BUnit[i]);
            }
            BUnitStats();
        }

        {
            for (int i = 0; i < defenceTable.RUnit.Count; i++)
            {
                rUnitData.Add(defenceTable.RUnit[i].unitName, defenceTable.RUnit[i]);
            }
            RUnitStats();
        }


    }



    private BUnitClass bUnit;
    private RUnitClass rUnit;
    public void BUnitStats()
    {
        bUnitData.TryGetValue(GameManager.Inst.PlayerInfo.BS, out bUnit);
        SetUnitStats(UnitType.BS, bUnit.unitHP, bUnit.unitATK);
        bUnitData.TryGetValue(GameManager.Inst.PlayerInfo.BA, out bUnit);
        SetUnitStats(UnitType.BA, bUnit.unitHP, bUnit.unitATK);
        bUnitData.TryGetValue(GameManager.Inst.PlayerInfo.BG, out bUnit);
        SetUnitStats(UnitType.BG, bUnit.unitHP, bUnit.unitATK);
        bUnitData.TryGetValue(GameManager.Inst.PlayerInfo.BW, out bUnit);
        SetUnitStats(UnitType.BW, bUnit.unitHP, bUnit.unitATK);
    }

    public void RUnitStats()
    {
        rUnitData.TryGetValue(GameManager.Inst.PlayerInfo.RS, out rUnit);
        SetUnitStats(UnitType.RS, rUnit.unitHP, rUnit.unitATK);
        rUnitData.TryGetValue(GameManager.Inst.PlayerInfo.RA, out rUnit);
        SetUnitStats(UnitType.RA, rUnit.unitHP, rUnit.unitATK);
        rUnitData.TryGetValue(GameManager.Inst.PlayerInfo.RG, out rUnit);
        SetUnitStats(UnitType.RG, rUnit.unitHP, rUnit.unitATK);
        rUnitData.TryGetValue(GameManager.Inst.PlayerInfo.RW, out rUnit);
        SetUnitStats(UnitType.RW, rUnit.unitHP, rUnit.unitATK);
    }

    public void SetUnitStats(UnitType unitType, int hp, int atk)
    {
        switch(unitType)
        {
            case UnitType.BS:
                {
                    GameManager.Inst.PlayerInfo.BS_HP = hp;
                    GameManager.Inst.PlayerInfo.BS_ATK = atk;
                    break;
                }
            case UnitType.BA:
                {
                    GameManager.Inst.PlayerInfo.BA_HP = hp;
                    GameManager.Inst.PlayerInfo.BA_ATK = atk;
                    break;
                }
            case UnitType.BG:
                {
                    GameManager.Inst.PlayerInfo.BG_HP = hp;
                    GameManager.Inst.PlayerInfo.BG_ATK = atk;
                    break;
                }
            case UnitType.BW:
                {
                    GameManager.Inst.PlayerInfo.BW_HP = hp;
                    GameManager.Inst.PlayerInfo.BW_ATK = atk;
                    break;
                }

            case UnitType.RS:
                {
                    GameManager.Inst.PlayerInfo.RS_HP = hp;
                    GameManager.Inst.PlayerInfo.RS_ATK = atk;
                    Debug.Log(GameManager.Inst.PlayerInfo.RS_ATK);
                    Debug.Log(GameManager.Inst.PlayerInfo.RS_HP);
                    break;
                }
            case UnitType.RA:
                {
                    GameManager.Inst.PlayerInfo.RA_HP = hp;
                    GameManager.Inst.PlayerInfo.RA_ATK = atk;
                    break;
                }
            case UnitType.RG:
                {
                    GameManager.Inst.PlayerInfo.RG_HP = hp;
                    GameManager.Inst.PlayerInfo.RG_ATK = atk;
                    break;
                }
            case UnitType.RW:
                {
                    GameManager.Inst.PlayerInfo.RW_HP = hp;
                    GameManager.Inst.PlayerInfo.RW_ATK = atk;
                    break;
                }
        }
        GameManager.Inst.SaveData();
    }

    #endregion
}
