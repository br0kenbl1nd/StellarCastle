using UnityEngine;

[RequireComponent(typeof(UnitStats))]
public class EnemyMovement : MonoBehaviour
{
    UnitStats unitStats;
    EnemyTargetFInder targetFinder;

    private Transform target;

    public float rotationSpeed = 720f;

    private bool canMove;
    public bool CanMove
    {
        get { return canMove; }
        private set { canMove = value; }
    }

    private void Start()
    {
        //get the target finder compononet
        targetFinder = gameObject.GetComponent<EnemyTargetFInder>();
        unitStats = GetComponent<UnitStats>();
        //find the target as soon as the enemy spawns
        target = targetFinder.Target;    
    } //start

    private void Update()
    {
        //update nearest target
        target = targetFinder.Target;

        //update can move based on distance from target
        UpdateCanMove();

        //if the enemy can move, it should move towards its target
        if(canMove == true)
        {
            MoveToTarget();
        }

        
    } //update


    void UpdateCanMove()
    {
        if(target != null)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, target.position);
            if(distanceToEnemy > unitStats.AttackRange)
            {
                canMove = true;
            }
            else
            {
                canMove = false;
            }
        }
        else
        {
            canMove = false;
        }

    } //update can move

    void MoveToTarget()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * unitStats.Speed * Time.deltaTime, Space.World);

        if(dir != Vector3.zero)
        {
        Quaternion toRotation = Quaternion.LookRotation(dir, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }


    } //move to target


} //class
