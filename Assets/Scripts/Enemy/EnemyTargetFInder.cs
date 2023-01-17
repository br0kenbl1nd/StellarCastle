using UnityEngine;

[RequireComponent(typeof(UnitStats))]
public class EnemyTargetFInder : MonoBehaviour
{
    public UnitStats unitStats;

    private string TargetTag;

    private Transform target;
    public Transform Target
    {
        get { return target; }
        private set { target = value; }
    }

    private void Awake()
    {
        if(gameObject.CompareTag("Good"))
        {
            TargetTag = "Bad";
        }
        else
        {
            TargetTag = "Good";
        }

        unitStats = GetComponent<UnitStats>();
    } //start

    private void Update()
    {
        FindNearestTarget();
        
    } //update

    //call only from the attached gameobject
    private void FindNearestTarget()
    {
        //find all the ally good buildings in the map
        GameObject[] targets = GameObject.FindGameObjectsWithTag(TargetTag);
        //store the shortest distance
        float shortestDistance = Mathf.Infinity;
        //store the current nearest target
        GameObject nearestTarget = null;

        //loop through them to find the nearest one
        foreach (GameObject target in targets)
        {
            float distanceToEnemy = Vector3.Distance(target.transform.position, transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestTarget = target;
            }
        }

        //after looping if we have a target, we set current target to that target
        if (nearestTarget != null && shortestDistance <= unitStats.TargetSeekingRange)
        {
            target = nearestTarget.transform;
        }
        else
        {
            target = null;
        }

    } //find nearest target

} //class
