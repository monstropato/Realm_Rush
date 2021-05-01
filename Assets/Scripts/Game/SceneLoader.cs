using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] float deathRestart = 2f;

    int currentScene;

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentScene + 1);
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(currentScene);
    }

    public void DeathRestart()
    {
        Invoke("RestartScene", deathRestart);
    }
}