using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Redcode.Pools;

public enum ClassType
{
    CT_SwordMan,
    CT_Archer,
    CT_Guarder,
    CT_Wizard,
}

public enum UnitType
{
    BS,
    BA,
    BG,
    BW,
    RS,
    RA,
    RG,
    RW,
    RCASTLE,
    BCASTLE,
}

public enum AI_State
{
    AI_Idle,
    AI_Move,
    AI_Attack,
}

public class UnitBase : MonoBehaviour, IPoolObject
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private ClassType classType;
    [SerializeField]
    private UnitType unitType;

    [SerializeField]
    private string poolName;
    public string PoolName
    {
        get { return poolName; }
    }


    private SpriteRenderer sr;
    private PlayerUnit playerUnit;
    private EnemyUnit enemyUnit;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        playerUnit = GetComponent<PlayerUnit>();
        enemyUnit = GetComponent<EnemyUnit>();
    }
    

    #region POOLS

    public void OnCreatedInPool() 
    {
        //������Ʈ�� �����Ҷ� ȣ��
        //Debug.Log("������Ʈ ���� " + gameObject.name);
    }

    public void OnGettingFromPool() // ��������
    {
        if (moveSpeed < 0f) // ������
        {
            sr.color = Color.white;
            transform.position = new Vector3(4.3f, 0f, 0f);
            enemyUnit.RUnitInit();
        }
        else
        {
            sr.color = Color.white;
            transform.position = new Vector3(-4.3f, 0f, 0f);
            playerUnit.BUnitInit();
        }
    }
    #endregion

    
}
