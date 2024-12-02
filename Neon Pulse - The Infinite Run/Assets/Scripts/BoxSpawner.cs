using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    //public GameObject taxiPrefab;
    public GameObject specialPrefab;

    public ObjectPool taxiPool;

    //variables taxi
    public float spawnVelocity = 0.25f;
    private float nextspawn;
    public AnimationCurve spawnCurve;

    public float spawnRangeX = 2.5f;
    public float spawnRangeZ = 5;

    //variables altre spawner
    public float specialSpawnChance = 0.2f;
    public float minSpecialInterval = 5f; 
    public float maxSpecialInterval = 15f;
    private float nextSpecialSpawn; 

    private float timePlayed = 0;

    //Coordenades fixes per als carrils
    private float[] lanes = { -2.5f, 0f, 2.5f };

    private float lastSpawnZ = -10f; // �ltima posici� Z generada
    private float minSpawnDistance = 10f; // Dist�ncia m�nima entre vehicles

    // Start is called before the first frame update
    void Start()
    {
        nextspawn = Time.time + spawnVelocity;

        nextSpecialSpawn = Time.time + Random.Range(minSpecialInterval, maxSpecialInterval);

        /**if (taxiPool != null)
        {
            Debug.Log("TaxiPool is connected to BoxSpawner!");
        }
        else
        {
            Debug.LogError("TaxiPool is NOT connected to BoxSpawner!");
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextspawn)
        {
            SpawnTaxi();
            nextspawn = Time.time + spawnVelocity * spawnCurve.Evaluate(timePlayed / 60);
        }

        if (Time.time > nextSpecialSpawn)
        {
            if (Random.value < specialSpawnChance) // Probabilitat de generar l'element especial
            {
                SpawnSpecial();
            }
            nextSpecialSpawn = Time.time + Random.Range(minSpecialInterval, maxSpecialInterval); // Recalcula el temps per al proper spawn especial
        }

        timePlayed += Time.deltaTime;
    }

    void SpawnTaxi() 
    {
        // Selecciona un carril aleatori
        float lane = lanes[Random.Range(0, lanes.Length)];
        float spawnZ = lastSpawnZ + minSpawnDistance;

        Vector3 spawnPosition = new Vector3(
            lane,
            transform.position.y + 0.5f,
            spawnZ
        );

        //Debug.Log($"Attempting to spawn taxi at position {spawnPosition}."); // Depuraci�

        // Obt� un taxi del pool en lloc de crear-ne un de nou
        GameObject taxi = taxiPool.GetFromPool(spawnPosition, Quaternion.identity);
        //Debug.Log($"Spawned taxi at position {spawnPosition}"); // Depuraci�


        // Assigna el pool al vehicle
        Vehicle vehicleScript = taxi.GetComponent<Vehicle>();
        if (vehicleScript != null)
        {
            vehicleScript.SetPool(taxiPool); // Assigna la refer�ncia al pool
            //Debug.LogError($"Vehicle {taxi.name} does not have a Vehicle script attached!");
        }

        // Actualitza la posici� Z
        lastSpawnZ = spawnZ;
    }

    void SpawnSpecial()
    {
        // Posici� aleat�ria per als elements especials
        float randomOffsetX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPosition = new Vector3(
            transform.position.x + randomOffsetX,
            transform.position.y + 0.5f,
            20
        );

        Instantiate(specialPrefab, spawnPosition, Quaternion.identity);
    }
}
