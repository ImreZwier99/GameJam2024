using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private float countdown;
    [SerializeField] private Transform[] spawnPoints; // Array of spawn points

    public Wave[] waves;
    public int currentWaveIndex = 0;

    private bool readyToCountDown;

    private void Start()
    {
        readyToCountDown = true;
        for (int i = 0; i < waves.Length; i++)
        {
            waves[i].enemiesLeft = waves[i].enemies.Length;
        }
    }

    private void Update()
    {
        if (currentWaveIndex >= waves.Length)
        {
            Debug.Log("You survived every wave!");
            return;
        }

        if (readyToCountDown == true)
        {
            countdown -= Time.deltaTime;
        }

        if (countdown <= 0)
        {
            readyToCountDown = false;

            countdown = waves[currentWaveIndex].timeToNextWave;

            StartCoroutine(SpawnWave());
        }

        if (waves[currentWaveIndex].enemiesLeft == 0)
        {
            readyToCountDown = true;
            currentWaveIndex++;
        }
    }

    private IEnumerator SpawnWave()
    {
        if (currentWaveIndex < waves.Length)
        {
            int maxEnemies = waves[currentWaveIndex].enemies.Length;
            int spawnedEnemies = 0;

            while (spawnedEnemies < maxEnemies)
            {
                Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                EnemyAI enemy = Instantiate(waves[currentWaveIndex].enemies[spawnedEnemies], randomSpawnPoint.position, Quaternion.identity);
                enemy.transform.SetParent(randomSpawnPoint);

                spawnedEnemies++;

                yield return new WaitForSeconds(waves[currentWaveIndex].timeToNextEnemy);
            }
        }
    }

    public void DecrementEnemiesLeft()
    {
        if (currentWaveIndex < waves.Length)
        {
            waves[currentWaveIndex].enemiesLeft--;
        }
    }
}

[System.Serializable]
public class Wave
{
    public EnemyAI[] enemies;
    public float timeToNextEnemy;
    public float timeToNextWave;

    public int enemiesLeft;
}

