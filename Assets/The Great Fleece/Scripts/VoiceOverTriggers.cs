using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverTriggers : MonoBehaviour
{
    [SerializeField]
    AudioClip VO_Clip;

    bool isVOPlayed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isVOPlayed)
        {
            isVOPlayed = true;
            AudioManager.Instance.PlayVoiceOver(VO_Clip);
        }
    }
}
