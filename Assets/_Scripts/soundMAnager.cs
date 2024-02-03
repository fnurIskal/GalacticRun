using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundMAnager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] public AudioSource audioSource;

    void Start()
    {
        Load();
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        volumeSlider.value = GameManager.Instance.volume;
    }

    private void Save()
    {
        GameManager.Instance.volume = volumeSlider.value;
    }

    public void Stop()
    {
        audioSource.Stop();
    }

    public void StartMusic()
    {
        audioSource.Play();
    }
}
