using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Redcode.Pools;

public class UnitManager : MonoBehaviour
{
    private static UnitManager inst;
    public static UnitManager Inst
    {
        get { return inst; }
    }

    private PoolManager poolManager;

    private void Awake()
    {
        if (inst)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            inst = this;
            poolManager = GetComponent<PoolManager>();            
        }
    }

    public void SpawnUnit(int unitIndex)
    {
        SoundManager.Inst.PlaySFX(SFX_Type.SFX_Click);
        switch(unitIndex)
        {
            case 0:
                {
                    if (BattleScene.bData.battlePoint >= 10)
                    {
                        UnitBase newUnit = poolManager.GetFromPool<UnitBase>(unitIndex);
                        BattleScene.bData.battlePoint -= 10f;
                    }
                    break;
                }
            case 1:
                {
                    if (BattleScene.bData.battlePoint >= 15)
                    {
                        UnitBase newUnit = poolManager.GetFromPool<UnitBase>(unitIndex);
                        BattleScene.bData.battlePoint -= 15f;
                    }
                    break;
                }
            case 2:
                {
                    if (BattleScene.bData.battlePoint >= 15)
                    {
                        UnitBase newUnit = poolManager.GetFromPool<UnitBase>(unitIndex);
                        BattleScene.bData.battlePoint -= 15f;
                    }
                    break;
                }
            case 3:
                {
                    if (BattleScene.bData.battlePoint >= 25)
                    {
                        UnitBase newUnit = poolManager.GetFromPool<UnitBase>(unitIndex);
                        BattleScene.bData.battlePoint -= 25f;
                    }
                    break;
                }
            case 4:
                {
                    UnitBase newUnit = poolManager.GetFromPool<UnitBase>(unitIndex);
                    break;
                }

        }

        
    }

    public void ReturnPool(UnitBase unit)
    {
        poolManager.TakeToPool<UnitBase>(unit.PoolName, unit);
    }
}
