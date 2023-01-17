using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [Header("Inital delay")]
    [SerializeField]
    private float initialStepCount;

    [Header("Prefabs of enemies")]
    [SerializeField]
    private GameObject enemy1Prefab;

    [SerializeField]
    private GameObject enemyBoss1Prefab;

    [Header("Wave characteristics")]
    public float amplitude;
    public float frequency;
    public float step;
    public float timeBetweenEnemies;

    //variable to count the time between each step
    private float stepTimeCount;
    //variable to count the number of enemies to spawn in each step
    private float numberOfEnemies;
    //variable to keep track of the step
    private int stepNumber;
    //keep track of reversal of waves
    private bool reverse;

    private void Start()
    {
        //the wave starts with the first step
        stepNumber = 1;
        //the step time is calculated
        stepTimeCount = initialStepCount;      

    } //start

    private void Update()
    {
        //spawn wave based on step time
        //reduce step time count
        stepTimeCount -= Time.deltaTime;
        //if steptimecount is less than 0 its time to spawn a wave (Step)
        if(stepTimeCount <= 0f)
        {

            //number of enemies is set for the first step
            numberOfEnemies = (amplitude / step) + (Mathf.Abs(stepNumber) - 1);
            //spawn wave
            StartCoroutine(SpawnWave());
            //set the step time count 
            stepTimeCount = frequency / step;
            //increase or decrease step number
            if(reverse)
            {
                stepNumber -= 1;
            }
            else
            {
                stepNumber += 1;
            }           
        }

        //if the step number equals total number of steps the wave should be reversed
        if(stepNumber == step)
        {
            reverse = true;
        }

        if(stepNumber == -step)
        {
            reverse = false;
        }
        
    } //update

    IEnumerator SpawnWave()
    {
        for(int i = 0; i < numberOfEnemies; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenEnemies);
        }
        if (step - 1 == Mathf.Abs(stepNumber))
        {
            
            SpawnBoss();
        }
    } //spawnwave

    void SpawnEnemy()
    {
        Instantiate(enemy1Prefab, transform.position, transform.rotation);
    } //spawnenemy

    void SpawnBoss()
    {
        Instantiate(enemyBoss1Prefab, transform.position, transform.rotation);
    } //spawn boss
   

} //class
