using UnityEngine;

public class AOEDamage : MonoBehaviour
{

    [SerializeField]
    private float aoeDamage;

    [SerializeField]
    private float range;

    [SerializeField]
    private string targetTag = "Bad";

    private void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(targetTag);

        foreach(GameObject enemy in enemies)
        {
            //check distance
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if(distance <= range)
            {
                //if the enemy is with in the range deal damage every frame
                Health _health = enemy.GetComponent<Health>();
                _health.TakeDamage(aoeDamage * Time.deltaTime);
            }
        }

    } //update


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, range);
        
    } //draw gizmos

} //class
