using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab; // Prefab que es reutilitzarà
    public int poolSize = 10; // Nombre inicial d'objectes al pool

    private Queue<GameObject> pool; // Cua per gestionar els objectes

    void Start()
    {
        pool = new Queue<GameObject>();

        // Crea els objectes inicials al pool
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false); // Manté els objectes inactius fins que es necessitin
            pool.Enqueue(obj);
            Debug.Log($"Object {obj.name} created and added to the pool."); // Depuració
        }

        Debug.Log($"Pool initialized with {pool.Count} objects."); // Depuració
    }

    public GameObject GetFromPool(Vector3 position, Quaternion rotation)
    {
        if (pool.Count > 0)
        {
            GameObject obj = pool.Dequeue(); // Treu un objecte del pool
            obj.transform.position = position;
            obj.transform.rotation = rotation;
            obj.SetActive(true); // Activa l'objecte per usar-lo
            Debug.Log($"Object retrieved from pool: {obj.name}. Remaining in pool: {pool.Count}"); // Depuració
            return obj;
        }
        else
        {
            // Si el pool està buit, crea un nou objecte
            Debug.LogWarning("Pool is empty! Creating a new object."); // Depuració
            GameObject obj = Instantiate(prefab, position, rotation);
            Debug.Log($"Object {obj.name} created because pool was empty."); // Depuració
            return obj;
        }
    }

    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false); // Desactiva l'objecte
        pool.Enqueue(obj); // Torna’l al pool
        Debug.Log($"Object returned to pool: {obj.name}. Pool size: {pool.Count}"); // Depuració
    }
}
