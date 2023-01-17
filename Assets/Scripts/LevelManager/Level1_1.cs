using UnityEngine;

public class Level1_1 : MonoBehaviour
{
    //spawn specified number of enemies and end the game when those enemies die
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private int noOfEnemies;

    [SerializeField]
    private float spawnInterval;
    private float spawnIntervalCount;

    private GameObject[] enemies;

    private int enemyCount;

    //base
    [Header("Base")]
    [SerializeField]
    private GameObject playerBase;

    //UI 
    [Header("UI")]
    [SerializeField]
    private GameWon gameWon;
    [SerializeField]
    private GameOver gameOver;
    [SerializeField]
    private GamePaused gamePausedUI;

    private void Start()
    {
        enemyCount = 0;
        spawnIntervalCount = 0f;
        enemies = new GameObject[noOfEnemies];
    } //start

    private void Update()
    {
        //spawn the specified number of enemies
        if(spawnIntervalCount <= 0f)
        {
            if (enemyCount <= noOfEnemies)
            {
                SpawnEnemy(enemyCount);
                enemyCount += 1;
                spawnIntervalCount = spawnInterval;
            }
        }

        spawnIntervalCount -= Time.deltaTime;

        // If the number of spawned units is more than 5 check if any enemies are alive
        if(enemyCount >= 5)
        {
            //to keep track of dead enemies
            int count = 0;
            //check if all the enemies in the matrix are dead
            for (int i = 0; i < noOfEnemies; i++)
            {               
                if(CheckIfDead(enemies[i]))
                {
                    count += 1;
                }
            }

            //if the number of dead enemies is equal to the total number enemies spawned, we end the game
            if(count >= noOfEnemies)
            {
                //Game won
                GameWon();
            }

        }

        //if base is destroyed the game is over
        if(playerBase == null)
        { 
            GameOver();
        }

    } //update

    void SpawnEnemy(int _index)
    {
        //spawn in  spawn point
        enemies[_index] = (GameObject)Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

    } //spawn enemy

    bool CheckIfDead(GameObject _enemy)
    {
        if(_enemy == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    } //check if alive

    void GameWon()
    {
        Cursor.lockState = CursorLockMode.None;
        gameWon.PlayerGameWon();
    } //game won

    void GameOver()
    {
        gameOver.PlayerGameOver();
    } //game over

} //class
