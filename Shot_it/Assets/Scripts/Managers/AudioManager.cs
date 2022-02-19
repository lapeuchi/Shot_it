using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource ads;
    public static AudioManager instance = null;

    AudioClip shotClip;
    AudioClip reloadClip;

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
    }

    public void PlayShot()
    {
        ads.PlayOneShot(shotClip);
    }
    public void PlayReload()
    {
        ads.PlayOneShot(reloadClip);
    }
}
