using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // Array de prefabs d'obstacles per generar
    public float spawnInterval = 2f;     // Interval de temps entre cada generació d'obstacles
    public float spawnRangeX = 5f;       // Rangs d'esquerra i dreta per col·locar obstacles

    private float timer = 0f;            // Temporitzador intern per controlar l'interval de generació

    // Update is called once per frame
    void Update()
    {
        // Actualitza el temporitzador
        timer += Time.deltaTime;

        // Comprova si el temps ha superat l'interval de generació
        if (timer >= spawnInterval)
        {
            SpawnObstacle(); // Genera un obstacle
            timer = 0f;      // Reinicia el temporitzador
        }
    }

    void SpawnObstacle()
    {
        // Selecciona un prefab d'obstacle aleatoriament
        int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
        GameObject obstacle = obstaclePrefabs[obstacleIndex];

        // Determina la posició de generació dins del rang
        float spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPosition = new Vector3(spawnPosX, transform.position.y, transform.position.z);

        // Genera l'obstacle en la posició especificada
        Instantiate(obstacle, spawnPosition, Quaternion.identity);
    }
}
