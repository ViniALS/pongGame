using UnityEngine;
using System.Collections;

public class PowerUpSpawner : MonoBehaviour
{

    public GameObject[] powerUpPrefabs; 
    public Ball ball; 

    public float minSpawnTime = 5f;
    public float maxSpawnTime = 15f;
    public float timeToMove = 10f; 
    public float spawnRangeX = 7f; 
    public float spawnRangeY = 4f;

    void Start()
    {
        if (ball == null) ball = FindFirstObjectByType<Ball>();
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true) 
        {
            while (ball.isPowerUpActive) yield return null;

            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(waitTime);

            if (ball.isPowerUpActive) continue; 

            Vector2 randomPosition = new Vector2(
                Random.Range(-spawnRangeX, spawnRangeX),
                Random.Range(-spawnRangeY, spawnRangeY)
            );
            
            int randomPowerUpIndex = Random.Range(0, powerUpPrefabs.Length);
            
            // Cria o item sorteado
            GameObject currentPowerUp = Instantiate(powerUpPrefabs[randomPowerUpIndex], randomPosition, Quaternion.identity);

            while (currentPowerUp != null)
            {
                float timer = 0f;
                while (timer < timeToMove && currentPowerUp != null)
                {
                    timer += Time.deltaTime;
                    yield return null;
                }

                if (currentPowerUp != null)
                {
                    currentPowerUp.transform.position = new Vector2(
                        Random.Range(-spawnRangeX, spawnRangeX),
                        Random.Range(-spawnRangeY, spawnRangeY)
                    );
                }
            }
        }
    }
}