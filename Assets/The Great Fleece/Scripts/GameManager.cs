using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    internal static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("Game Manager instance got deleted!");
            }
            
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        isCaught = false;
    }

    [SerializeField]
    private PlayableDirector IntroCutScene;

    internal bool HasCard { get; set; } = false;
    internal bool isCaught { get; set; } = false;
    private void Update()
    {
        if (isCaught)
        {
            AudioManager.Instance.transform.Find("VO").transform.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            IntroCutScene.time = 53.35f;
        }
    }
}
