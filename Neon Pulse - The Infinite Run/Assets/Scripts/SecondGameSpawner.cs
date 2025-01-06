using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondGameSpawner : MonoBehaviour
{

    private float timePlayed = 0;
    private float lastSpawnZ = 5;
    private float minSpawnDistance = 10f;

    public List<GameObject> easy_presets;

    List<GameObject> spawned_presets;

    // Start is called before the first frame update
    void Start()
    {
        spawned_presets = new List<GameObject>();
        for(int i = 0; i < 5; i++)
        {
            Spawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        timePlayed += Time.deltaTime * 15;
        if(timePlayed >= 50) {
            Spawn();
            timePlayed = 0;
        }

        
    }

    void Spawn() {
        float nextZ;
        if (spawned_presets.Count > 0) { 
            nextZ = 55 + spawned_presets[spawned_presets.Count - 1].transform.position.z;
        }
        else
        {
            nextZ = 45;
        }
        GameObject spawned = Instantiate(easy_presets[Random.Range(0, easy_presets.Count)], new Vector3(3.75f, 0, nextZ), Quaternion.Euler(0, -90, 0));
        spawned_presets.Add(spawned);
    }
}
