using UnityEngine;

public class DefenseUnitAnim : MonoBehaviour
{
    public EnemyTargetFInder targetFinder;

    public Transform partToRotate;

    private Transform target;

    public float rotationSpeed = 7f;

    private void Update()
    {
        //if we dont have a target we need to get target
        if(target == null)
        {
            target = targetFinder.Target;
        }

        //if we have target rotate the head to face the target
        if(target != null)
        {
            Vector3 dir = target.position - transform.position;

            Quaternion lookRotation = Quaternion.LookRotation(dir);

            Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, rotationSpeed * Time.deltaTime).eulerAngles;
            partToRotate.rotation = Quaternion.Euler(0f, rotation.y + 90f, 0f);

        }

        
    } //update

} //class
