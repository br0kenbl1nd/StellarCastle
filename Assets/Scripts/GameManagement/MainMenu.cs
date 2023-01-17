using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject titleScene;

    public GameObject mainMenu;

    public GameObject confirmPlayGame;

    public void OpenMainMenu()
    {
        titleScene.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void ConfirmPlayGame()
    {
        confirmPlayGame.SetActive(true);

    }

    public void PlayGame()
    {
        SceneManager.LoadScene("MainLevel");

    }

    public void BackToMainMenu()
    {
        confirmPlayGame.SetActive(false);
    }

    public void PlayTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
