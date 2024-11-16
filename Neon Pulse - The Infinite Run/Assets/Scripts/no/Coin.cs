using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public int coinValue = 1; // Valor de la moneda
    public AudioClip coinSound; // So de la moneda

    public GameObject[] obstaclePrefabs; // Prefabs d'obstacles
    public GameObject coinPrefab; // Prefab de la moneda
    public float spawnInterval = 2f; // Interval de generació d'obstacles
    public float spawnRangeX = 5f; // Rang en l'eix X per generar obstacles i monedes
    public float coinSpawnChance = 0.5f; // Probabilitat de generar una moneda (0.5 = 50%)

    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        // Actualitza el temporitzador
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            // Genera un obstacle i, potencialment, una moneda
            SpawnObstacleAndCoins();
            timer = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            // Reprodueix el so de recollida
            AudioSource.PlayClipAtPoint(coinSound, transform.position);

            // Afegeix la moneda al comptador de monedes
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.AddCoins(coinValue);
            }

            // Destrueix la moneda o desactiva-la
            Destroy(gameObject);
        }
    }

    void SpawnObstacleAndCoins()
    {
        // Genera un obstacle aleatori
        int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
        GameObject obstacle = obstaclePrefabs[obstacleIndex];
        float spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPosition = new Vector3(spawnPosX, transform.position.y, transform.position.z);
        Instantiate(obstacle, spawnPosition, Quaternion.identity);

        // Decideix aleatòriament si es genera una moneda
        if (Random.value < coinSpawnChance)
        {
            // Posició de la moneda una mica per sobre de l'obstacle
            Vector3 coinPosition = spawnPosition + Vector3.up * 1.5f;
            Instantiate(coinPrefab, coinPosition, Quaternion.identity);
        }
    }

}
