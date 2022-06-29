using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public Enemy[] enemies;
        public int count;
        public float timeBetweenSpawns;

    }

    public Wave[] waves;

    public Transform[] spawnPoints;

    public float timeBetweenWaves;

    private Wave currentWave;

    private int currentWaveIndex;

    private Transform player;

    private bool finishSpawning;

    public GameObject boss;

    public Transform bossSpawnPoint;

    public GameObject healthBar;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(StartSpawnWave(currentWaveIndex));
    }

    IEnumerator StartSpawnWave(int index)
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        StartCoroutine(SpawnWave(index));
    }

    IEnumerator SpawnWave(int index)
    {
        currentWave = waves[index];

        for (int i = 0; i < currentWave.count; i++)
        {
            if (player == null)
            {
                yield break;
            }

            Enemy randomEnemy = currentWave.enemies[Random.Range(0, currentWave.enemies.Length)];
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(randomEnemy, randomSpawnPoint.position, randomSpawnPoint.rotation);

            if (i == currentWave.count - 1)
            {
                finishSpawning = true;
            }
            else
            {
                finishSpawning = false;
            }

            yield return new WaitForSeconds(currentWave.timeBetweenSpawns);
        }
    }
    private void Update()
    {
        if (finishSpawning && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            finishSpawning = false;

            if (currentWaveIndex + 1 < waves.Length)
            {
                currentWaveIndex++;
                StartCoroutine(StartSpawnWave(currentWaveIndex));
            }
            else
            {
                Instantiate(boss, bossSpawnPoint.position, bossSpawnPoint.rotation);
                healthBar.SetActive(true);
            }
        }
    }
}
