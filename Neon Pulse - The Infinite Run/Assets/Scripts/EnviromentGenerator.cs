using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnviromentGenerator : MonoBehaviour
{

    public GameObject roadPrefab;
    public GameObject roadParent;
    

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 20; ++i)
        {
            Instantiate(roadPrefab, new Vector3(3.75f, 0, -30 + 7.5f*i), Quaternion.Euler(0, -90, 0), roadParent.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateRoad() {
        Instantiate(roadPrefab, new Vector3(3.75f, 0, -30 + 7.5f * 19), Quaternion.Euler(0, -90, 0), roadParent.transform);
    }
}
