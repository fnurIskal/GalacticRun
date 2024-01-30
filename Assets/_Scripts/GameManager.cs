using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Instance
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    public float currentScore = 0f;
    public float highscore = 0f;
    public void IncreaseScore(float score)
    {
        currentScore += score;
    }
    public void HoldHighscore()
    {
        if (currentScore > highscore)
            highscore = currentScore;
    }
    public void ResetScore()
    {
        currentScore = 0f;
    }
}
