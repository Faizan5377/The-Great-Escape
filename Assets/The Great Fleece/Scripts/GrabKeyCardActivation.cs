using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKeyCardActivation : MonoBehaviour
{
    [SerializeField]
    GameObject _GrabKeyCardCutScene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _GrabKeyCardCutScene.SetActive(true);
            GameManager.Instance.HasCard = true;
        }
    }
}
