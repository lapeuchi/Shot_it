using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource ads;
    public static AudioManager instance = null;

    AudioClip shotClip;
    AudioClip reloadClip;
    AudioClip hitClip;
    AudioClip missClip;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);
        ads = Camera.main.GetComponent<AudioSource>();
        shotClip = Resources.Load<AudioClip>("Sounds/Gun/Gun2_4");
        reloadClip = Resources.Load<AudioClip>("Sounds/Gun/Gun2_load");
        hitClip = Resources.Load<AudioClip>("Sounds/Hit");
        missClip = Resources.Load<AudioClip>("Sounds/Miss");
    }

    public void PlayShot()
    {
        ads.PlayOneShot(shotClip);
    }
    public void PlayReload()
    {
        ads.PlayOneShot(reloadClip);
    }
    public void PlayHit()
    {
        ads.PlayOneShot(hitClip);
    }
    public void PlayMiss()
    {
        ads.PlayOneShot(missClip);
    }
}
