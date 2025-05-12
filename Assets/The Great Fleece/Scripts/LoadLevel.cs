using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class LoadLevel : MonoBehaviour
{
    [SerializeField]
    Image _ProgressBar;


    private void Start()
    {
        StartCoroutine(LoadNextLevel());
    }
    IEnumerator LoadNextLevel()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Main");

        while(operation.isDone == false)
        {
            _ProgressBar.fillAmount = operation.progress;
            yield return new WaitForEndOfFrame();
        }
    }

}
