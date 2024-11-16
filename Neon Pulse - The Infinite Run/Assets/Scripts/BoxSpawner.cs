using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{

    public GameObject prefab;
    public float spawnvelocity = 0.25f;
    private float nextspawn;
    public AnimationCurve spawnCurve;

    public float spawnRangeX = 2.5f;
    public float spawnRangeZ = 5;

    private float timePlayed = 0;

    // Start is called before the first frame update
    void Start()
    {
        nextspawn = Time.time + spawnvelocity;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextspawn) {

            float randomOffsetX = Random.Range(-spawnRangeX, spawnRangeX);
            float randomOffsetZ = Random.Range(-spawnRangeZ, spawnRangeZ);

            Vector3 spawnPosition = new Vector3(
                transform.position.x + randomOffsetX,
                transform.position.y +0.5f,  
                20
            );

            Instantiate(prefab, spawnPosition, Quaternion.identity); //añadir spawn aleatorio, sumando algo al transform position, buscar random.range
            
            nextspawn = Time.time + spawnvelocity * spawnCurve.Evaluate(timePlayed/60);
            
        }
        timePlayed += Time.deltaTime;
    }


}
