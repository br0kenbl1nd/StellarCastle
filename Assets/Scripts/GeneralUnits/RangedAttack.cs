using UnityEngine;

[RequireComponent(typeof(UnitStats))]
[RequireComponent(typeof(EnemyTargetFInder))]
public class RangedAttack : MonoBehaviour
{
    public UnitStats unitStats;
    public EnemyTargetFInder targetFinder;
    public Transform firePoint;

    private bool canAttack;
    public bool CanAttack
    {
        get { return canAttack; }
        private set { canAttack = value; }
    }

    //attack speed counting variable
    private float attackSpeedCount;

    private void Start()
    {
        attackSpeedCount = 0f;
        
    } //start

    private void Update()
    {
        //if we have a target object starts attacking
        if(targetFinder.Target != null)
        {
            if (CheckRange())
            {
                canAttack = true;
            }
            else
            {
                canAttack = false;
            }
        }
        else
        {
            canAttack = false;
        }

        if (canAttack == true)
        {
            //if can attack is true attack cycle functions
            if (attackSpeedCount <= 0f)
            {
                //attack target
                AttackTarget(targetFinder.Target);
                //reset the attack speed count
                attackSpeedCount = 1f / unitStats.AttackSpeed;

            }
            attackSpeedCount -= Time.deltaTime;
        }
        
    } //update

    bool CheckRange()
    {
        float distanceToTarget = Vector3.Distance(transform.position, targetFinder.Target.position);

        if(distanceToTarget <= unitStats.AttackRange)
        {
            return true;
        }
        else
        {
            return false;
        }
         
    } //check range

    void AttackTarget(Transform _target)
    {
        GameObject _b = (GameObject)Instantiate(unitStats.Bullet, firePoint.position, Quaternion.identity);
        Bullet bullet = _b.GetComponent<Bullet>();
        bullet.Target = _target;
        bullet.Damage = unitStats.Damage;
    } //attack target


} //class
