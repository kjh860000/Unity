using UnityEngine;
using UnityEngine.UI;

public abstract class MonsterCore : MonoBehaviour, IDamageable
{
    public enum MonsterState { IDLE, PATROL, TRACE, ATTACK}
    public MonsterState monsterState = MonsterState.IDLE;

    public ItemManager itemManager;

    protected Animator animator;
    protected Rigidbody2D monsterRb;
    protected Collider2D monsterColl;
    [SerializeField] public Image hpBar;

    public Transform target;

    public float hp;
    public float currHp;
    public float speed;
    public float attackTime;
    public float atkDamage;

    protected float moveDir;
    protected float targetDist;

    protected bool isTrace;
    private bool isDead;


    protected virtual void Init(float hp, float speed, float attackTime, float atkDamage)
    {
        this.hp = hp;
        this.speed = speed;
        this.attackTime = attackTime;
        this.atkDamage = atkDamage;

        itemManager = FindFirstObjectByType<ItemManager>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        animator = GetComponent<Animator>();
        monsterRb = GetComponent<Rigidbody2D>();
        monsterColl = GetComponent<Collider2D>();

        currHp = hp;
        hpBar.fillAmount = currHp / hp;
    }
    void Update()
    {
        if (isDead)
            return;

        switch (monsterState)
        {
            case MonsterState.IDLE:
                Idle();
                break;
            case MonsterState.PATROL:
                Patrol();
                break;
            case MonsterState.TRACE:
                Trace();
                break;
            case MonsterState.ATTACK:
                Attack();
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Return"))
        {
            moveDir *= -1;
            transform.localScale = new Vector3(moveDir, 1, 1);
        }

        if(other.GetComponent<IDamageable>() != null)
        {
            other.GetComponent<IDamageable>().TakeDamage(atkDamage);
        }
    }
    public abstract void Idle();
    public abstract void Patrol();
    public abstract void Trace();
    public abstract void Attack();

    public void ChangeState(MonsterState newState)
    {
        if(monsterState != newState)
            monsterState = newState;
    }

    public void TakeDamage(float damage)
    {
        currHp -= damage;

        hpBar.fillAmount = currHp / hp;

        if (currHp <= 0f)
            Death();
    }

    public void Death()
    {
        isDead = true;
        animator.SetTrigger("Death");
        monsterColl.enabled = false;
        monsterRb.gravityScale = 0f;

        int itemCount = Random.Range(0, 3);
        for (int i=0; i<itemCount; i++)
        {
            itemManager.DropItem(transform.position);
        }
    }
}
