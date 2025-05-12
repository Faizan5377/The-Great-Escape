using UnityEngine.SceneManagement;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    internal static UIManager Instance
    {
        get
        {
            if(_instance  == null)
            {
                Debug.LogError("UIManager Instance missing!");
            }
            return _instance;
        }
        private set
        {
            _instance = value;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public void Restart()
    {
        GameManager.Instance.isCaught = false;
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
