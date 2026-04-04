using UnityEngine;

public class BallGenerator : MonoBehaviour
{
    [SerializeField] private BallSpawnEntry[] ballEntries;
    [SerializeField] private Transform playerTarget;

    [Header("Spawn Settings")]
    [SerializeField] private float spawnInterval = 0.05f; //0.5 - 2
    [SerializeField] private float spawnRangeX = 1f; //0.5 - 4
    [SerializeField] private float spawnRangeZ = 1f; //0.5 -4 
    [SerializeField] private float fixedHeight = -0.1f;
    [SerializeField] private int maxBallsToSpawn = 1000;
    
    private float timer;
    private int ballsSpawned;

    private void Update()
    {
        if (LevelManager.Instance != null && LevelManager.Instance.GameOver)
            return;

        timer += Time.deltaTime;

        if (ballsSpawned >= maxBallsToSpawn)
            return;

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnBall();
        }
    }

    private void SpawnBall()
    {
        if (ballEntries == null || ballEntries.Length == 0 || playerTarget == null)
            return;

        BallSpawnEntry randomEntry = ballEntries[Random.Range(0, ballEntries.Length)];

        if (randomEntry == null || randomEntry.prefab == null || randomEntry.data == null)
            return;

        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        float randomZ = Random.Range(-spawnRangeZ, spawnRangeZ);

        Vector3 spawnPosition = transform.position + new Vector3(randomX, fixedHeight, randomZ);

        BallObject spawnedBall = Instantiate(randomEntry.prefab, spawnPosition, Quaternion.identity);
        spawnedBall.Initialize(randomEntry.data, playerTarget);

        ballsSpawned++;
    }
}