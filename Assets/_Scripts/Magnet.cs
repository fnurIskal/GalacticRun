using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField] public AudioSource audioSource;
    [SerializeField] private int magnetTime;
    [SerializeField] private GameObject magnetText;
    private int count = 0;
    private GameObject[] boosts;
    private GameObject[] enemies;
    private void Start()
    {
        audioSource.volume = GameManager.Instance.soundVolume;
    }
    private void Update()
    {
        transform.Rotate(0f, 100 * Time.deltaTime, 0f, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.Play();
            magnetText = GameObject.Find("MagnetTimeText");
            magnetText.GetComponent<MagnetText>().ActivatePowerup();
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            InvokeRepeating("MagnetBuff", 0f, .5f);
        }
    }
    void MagnetBuff()
    {
        if (count <= magnetTime)
        {
            count++;
            boosts = GameObject.FindGameObjectsWithTag("Boost");
            foreach (GameObject boost in boosts)
            {
                boost.GetComponent<Boost>().magnet = true;
            }
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<Enemy>().magnet = true;
            }

        }
        else
            Destroy(gameObject);
    }
}
