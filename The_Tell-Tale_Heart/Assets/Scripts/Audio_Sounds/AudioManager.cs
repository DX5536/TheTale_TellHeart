using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    [SerializeField]
    private AudioSource BGMAudio;

    [SerializeField]
    private AudioSource heartBeatAudio;

    private void Awake()
    {
        //Create an instance
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }

        else if (instance != null)
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        if (heartBeatAudio != null)
        {
            heartBeatAudio.volume = 0;
        }
    }

    public void HeartBeatGetsLouder()
    {
        //Each time this method is called (aka through dialog choices)
        //Volume is increased!
        heartBeatAudio.volume += 0.1f;
    }

}
