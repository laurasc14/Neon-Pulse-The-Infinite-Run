using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresetMovement : MonoBehaviour
{
    public float velocity = 15f;

    // Update is called once per frame
    void Update()
    {
        transform.position -= Vector3.forward * velocity * Time.deltaTime;

        if (transform.position.z < -30)
        {

        }
    }
}
