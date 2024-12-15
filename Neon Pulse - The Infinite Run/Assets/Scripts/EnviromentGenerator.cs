using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentGenerator : MonoBehaviour
{
    [Header("Road Configuration")]
    public GameObject roadPrefab;                  // Prefab de la carretera
    public GameObject roadParent;                  // Parent per les carreteres
    public float roadLength = 7.5f;                // Longitud d'un tram de carretera
    private float currentZPosition = -30f;         // Posició inicial Z
    private int roadSections = 20;                 // Nombre de seccions inicials

    [Header("Sidewalk Configuration")]
    public List<GameObject> leftSidewalkPrefabs;   // Llista de prefabs per vorera esquerra
    public List<GameObject> rightSidewalkPrefabs;  // Llista de prefabs per vorera dreta
    public float leftSidewalkOffsetX = 5f;         // Offset lateral per vorera esquerra
    public float rightSidewalkOffsetX = 6f;        // Offset lateral per vorera dreta

    [Header("Side Elements")]
    public List<GameObject> leftSideElements;      // Prefabs decoratius per esquerra
    public List<GameObject> rightSideElements;     // Prefabs decoratius per dreta
    public float sideElementOffsetX = 7f;          // Offset per decoració lateral

    void Start()
    {
        // Genera carretera central, voreres i decoració
        for (int i = 0; i < roadSections; ++i)
        {
            GenerateRoadSection();
        }
    }

    public void CreateRoad()
    {
        // Genera un nou tram de carretera
        GenerateRoadSection();
    }

    private void GenerateRoadSection()
    {
        // **1. Genera la carretera al centre (carretera principal)**
        Vector3 roadPosition = new Vector3(3.75f, 0, currentZPosition);
        Instantiate(roadPrefab, roadPosition, Quaternion.Euler(0, -90, 0), roadParent.transform);
        //Debug.Log($"Carretera generada a Z: {currentZPosition}");

        // **2. Genera les voreres**
        GenerateSidewalks();

        // **3. Genera els elements decoratius**
        GenerateSideElements();

        // **4. Incrementa la posició Z per al següent tram**
        currentZPosition += roadLength;
    }

    private void GenerateSidewalks()
    {
        // **Genera la vorera esquerra amb el seu offset personalitzat**
        if (leftSidewalkPrefabs.Count > 0)
        {
            GameObject leftPrefab = leftSidewalkPrefabs[Random.Range(0, leftSidewalkPrefabs.Count)];
            Vector3 leftPosition = new Vector3(-leftSidewalkOffsetX, 0, currentZPosition);
            Instantiate(leftPrefab, leftPosition, Quaternion.identity, roadParent.transform);
            //Debug.Log($"Vorera esquerra generada a Z: {currentZPosition}");
        }

        // **Genera la vorera dreta amb el seu offset personalitzat**
        if (rightSidewalkPrefabs.Count > 0)
        {
            GameObject rightPrefab = rightSidewalkPrefabs[Random.Range(0, rightSidewalkPrefabs.Count)];
            Vector3 rightPosition = new Vector3(rightSidewalkOffsetX, 0, currentZPosition);
            Instantiate(rightPrefab, rightPosition, Quaternion.identity, roadParent.transform);
            //Debug.Log($"Vorera dreta generada a Z: {currentZPosition}");
        }
    }

    private void GenerateSideElements()
    {
        // **Genera un element decoratiu a l'esquerra**
        if (leftSideElements.Count > 0)
        {
            GameObject leftElement = leftSideElements[Random.Range(0, leftSideElements.Count)];
            Vector3 leftPosition = new Vector3(-sideElementOffsetX, 0, currentZPosition);
            Instantiate(leftElement, leftPosition, Quaternion.identity, roadParent.transform);
            //Debug.Log($"Element lateral esquerre generat a Z: {currentZPosition}");
        }

        // **Genera un element decoratiu a la dreta**
        if (rightSideElements.Count > 0)
        {
            GameObject rightElement = rightSideElements[Random.Range(0, rightSideElements.Count)];
            Vector3 rightPosition = new Vector3(sideElementOffsetX, 0, currentZPosition);
            Instantiate(rightElement, rightPosition, Quaternion.identity, roadParent.transform);
            //Debug.Log($"Element lateral dret generat a Z: {currentZPosition}");
        }
    }
}