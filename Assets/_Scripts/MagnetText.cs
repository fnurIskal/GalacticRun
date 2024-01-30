using UnityEngine;
using TMPro;
using System;

public class MagnetText : MonoBehaviour
{
    public TextMeshProUGUI magnetTimeText;
    public bool isPowerupActive = false;
    private float powerupDuration = 30f;
    private float timer;
    void Update()
    {
        if (isPowerupActive)
        {
            timer -= Time.deltaTime;
            magnetTimeText.text = Mathf.Round(timer) + " s";
            if (timer <= 0f)
                DeActivatePowerup();
        }
    }
    public void ActivatePowerup()
    {
        isPowerupActive = true;
        timer = powerupDuration;
    }
    void DeActivatePowerup()
    {
        isPowerupActive = false;
        magnetTimeText.text = "";
    }
}
