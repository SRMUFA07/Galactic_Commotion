using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesChange : MonoBehaviour
{
    public GameObject _loadingScreen;

    public void ChangeScenes(int numberScenes)
    {
        _loadingScreen.SetActive(true);

        SceneManager.LoadScene(numberScenes);
        Time.timeScale = 1;
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void ChangeFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
