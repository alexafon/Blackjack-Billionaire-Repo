using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Blackjack Game");
    }

    public void OpenShop()
    {
        SceneManager.LoadSceneAsync("shopmenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
