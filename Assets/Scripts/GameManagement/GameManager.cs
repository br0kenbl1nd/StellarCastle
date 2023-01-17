using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerBase;

    public GameOver gameOver;
    public GamePaused gamePaused;
    public GameWon gameWon;
    public UIManager uiManager;

    public GameObject[] enemySpawners;

    private void Update()
    {
        if (playerBase == null)
        {
            GameOver();
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            GamePaused();
        }

        if(CheckForEnemySpawners() <= 0)
        {
            GameWon();
        }

    } //update

    int CheckForEnemySpawners()
    {
        int count = 0;

        foreach(GameObject spawner in enemySpawners)
        {
            if (spawner != null)
            {
                count += 1;
            }
        }

        return count;
    }

    void GameOver()
    {
        gameOver.PlayerGameOver();

    } //game over

    void GamePaused()
    {
        gamePaused.PlayerGamePaused();
    }

    void GameWon()
    {
        gameWon.PlayerGameWon();
    }

} //class
