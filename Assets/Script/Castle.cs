using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Castle : MonoBehaviour, IUnitBase
{
    [SerializeField]
    private int currentHP;
    [SerializeField]
    private int maxHP;
    [SerializeField]
    private UnitType unitType;

    private bool isAlive;
    private SpriteRenderer sr;

    [SerializeField]
    private BattleEnd battleEnd;

    [SerializeField]
    private TextMeshProUGUI redHptext;
    [SerializeField]
    private TextMeshProUGUI blueHptext;



    private void Awake()
    {
        InitCastle();
    }

    public void InitCastle()
    {
        sr = GetComponent<SpriteRenderer>();
        isAlive = true;

        switch(unitType)
        {
            case UnitType.RCASTLE:
                {
                    currentHP = maxHP = BattleScene.bData.rCastleHP;
                    redHptext.text = BattleScene.bData.rCastleHP.ToString();
                    break;
                }
            case UnitType.BCASTLE:
                {
                    currentHP = maxHP = 100;
                    blueHptext.text = "100";
                    break;
                }
        }
    }

    public bool TakeDamage(int damage)
    {
        Debug.Log("¸Â±äÇÔ");
        currentHP -= damage;
        switch (unitType)
        {
            case UnitType.RCASTLE:
                {
                    if (currentHP < 0)
                        currentHP = 0;
                    BattleScene.bData.rCastleHP = currentHP;
                    redHptext.text = BattleScene.bData.rCastleHP.ToString();
                    break;
                }
            case UnitType.BCASTLE:
                {
                    if (currentHP < 0)
                        currentHP = 0;
                    BattleScene.bData.bCastleHP = currentHP;
                    blueHptext.text = BattleScene.bData.bCastleHP.ToString();
                    break;
                }
        }

        if (currentHP < 1)
        {
            if (isAlive)
            {
                isAlive = false;
                StartCoroutine(OnBreak(unitType));
            }
            return false;
        }
        else
        {
            StopCoroutine(OnHit());
            StartCoroutine(OnHit());
            return true;
        }
    }

    IEnumerator OnHit()
    {

        sr.color = Color.red;
        yield return YieldInstructionCache.WaitForSeconds(0.1f);
        sr.color = Color.white;
        yield return YieldInstructionCache.WaitForSeconds(0.1f);
    }

    IEnumerator OnBreak(UnitType unitType)
    {
        BattleScene.bData.battleEnd = true;
        switch(unitType)
        {
            case UnitType.RCASTLE:
                {
                    battleEnd.SetBattleEndUI();
                    break;
                }
            case UnitType.BCASTLE:
                {
                    battleEnd.LoseUI();
                    break;
                }
        }    
        Destroy(gameObject);
        yield return YieldInstructionCache.WaitForSeconds(0.1f);
    }

    public void Move_State()
    {
        //throw new System.NotImplementedException();
    }

    public void CheckEnemy()
    {
        //throw new System.NotImplementedException();
    }

    public void Attack_State()
    {
        //throw new System.NotImplementedException();
    }

    public void ApplyDamage()
    {
        //throw new System.NotImplementedException();
    }
}
