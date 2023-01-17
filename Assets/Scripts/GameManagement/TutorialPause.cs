using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialPause : MonoBehaviour
{

    public GameObject gamePausedUI;
    
    public void PauseGame()
    {
        if(gamePausedUI.activeSelf == true)
        {
            UnPauseGame();
        }
        else
        {
            Time.timeScale = 0f;
            gamePausedUI.SetActive(true);
        }


    } //pause game

    public void UnPauseGame()
    {
        gamePausedUI.SetActive(false);
        Time.timeScale = 1f;

    }

    public void Continue()
    {
        UnPauseGame();
    }

    public void MainMenu()
    {
        UnPauseGame();
        SceneManager.LoadScene("MainMenu");
    }

    public void SkipTutorial()
    {
        UnPauseGame();
        SceneManager.LoadScene("MainLevel");

    }

} //class
