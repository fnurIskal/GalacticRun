using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class StartMenuManager : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    public GameObject playBtn;
    public GameObject settingsBtn;
    public GameObject quitBtn;
    public GameObject settingsScreen;
    [Header("Settings")]
    public GameObject soundOn;
    public GameObject soundOff;
    public GameObject musicOn;
    public GameObject musicOff;
    public GameObject starSpawner;
    public GameObject magnet;
    public GameObject highscore;
    public Slider volumeSlider;
    private void Start()
    {
        highScoreText.text = GameManager.Instance.highscore.ToString();
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }
    public void PlayGame()
    {
        GameManager.Instance.ResetScore();
        SceneManager.LoadScene("LoadingScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void SettingsOn()
    {
        playBtn.SetActive(false);
        settingsBtn.SetActive(false);
        quitBtn.SetActive(false);
        starSpawner.SetActive(false);
        magnet.SetActive(false);
        highscore.SetActive(false);
        settingsScreen.SetActive(true);
    }
    public void SettingsOff()
    {
        playBtn.SetActive(true);
        settingsBtn.SetActive(true);
        quitBtn.SetActive(true);
        starSpawner.SetActive(true);
        magnet.SetActive(true);
        highscore.SetActive(true);
        settingsScreen.SetActive(false);
    }
    public void SoundOn()
    {
        soundOn.SetActive(false);
        soundOff.SetActive(true);
    }
    public void SoundOff()
    {
        soundOn.SetActive(true);
        soundOff.SetActive(false);
    }
    public void MusicOn()
    {
        musicOn.SetActive(false);
        musicOff.SetActive(true);
    }
    public void MusicOff()
    {
        musicOn.SetActive(true);
        musicOff.SetActive(false);
    }
    private void OnVolumeChanged(float value)
    {
        GameManager.Instance.SetVolume(value);
    }
}
