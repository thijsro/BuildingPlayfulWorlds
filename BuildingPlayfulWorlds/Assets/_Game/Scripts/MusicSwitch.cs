using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitch : MonoBehaviour
{
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    [SerializeField] private float fadeRate = 0.001f;

    bool fadingIn = false;
    bool fadingOut = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if (fadingIn)
        {
            if (audioSource2.volume < 1.0f)
            {
                audioSource2.volume += fadeRate * Time.deltaTime;
            }
            else
            {
                fadingIn = false;
            }
        }

        if (fadingOut)
        {
            if (audioSource1.volume > 0.1f)
            {
                audioSource1.volume -= fadeRate * Time.deltaTime;

            }
            else
            {
                audioSource1.volume = 0.0f;
                audioSource1.Stop();
                fadingOut = false;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        PlayMusic();
        StopMusic();
    }

    private void PlayMusic()
    {
        audioSource2.Play();
        audioSource2.volume = 0.0f;
        fadingIn = true;
    }

    private void StopMusic()
    {
        fadingOut = true;
    }
}
