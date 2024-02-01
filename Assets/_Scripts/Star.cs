using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private bool magnetting = false;
    public float speed;
    public float rotationSpeed;
    private float time = 0f;
    private GameObject magnet;
    private void Start()
    {
        magnet = GameObject.FindWithTag("Magnet");
    }
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 2.2f)
        {
            Destroy(gameObject);
        }
        if (!magnetting)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, magnet.transform.position) < 5f)
                magnetting = true;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, magnet.transform.position, speed * Time.deltaTime);
            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        }
    }
}
