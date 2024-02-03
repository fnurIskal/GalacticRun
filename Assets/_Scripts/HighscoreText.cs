using TMPro;
using UnityEngine;

public class HighscoreText : MonoBehaviour
{
    public TextMeshProUGUI highscoreText;
    void Update()
    {
        highscoreText.text = "high score : " + GameManager.Instance.highscore.ToString();
    }
}
