using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;

    internal static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Audio Manager Instance not found");
            }
            return _instance;
        }
        private set
        {
            _instance = value;
        }
    }

    [SerializeField]
    private AudioSource _background_Sound_Source, _VO_Sound_Source, _Coin_Throw_Sound_Source;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject); // Keep the AudioManager alive across scenes

            //Initialize separate audio sources for each clip




            //Populate Audio Sources with Clips


            //Enabling Backround Music
            _background_Sound_Source.playOnAwake = true;
            _background_Sound_Source.loop = true;
            _background_Sound_Source.Play();
        }
        else if (_instance != this)
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }


    internal void PlayVoiceOver(AudioClip clip)
    {
        if (!GameManager.Instance.isCaught)
        {
            _VO_Sound_Source.clip = clip;
            _VO_Sound_Source.Play();
        }
    }

    internal void PlayCoinThrowSoundOnce(AudioClip clip)
    {
        _Coin_Throw_Sound_Source.clip = clip;
        _Coin_Throw_Sound_Source.Play();
    }

    internal void PlayBackgroundMusic(AudioClip clip = null)
    {

    }
   
}
