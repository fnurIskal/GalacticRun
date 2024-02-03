using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadSceneAudio : MonoBehaviour
{
    public AudioSource audioSource;
    void Start()
    {
        audioSource.volume = GameManager.Instance.soundVolume;
    }
}
