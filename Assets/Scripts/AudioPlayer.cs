using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] AudioClip packagePickedUp;
    [SerializeField] AudioClip packageDropped;
    [SerializeField] [Range(0f, 1f)] float sfxVolume = 1f;
    AudioSource audioSource;

    void Awake() 
    {
        ManageSingleton();
        audioSource = GetComponent<AudioSource>();
    }

    void ManageSingleton()
    {
        int instanceCount = FindObjectsOfType(GetType()).Length;
        if (instanceCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this);
        }
    }

    void PlayClip(AudioClip clip)
    {
        if (clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, sfxVolume);
        }
    }

    public void PackagePickedUpSFX()
    {
        PlayClip(packagePickedUp);
    }

    public void PackageDeliveredSFX()
    {
        PlayClip(packageDropped);
    }
}
