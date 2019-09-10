using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{
    public AudioClip soundExplosion;
    AudioSource myAudio;
    public static sound instance;

    void Awake()
    {
        if (sound.instance == null)
            sound.instance = this;
    }

    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }
   
    void Update()
    {

    }

    public void PlaySound()
    {
        myAudio.PlayOneShot(soundExplosion);
    }
}