using UnityEngine;
using System.Collections;

public class EnemySpawning : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private Vector2 spawnPos;

    private int spawnDelay;
    private int x = 1;

    void Update()
    {   
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(1f);

        while (x == 1)
        {   
            GetRandomPos();
            ChooseEnemy();

            Instantiate(EnemyManager.instance.chosenEnemy, spawnPos, Quaternion.identity);

            float spawnDelay = Random.Range(4f, 6f);

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
        float num = Mathf.Round(Random.Range(0f, 100f));

        if (num >= 50)
        {
            EnemyManager.instance.SetRangedEnemyStats();
        }
        else if (num >= 0 && num < 50)
        {
            EnemyManager.instance.SetMeleeEnemyStats();
        }
    }
}
