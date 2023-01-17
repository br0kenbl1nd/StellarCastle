using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;
    public Transform Target
    {
        get { return target; }
        set { target = value; }
    }

    public float ammoSpeed;

    private float damage;
    public float Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    private void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
        }
        else
        {
            //check distance to target
            float distanceToTarget = Vector3.Distance(transform.position, target.position);
            if(distanceToTarget >= 1f)
            {
                MoveToTarget();
            }
            else
            {
                HitTarget();
                Destroy(gameObject);
            }
        }


    } //update

    void MoveToTarget()
    {
        Vector3 dir = (target.position + new Vector3(0f, 0.3f, 0f)) - transform.position;
        transform.Translate(dir.normalized * ammoSpeed * Time.deltaTime, Space.World);

    } //move to target

    void HitTarget()
    {
        Health health = target.gameObject.GetComponent<Health>();
        if(health != null)
        {
            health.TakeDamage(damage);
        }

    } //hit target

} //class
