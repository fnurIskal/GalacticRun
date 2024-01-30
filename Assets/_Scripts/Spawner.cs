using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnables;
    private float timer = 0;
    private int randomIndex;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            timer = 0;
            randomIndex = Random.Range(0, spawnables.Length);
            Vector2 randomSpawnPos = new Vector2(Random.Range(-2f, 2f), Random.Range(2, 4.5f));
            Instantiate(spawnables[randomIndex], randomSpawnPos, Quaternion.identity);
        }
    }
}
