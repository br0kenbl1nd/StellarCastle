using UnityEngine;

public class Expire : MonoBehaviour
{

    public float lifeTime;

    private float count;

    private void Start()
    {
        count = 0f;
        
    } //start

    private void Update()
    {
        count += Time.deltaTime;

        if(count >= lifeTime)
        {
            Destroy(gameObject);
        }
        
    }

}
