using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        FindObjectOfType<Score>().ResetGame();
        SceneManager.LoadScene(0);
    }

}
