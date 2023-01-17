using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWon : MonoBehaviour
{
    public GameObject gameWonUI;

    public string nextLevel;

    public void PlayerGameWon()
    {
        gameWonUI.SetActive(true);

    } //game won

    public void NextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    } //next level

} //class
