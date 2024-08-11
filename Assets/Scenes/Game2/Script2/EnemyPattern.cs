using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; // Import to handle scene management

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Assign 3 enemy prefabs in the Unity Editor
    public Transform[] patrolPoints; // Assign 4 patrol points in the Unity Editor
    public float spawnDelay = 2f; // Delay before spawning the next enemy
    public float speed = 2f; // Speed of enemy movement
    public string nextSceneName; // Name of the scene to load after all enemies have patrolled

    private int currentEnemyIndex = 0;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (currentEnemyIndex < enemyPrefabs.Length)
        {
            GameObject enemy = Instantiate(enemyPrefabs[currentEnemyIndex], transform.position, Quaternion.identity);
            yield return StartCoroutine(Patrol(enemy)); // Wait for patrol to finish before spawning the next enemy
            currentEnemyIndex++;
            yield return new WaitForSeconds(spawnDelay); // Optional delay before spawning the next enemy
        }

        // After all enemies have spawned and patrolled, change the scene
        SceneManager.LoadScene(nextSceneName);
    }

    IEnumerator Patrol(GameObject enemy)
    {
        for (int i = 0; i < patrolPoints.Length; i++)
        {
            Vector3 randomPoint = GetRandomPoint();
            while (Vector3.Distance(enemy.transform.position, randomPoint) > 0.1f)
            {
                enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, randomPoint, speed * Time.deltaTime);
                yield return null;
            }
            yield return new WaitForSeconds(1f); // Wait 1 second at each point
        }
        Destroy(enemy); // Destroy enemy after patrolling
    }

    Vector3 GetRandomPoint()
    {
        int randomIndex = Random.Range(0, patrolPoints.Length);
        return patrolPoints[randomIndex].position;
    }
}
