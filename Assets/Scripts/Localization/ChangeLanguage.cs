using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLanguage : MonoBehaviour
{
    public void EnglishLangiageSet()
    {
        LanguageText.languageNumber = 0;
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }

    public void RussianLangiageSet()
    {
        LanguageText.languageNumber = 1;
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }

    public void TurkishLangiageSet()
    {
        LanguageText.languageNumber = 2;
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }
}
