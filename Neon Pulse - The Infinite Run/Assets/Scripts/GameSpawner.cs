using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpawner : MonoBehaviour
{

    private float[] lanes = { -2.5f, 0f, 2.5f };
    private float timePlayed = 0;
    private float lastSpawnZ = 5;
    private float minSpawnDistance = 10f;

    public GameObject pickUp;
    public GameObject jumpPower;


    public List <SpawnData> objectList;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < objectList.Count; i++)
        {
            objectList[i].nextSpawn = Time.time + objectList[i].velocitySpawn;
        }

    }

    // Update is called once per frame
    void Update()
    {
        foreach (SpawnData data in objectList) {
            if (Time.time > data.nextSpawn)
            {
                Spawn(data);
                data.nextSpawn = Time.time + data.velocitySpawn * data.spawnCurve.Evaluate(timePlayed / 60);
            }
        }
  



        timePlayed += Time.deltaTime;
    }

    void Spawn(SpawnData data)
    {
        // Selecciona un carril aleatori
        float lane = lanes[UnityEngine.Random.Range(0, lanes.Length)];
        float spawnZ = lastSpawnZ + minSpawnDistance;

        Vector3 spawnPosition = new Vector3(
            lane,
            transform.position.y + 0.5f + data.heithSpawn,
            spawnZ
        );

        //Debug.Log($"Attempting to spawn taxi at position {spawnPosition}."); // Depuració

        // Obté un taxi del pool en lloc de crear-ne un de nou
        GameObject taxi = data.pool.GetFromPool(spawnPosition, Quaternion.identity);
        //Debug.Log($"Spawned taxi at position {spawnPosition}"); // Depuració



        // Assigna el pool al vehicle
        Vehicle vehicleScript = taxi.GetComponent<Vehicle>();
        if (vehicleScript != null)
        {
            vehicleScript.SetPool(data.pool); // Assigna la referència al pool
            //Debug.LogError($"Vehicle {taxi.name} does not have a Vehicle script attached!");
        }

        for (int i = 0; i < lanes.Length; i++)
        {
            if (lanes[i] != lane)
            {
                if (UnityEngine.Random.Range(0f, 1f) < 0.05f)
                {
                    Instantiate(jumpPower, new Vector3(lanes[i], transform.position.y + 0.5f + data.heithSpawn, spawnZ), Quaternion.identity, taxi.transform);
                }
                else
                {
                    Instantiate(pickUp, new Vector3(lanes[i], transform.position.y + 0.5f + data.heithSpawn, spawnZ), Quaternion.identity, taxi.transform);

                }
            }
        }

        // Actualitza la posició Z
        lastSpawnZ = spawnZ;
    }
}
[Serializable]
public class SpawnData
{
    public float probabilitySpawn;
    public ObjectPool pool;
    public float heithSpawn;
    public float velocitySpawn;
    internal float nextSpawn;
    public AnimationCurve spawnCurve;
    
}
