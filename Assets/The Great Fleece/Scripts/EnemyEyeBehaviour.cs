using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEyeBehaviour : MonoBehaviour
{
    [SerializeField]
    GameObject _GameOverCutScene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.isCaught = true;
            _GameOverCutScene.SetActive(true);
        }
    }
}
