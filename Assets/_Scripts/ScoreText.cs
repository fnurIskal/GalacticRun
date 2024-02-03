using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    void Update()
    {
        scoreText.text = Mathf.RoundToInt(GameManager.Instance.currentScore).ToString();
    }
}
