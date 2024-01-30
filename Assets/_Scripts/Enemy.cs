using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float stayAliveTime;
    public float enemyScore;
    public float speed;
    public float pushForce;
    public bool magnet = false;
    private float timer;
    private GameObject player;
    private bool hasScored = false;
    private float distance;
    private void Start()
    {
        player = GameObject.Find("Player");
        
    }
    private void Update()
    {
        timer += Time.deltaTime;
        distance = Vector2.Distance(transform.position, player.transform.position);
        if ((player.transform.position.y > transform.position.y) && !hasScored)
        {
            GameManager.Instance.IncreaseScore(enemyScore);
            hasScored = true;
        }
        if (timer > stayAliveTime)
        {
            timer = 0;
            Destroy(gameObject);
        }
        if (magnet && distance < 3f)
        {
            Vector2 push = (transform.position - player.transform.position).normalized * pushForce;
            transform.Translate(push * speed * Time.deltaTime, Space.World);
        }
    }
}
