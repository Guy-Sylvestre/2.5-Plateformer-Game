using UnityEngine.SceneManagement;
using UnityEngine;

public class Events : MonoBehaviour
{
    // Replay level
    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Quit game
    public void QuitGame()
    {
        Application.Quit();
    }
}
