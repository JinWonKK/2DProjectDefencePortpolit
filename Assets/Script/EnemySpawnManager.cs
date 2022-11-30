using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Redcode.Pools;

public class EnemySpawnManager : MonoBehaviour
{
    private int stage;

    private StageClass stageData;

    private PoolManager poolManager;

    private float spawnTime;
    
    private void Awake()
    {
        poolManager = GetComponent<PoolManager>();
    }

    public void InitStage()
    {
        stage = GameManager.Inst.PlayerInfo.initStage;
        GameManager.Inst.stageData.TryGetValue(stage, out stageData);
        BattleScene.bData.rCastleHP = stageData.castleHP;
        BattleScene.bData.bCastleHP = 100;
        EnemyStat();
        StartCoroutine(SpawnEnemy());
    }

    private void EnemyStat()
    {
        switch(stageData.unitLevel)
        {
            case 1:
                {
                    GameManager.Inst.PlayerInfo.RS = "RS_1";
                    GameManager.Inst.PlayerInfo.RA = "RA_1";
                    GameManager.Inst.PlayerInfo.RG = "RG_1";
                    GameManager.Inst.PlayerInfo.RW = "RW_1";
                    break;
                }
            case 2:
                {
                    GameManager.Inst.PlayerInfo.RS = "RS_2";
                    GameManager.Inst.PlayerInfo.RA = "RA_2";
                    GameManager.Inst.PlayerInfo.RG = "RG_2";
                    GameManager.Inst.PlayerInfo.RW = "RW_2";
                    break;
                }
            case 3:
                {
                    GameManager.Inst.PlayerInfo.RS = "RS_3";
                    GameManager.Inst.PlayerInfo.RA = "RA_3";
                    GameManager.Inst.PlayerInfo.RG = "RG_3";
                    GameManager.Inst.PlayerInfo.RW = "RW_3";
                    break;
                }
        }
        GameManager.Inst.UpgradeRunit();
    }

    private int rUnit;

    IEnumerator SpawnEnemy()
    {
        spawnTime = 10f;
        while(!BattleScene.bData.battleEnd)
        {
            rUnit = Random.Range(4, 8);
            yield return YieldInstructionCache.WaitForSeconds(spawnTime);
            UnitBase newUnit = poolManager.GetFromPool<UnitBase>(rUnit);
            spawnTime = Random.Range(6f, stageData.coolTime);
        }
    }
}
