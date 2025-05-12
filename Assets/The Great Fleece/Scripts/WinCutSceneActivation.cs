using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCutSceneActivation : MonoBehaviour
{
    [SerializeField]
    GameObject WinCutScene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player collided");
            Debug.Log("HasCard: " + GameManager.Instance.HasCard);
            if (GameManager.Instance.HasCard)
            {
                
                WinCutScene.SetActive(true);
            }
        }
    }
}
