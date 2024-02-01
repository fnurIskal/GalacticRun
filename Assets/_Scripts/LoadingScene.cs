using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    private float time=0;
  
    void Update()
    {
        time += Time.deltaTime;
        if(time >= 3)
        {
           SceneManager.LoadScene("StartMenu");
        }
    }
}
