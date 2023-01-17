using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePaused : MonoBehaviour
{
    public GameObject gamePaused;

    public void PlayerGamePaused()
    {
        if (gamePaused.activeSelf == true)
        {
            UnPauseGame();
        }
        else
        {
            gamePaused.SetActive(true);
            Time.timeScale = 0f;
        }

    } //game paused

    public void UnPauseGame()
    {
        gamePaused.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        UnPauseGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    } //restart

    public void Continue()
    {
        UnPauseGame();
    } //continue

    public void MainMenu()
    {
        UnPauseGame();
        SceneManager.LoadScene("MainMenu");
    } //main menu

} //class
