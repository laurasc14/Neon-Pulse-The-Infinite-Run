using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RoadMovement : MonoBehaviour
{

    public float velocity = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= Vector3.forward * velocity * Time.deltaTime;

        if (transform.position.z < -30) { 
            GetComponentInParent<EnviromentGenerator>().RemoveRoad(gameObject);
            Destroy(gameObject);

            GetComponentInParent<DecorationGenerator>().RemoveDecoration(gameObject);
            Destroy(gameObject);
        }
    }
}
