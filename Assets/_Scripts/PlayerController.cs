using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    private Vector3 touchPos;
    private Vector3 direction;
    public float boostScore;
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos.z = 0;
            if (Vector2.Distance(touchPos, transform.position) < .5f)
            {
                direction = touchPos - transform.position;
                rb.velocity = new Vector2(direction.x, direction.y) * moveSpeed;

                if (touch.phase == TouchPhase.Ended)
                {
                    rb.velocity = Vector2.zero;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            GameManager.Instance.HoldHighscore();
            SceneManager.LoadScene("DeadScene");
        }
        if (collision.gameObject.CompareTag("Boost"))
        {
            Destroy(collision.gameObject);
            GameManager.Instance.IncreaseScore(boostScore);
        }
    }
}