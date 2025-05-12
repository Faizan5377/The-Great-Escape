using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCameraBehavior : MonoBehaviour
{
    [SerializeField]
    GameObject _GameOverCutScene;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.isCaught = true;
            Color color = new Color(0.6f, 0.1f, 0.1f, .3f);
            GetComponent<MeshRenderer>().material.SetColor("_TintColor", color);
            GetComponentInParent <Animator>().enabled = false;
            StartCoroutine(WaitbeforeGameOver());
        }
    }

    IEnumerator WaitbeforeGameOver()
    {
        yield return new WaitForSeconds(2f);
        _GameOverCutScene.SetActive(true);
    }
}
