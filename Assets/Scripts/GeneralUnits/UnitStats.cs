using UnityEngine;

public class UnitStats : MonoBehaviour
{

    [SerializeField]
    private float startHealth;
    public float StartHealth
    {
        get { return startHealth; }
    }
    private float health;
    public float Health
    {
        get { return health; }
        set { health = value; }
    }

    [SerializeField]
    private float startAttackRange;
    public float StartAttackRange
    {
        get { return attackRange; }
    }
    private float attackRange;
    public float AttackRange
    {
        get { return attackRange; }
        private set { attackRange = value; }
    }

    [SerializeField]
    private float targetSeekingRange;
    public float TargetSeekingRange
    {
        get { return targetSeekingRange; }
        private set { targetSeekingRange = value; }
    }

    [SerializeField]
    private float startSpeed;
    public float StartSpeed
    {
        get { return startSpeed; }
    }
    private float speed;
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    [SerializeField]
    private float startDamage;
    public float StartDamage
    {
        get { return startDamage; }
    }
    private float damage;
    public float Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    [SerializeField]
    private float startAttackSpeed;
    public float StartAttackSpeed
    {
        get { return startAttackSpeed; }
    }
    private float attackSpeed;
    public float AttackSpeed
    {
        get { return attackSpeed; }
        set { attackSpeed = value; }
    }

    [SerializeField]
    private GameObject bullet;
    public GameObject Bullet
    {
        get { return bullet; }
        set { bullet = value; }
    }

    private void Start()
    {
        health = startHealth;
        speed = startSpeed;
        attackSpeed = startAttackSpeed;
        attackRange = startAttackRange;
        damage = startDamage;
        
    } //start

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, targetSeekingRange);
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.green;
    }

} //class
