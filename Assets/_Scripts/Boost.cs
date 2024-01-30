using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boost : MonoBehaviour
{
    public float stayAliveTime;
    public float speed; 
    public bool magnet = false;
    private float timer;
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > stayAliveTime)
        {
            timer = 0;
            Destroy(gameObject);
        }
        else
        {
            if (!magnet)
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
        }
    }
}
