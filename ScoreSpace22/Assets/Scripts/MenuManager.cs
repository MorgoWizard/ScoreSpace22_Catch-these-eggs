using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject howToPlay;
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Settings()
    {
        Debug.Log("Settings");
    }

    public void HowToPlay()
    {
        howToPlay.SetActive(!howToPlay.activeInHierarchy);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
