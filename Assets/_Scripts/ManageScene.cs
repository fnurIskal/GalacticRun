using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour
{
    [SerializeField] private GameObject shadowImg;
    private GameObject[] enemies;
    private GameObject[] boosts;
    private GameObject[] magnets;
    private GameObject player;
    public void LoadPlayScene()
    {
        GameManager.Instance.ResetScore();
        SceneManager.LoadScene("SampleScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PauseGame()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        boosts = GameObject.FindGameObjectsWithTag("Boost");
        magnets = GameObject.FindGameObjectsWithTag("Magnet");
        player = GameObject.FindWithTag("Player");

        foreach (GameObject enemy in enemies)
        {
            enemy.SetActive(false);
        }
        foreach (GameObject boost in boosts)
        {
            boost.SetActive(false);
        }
        foreach(GameObject magnet in magnets)
        {
            magnet.SetActive(false);
        }
        player.SetActive(false);
        shadowImg.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        foreach (GameObject enemy in enemies)
        {
            enemy.SetActive(true);
        }
        foreach (GameObject boost in boosts)
        {
            boost.SetActive(true);
        }
        foreach (GameObject magnet in magnets)
        {
            magnet.SetActive(true);
        }
        player.SetActive(true);
        shadowImg.SetActive(false);
        Time.timeScale = 1f;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public void SetVolume()
    {
        AudioListener.volume = 0f;
    }
    public void ResetVolume()
    {
        AudioListener.volume = GameManager.Instance.volume;
    }
}
