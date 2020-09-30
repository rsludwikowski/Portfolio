using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private List<Enemy> enemies = new List<Enemy>();

    public static int enemyNumber = 0;

    public float minZSpawn = 0;
    public float maxZSpawm = 0;

    private float enemySpawnTimer;
    public float enemySpawnDelay = 10f;

    private void GenerateEnemies()
    {
        int enemies = (int)Random.Range(0.0f, 4.99f);
        for (int i = 0; i < enemies; i++)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        enemyNumber++;
        GameObject enemyInstance = Instantiate(enemyPrefab);
        enemyInstance.transform.position = new Vector3(Random.Range(-5,5),
            enemyInstance.GetComponent<Enemy>().hoverHeight * 4,
            transform.position.z + Random.Range(minZSpawn, maxZSpawm));
        enemyInstance.transform.SetParent(this.transform);
    }

    private void Start()
    {
        enemySpawnTimer = enemySpawnDelay;
    }

    private void Update()
    {
        enemySpawnTimer -= Time.deltaTime;
        if(enemyNumber == 0)
        {
            if (enemySpawnTimer <= 0.0f)
            {
                enemySpawnTimer = enemySpawnDelay;
                GenerateEnemies();
            }
        }
    }
}
