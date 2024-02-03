using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer rbSprite;
    [SerializeField] private GameObject pause;
    [SerializeField] private float moveSpeed;
    [SerializeField] public AudioSource audioSourceStar;
    private bool gameStarted = false;
    private Vector3 direction;
    public float boostScore;
    private Vector3 touchPosition;
    private void Start()
    {
        audioSourceStar.volume = GameManager.Instance.soundVolume;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !gameStarted)
        {
            InvokeRepeating("GainScore", 1f, 1f);
            gameStarted = true;
        }
        flip();
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            if(Vector2.Distance(touchPosition, pause.transform.position) > 0.5) 
            {
                direction = (touchPosition - transform.position);
                rb.velocity = new Vector2(direction.x, direction.y) * moveSpeed;

                if (touch.phase == TouchPhase.Ended)
                    rb.velocity = Vector2.zero;
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
            audioSourceStar.Play();
            Destroy(collision.gameObject);
            GameManager.Instance.IncreaseScore(boostScore);
        }
    }
    private void flip()
    {
        if(transform.position.x < 0)
            rbSprite.flipX = true;
        else
            rbSprite.flipX = false;
    }
    private void GainScore()
    {
        GameManager.Instance.IncreaseScore(1f);
    }
}