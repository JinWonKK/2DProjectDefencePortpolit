using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IUnitBase
{
    public bool TakeDamage(int damage);
    public void Move_State();
    public void CheckEnemy();
    public void Attack_State();
    public void ApplyDamage();
}

public class PlayerUnit : MonoBehaviour, IUnitBase
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
        animator = GetComponent<Animator>();
        unitBase = GetComponent<UnitBase>();
        sr = GetComponent<SpriteRenderer>();
        Transform t = transform.Find("AttackPivot");
        if (t != null)
            attackPivot = t.GetComponent<DrawGizmos>();
    }

    public void BUnitInit()
    {
        switch (unitType)
        {
            case UnitType.BS:
                {
                    maxHP = currentHP = GameManager.Inst.PlayerInfo.BS_HP;
                    attackDamage = GameManager.Inst.PlayerInfo.BS_ATK;
                    break;
                }
            case UnitType.BA:
                {
                    maxHP = currentHP = GameManager.Inst.PlayerInfo.BA_HP;
                    attackDamage = GameManager.Inst.PlayerInfo.BA_ATK;
                    break;
                }
            case UnitType.BG:
                {
                    maxHP = currentHP = GameManager.Inst.PlayerInfo.BG_HP;
                    attackDamage = GameManager.Inst.PlayerInfo.BG_ATK;
                    break;
                }
            case UnitType.BW:
                {
                    maxHP = currentHP = GameManager.Inst.PlayerInfo.BW_HP;
                    attackDamage = GameManager.Inst.PlayerInfo.BW_ATK;
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
    private float attackRate = 2f;
    private float attackDelay = 0;

    private bool enemyAlive;

    public bool TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP < 1)
        {
            if (isAlive)
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


    private SpriteRenderer sr;

    IEnumerator OnHit()
    {
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
            else if (!enemyAlive ||attackUnitList[0] == null)
            {
                state = AI_State.AI_Move;
            }
        }
    }

    private void AttackSound()
    {
        switch(unitType)
        {
            case UnitType.BS:
                {
                    SoundManager.Inst.PlaySFX(SFX_Type.SFX_Sword);
                    break;
                }
            case UnitType.BA:
                {
                    SoundManager.Inst.PlaySFX(SFX_Type.SFX_Archer);
                    break;
                }
            case UnitType.BG:
                {
                    SoundManager.Inst.PlaySFX(SFX_Type.SFX_Guard);
                    break;
                }
            case UnitType.BW:
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
