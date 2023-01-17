using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public GameObject gameOverUI;

    public void PlayerGameOver()
    {
        gameOverUI.SetActive(true);
         
    } //game over

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    } //restart

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    } //main menu
    
}
