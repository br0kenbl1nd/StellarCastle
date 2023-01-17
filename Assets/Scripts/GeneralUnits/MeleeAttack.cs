using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public UnitStats unitStats;
    public EnemyTargetFInder targetFinder;

    private bool canAttack;
    public bool CanAttack
    {
        get { return canAttack; }
        private set { canAttack = value; }
    }

    //attack speed calculating variable
    private float attackSpeedCount;

    private void Start()
    {
        attackSpeedCount = 1f / unitStats.StartAttackSpeed;
    } //start

    private void Update()
    {
        //if we have a target check if we are in range of the target to attack
        if (targetFinder.Target != null)
        {
            CheckAttackRange();
        }
        else
        {
            canAttack = false;
        }

        //if we are in range we attack the target
        if (targetFinder.Target != null)
        {
            if (canAttack == true)
            {
                //if attackspeedcount is less than 0, we perform an attack
                if (attackSpeedCount <= 0f)
                {
                    //perform an attack
                    AttackTarget(targetFinder.Target);
                    //reset the attackspeed count
                    attackSpeedCount = 1f / unitStats.AttackSpeed;
                }
            }

            //reduce attackspeedcount
            attackSpeedCount -= Time.deltaTime;
        }
        
    } //update

    void CheckAttackRange()
    {
        //finding the distance between enemy and object
        float distanceToTarget = Vector3.Distance(transform.position, targetFinder.Target.position);
        if(distanceToTarget < unitStats.AttackRange)
        {
            canAttack = true;
        }
        else
        {
            canAttack = false;
        }

    } //check attack range

    void AttackTarget(Transform _target)
    {
        Health targetHealth = _target.gameObject.GetComponent<Health>();
        if(targetHealth != null)
        {
            targetHealth.TakeDamage(unitStats.Damage);
        }

    }//attack target

} //class
