using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Redcode.Pools;

public class EnemyUnit : MonoBehaviour, IUnitBase
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private UnitType unitType;
    [SerializeField]
    private int currentHP;
    [SerializeField]
    private int maxHP;
    [SerializeField]
    private int attackDamage;

    private AI_State state = AI_State.AI_Idle;
    private bool isAlive;
    private Vector3 move;

    private UnitBase unitBase;

    private void Awake()
    {
        unitBase = GetComponent<UnitBase>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        Transform t = transform.Find("AttackPivot");
        if (t != null)
            attackPivot = t.GetComponent<DrawGizmos>();
    }

    public void RUnitInit()
    {
        switch (unitType)
        {
            case UnitType.RS:
                {
                    maxHP = currentHP = GameManager.Inst.PlayerInfo.RS_HP;
                    attackDamage = GameManager.Inst.PlayerInfo.RS_ATK;
                    break;
                }
            case UnitType.RA:
                {
                    maxHP = currentHP = GameManager.Inst.PlayerInfo.RA_HP;
                    attackDamage = GameManager.Inst.PlayerInfo.RA_ATK;
                    break;
                }
            case UnitType.RG:
                {
                    maxHP = currentHP = GameManager.Inst.PlayerInfo.RG_HP;
                    attackDamage = GameManager.Inst.PlayerInfo.RG_ATK;
                    break;
                }
            case UnitType.RW:
                {
                    maxHP = currentHP = GameManager.Inst.PlayerInfo.RW_HP;
                    attackDamage = GameManager.Inst.PlayerInfo.RW_ATK;
                    break;
                }
        }

        isAlive = true;
        state = AI_State.AI_Move;
    }

    private void Update()
    {
        switch (state)
        {
            case AI_State.AI_Move:
                Move_State();
                break;
            case AI_State.AI_Attack:
                Attack_State();
                break;
            case AI_State.AI_Idle:
                Idle_State();
                break;
        }

        if (BattleScene.bData.battleEnd)
        {
            state = AI_State.AI_Idle;
        }
    }

    private Animator animator;

    private DrawGizmos attackPivot;
    [SerializeField]
    private LayerMask targetLayer;

    private List<GameObject> attackUnitList = new List<GameObject>();

    [SerializeField]
    private float attackRate;
    private float attackDelay = 0;

    private bool enemyAlive;

    public bool TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP < 1)
        {
            if(isAlive)
            {
                isAlive = false;
                StartCoroutine(OnDie());
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

    private Vector3 returnVec = new Vector3(0f, -10f, 0);
    private SpriteRenderer sr;

    IEnumerator OnHit()
    {
        //LeanTween.scale(this.gameObject, hitScale, 1f);
        sr.color = Color.red;
        yield return YieldInstructionCache.WaitForSeconds(0.1f);
        sr.color = Color.white;
        yield return YieldInstructionCache.WaitForSeconds(0.1f);
    }

    IEnumerator OnDie()
    {
        animator.SetTrigger("Die");
        // °ñµå ½×ÀÌ´Â ÇÔ¼ö ³Ö±â
        sr.color = Color.gray;
        yield return YieldInstructionCache.WaitForSeconds(0.5f);
        transform.position = returnVec;
        switch(unitType)
        {
            case UnitType.RS:
                {
                    BattleScene.bData.battlePoint += 3f;
                    break;
                }
            case UnitType.RA:
                {
                    BattleScene.bData.battlePoint += 5f;
                    break;
                }
            case UnitType.RG:
                {
                    BattleScene.bData.battlePoint += 5f;
                    break;
                }
            case UnitType.RW:
                {
                    BattleScene.bData.battlePoint += 10f;
                    break;
                }
        }
        UnitManager.Inst.ReturnPool(unitBase);
    }

    public void Move_State()
    {
        attackUnitList.Clear();
        animator.SetBool("Move", true);
        move.x = moveSpeed * Time.deltaTime;
        move.y = 0f;
        move.z = 0f;
        transform.Translate(move);
        enemyAlive = true;
        attackDelay = 0;
        CheckEnemy();
    }

    public void CheckEnemy()
    {
        Collider2D enemy =
            Physics2D.OverlapBox(attackPivot.transform.position,
                                 attackPivot.size,
                                 0,
                                 targetLayer);

        if (enemy != null)
        {
            attackUnitList.Add(enemy.gameObject);
            state = AI_State.AI_Attack;
        }
    }

    public void Attack_State()
    {
        Debug.Log(attackUnitList[0].gameObject);
        attackDelay -= Time.deltaTime;
        if (attackDelay <= 0f)
        {
            attackDelay = attackRate;
            if (attackUnitList[0] != null && enemyAlive)
            {
                animator.SetTrigger("Attack");
                AttackSound();
                ApplyDamage();
            }
            else if (!enemyAlive || attackUnitList[0] == null)
            {
                state = AI_State.AI_Move;
            }
        }
    }

    private void AttackSound()
    {
        switch (unitType)
        {
            case UnitType.RS:
                {
                    SoundManager.Inst.PlaySFX(SFX_Type.SFX_Sword);
                    break;
                }
            case UnitType.RA:
                {
                    SoundManager.Inst.PlaySFX(SFX_Type.SFX_Archer);
                    break;
                }
            case UnitType.RG:
                {
                    SoundManager.Inst.PlaySFX(SFX_Type.SFX_Guard);
                    break;
                }
            case UnitType.RW:
                {
                    SoundManager.Inst.PlaySFX(SFX_Type.SFX_Wizard);
                    break;
                }
        }

    }

    public void ApplyDamage()
    {
        if (attackUnitList[0].TryGetComponent<IUnitBase>(out IUnitBase unitBase))
        {
            enemyAlive = unitBase.TakeDamage(attackDamage);
            Debug.Log(enemyAlive);
        }
        else
            enemyAlive = false;
    }

    public void Idle_State()
    {
        StopAllCoroutines();
    }

}
