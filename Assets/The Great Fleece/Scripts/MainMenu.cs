using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("LoadingScene");
        Debug.Log("Start Button clicked");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
