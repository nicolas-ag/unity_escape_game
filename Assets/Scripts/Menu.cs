using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject settings;
    [SerializeField]
    private GameObject menu;
    [SerializeField]
    private GameObject credits;

    public void Level1()
    {
        PlayerPrefs.SetInt("level", 1);
        SceneManager.LoadScene("Level1");
    }

    public void Level2()
    {
        PlayerPrefs.SetInt("level", 2);
        SceneManager.LoadScene("Level2");
    }

    public void Level3()
    {
        PlayerPrefs.SetInt("level", 3);
        SceneManager.LoadScene("Level3");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OpenSettings()
    {
        menu.SetActive(false);
        settings.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenCredits()
    {
        menu.SetActive(false);
        credits.SetActive(true);
    }

    public void CloseCredits()
    {
        menu.SetActive(true);
        credits.SetActive(false);
    }
}
