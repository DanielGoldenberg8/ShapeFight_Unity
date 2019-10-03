using UnityEngine;
using System.Collections;

public class EnemySpawning : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public float minSpawnDelay;
    public float maxSpawnDelay;

    private GameObject player;

    private Vector2 spawnPos;

    private int spawnDelay;
    private int x = 1;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {   
        if (player != null)
        {
            StartCoroutine(SpawnEnemy());
        }
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(1f);

        while (x == 1)
        {   
            GetRandomPos();
            ChooseEnemy();

            Instantiate(EnemyManager.instance.chosenEnemy, spawnPos, Quaternion.identity);

            float spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);

            x--;

            yield return new WaitForSeconds(spawnDelay);

            x++;
        }
    }

    void GetRandomPos()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        spawnPos = new Vector2(randomX, randomY);
    }

    void ChooseEnemy()
    {
        float num = Mathf.CeilToInt(Random.Range(0f, 100f));

        if (num <= 60)
        {
            EnemyManager.instance.SetRangedEnemyStats();
        }
        else
        {
            EnemyManager.instance.SetMeleeEnemyStats();
        }
    }
}
