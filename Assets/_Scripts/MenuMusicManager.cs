using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusicManager : MonoBehaviour
{
    [SerializeField] public AudioSource audioSource;
    void Start()
    {
        audioSource.volume = GameManager.Instance.volume;
    }
    private void Update()
    {
        audioSource.volume = GameManager.Instance.volume;
    }
}
