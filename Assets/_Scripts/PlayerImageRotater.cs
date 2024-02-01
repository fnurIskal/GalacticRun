using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerImageRotater : MonoBehaviour
{
    [SerializeField] GameObject[] points = null;
    private int target = 1;
    public float speed = 2f;
    public float rotationSpeed = 60f;
    void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        if (target == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[0].transform.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, points[0].transform.position) < 0.2f)
                target = 2;
        }
        if (target == 2)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[1].transform.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, points[1].transform.position) < 0.2f)
                target = 3;
        }
        if (target == 3)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[2].transform.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, points[2].transform.position) < 0.2f)
                target = 4;
        }
        if (target == 4)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[3].transform.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, points[3].transform.position) < 0.2f)
                target = 1;
        }
    }
}
