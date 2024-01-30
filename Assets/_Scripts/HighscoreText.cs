using TMPro;
using UnityEngine;

public class HighscoreText : MonoBehaviour
{
    public TextMeshProUGUI highscoreText;
    void Update()
    {
        highscoreText.text = "Highscore : " + GameManager.Instance.highscore.ToString();
    }
}
