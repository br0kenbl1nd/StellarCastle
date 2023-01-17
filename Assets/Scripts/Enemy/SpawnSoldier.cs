using UnityEngine;

public class SpawnSoldier : MonoBehaviour
{
    [SerializeField]
    private GameObject soldier;

    [SerializeField]
    private float spawnInterval;
    private float spawnIntervalCount;

    private void Start()
    {
        spawnIntervalCount = 0f;
        
    } //start

    private void Update()
    {

        if(spawnIntervalCount <= 0f)
        {
            Instantiate(soldier, transform.position, transform.rotation);
            spawnIntervalCount = spawnInterval;
        }
        spawnIntervalCount -= Time.deltaTime;
        
    } //update

} //class
