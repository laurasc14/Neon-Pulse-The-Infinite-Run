using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Vehicle : MonoBehaviour
{
    private ObjectPool pool;

    // Assigna la referència al pool
    public void SetPool(ObjectPool objectPool)
    {
        pool = objectPool;
    }

    void Update()
    {
        // Comprova si el vehicle ha sortit de l'àrea visible
        if (transform.position.z < -10f) // Pots ajustar aquest valor segons el joc
        {
            pool.ReturnToPool(this.gameObject); // Torna’l al pool
        }
    }
}
