using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorationGenerator : MonoBehaviour
{
    [Header("Decoration Configuration")]
   
    public GameObject decorationParent;                  // Parent per les carreteres
    private float currentZPosition = -30f;         // Posició inicial Z

    [Header("Sidewalk Configuration")]
    public List<GameObject> leftSidewalkPrefabs;   // Llista de prefabs per vorera esquerra
    public List<GameObject> rightSidewalkPrefabs;  // Llista de prefabs per vorera dreta
    public float leftSidewalkOffsetX = 5f;         // Offset lateral per vorera esquerra
    public float rightSidewalkOffsetX = 6f;        // Offset lateral per vorera dreta

    [Header("Side Elements")]
    public List<GameObject> leftSideElements;      // Prefabs decoratius per esquerra
    public List<GameObject> rightSideElements;     // Prefabs decoratius per dreta
    public float sideElementOffsetX = 7f;          // Offset per decoració lateral

    List<GameObject> activeDecoration;
    GameObject lastDecorationGeneratedLeft;
    GameObject lastDecorationGeneratedRight;

   

    void Start()
    {
        activeDecoration = new List<GameObject>();

        GameObject leftPrefab = leftSidewalkPrefabs[Random.Range(0, leftSidewalkPrefabs.Count)];
        Vector3 leftPosition = new Vector3(-leftSidewalkOffsetX, 0, -30);
        GameObject geo = Instantiate(leftPrefab, leftPosition, Quaternion.identity, decorationParent.transform);
        lastDecorationGeneratedLeft = geo;

        GameObject rightPrefab = rightSidewalkPrefabs[Random.Range(0, rightSidewalkPrefabs.Count)];
        Vector3 rightPosition = new Vector3(rightSidewalkOffsetX, 0, -30);
        GameObject geo2 = Instantiate(rightPrefab, rightPosition, Quaternion.identity, decorationParent.transform);
        lastDecorationGeneratedRight = geo2;

        // Genera carretera central, voreres i decoració
        for (int i = 0; i < 30; ++i)
        {
            GenerateRoadSection();
        }
    }

    private void Update()
    {
        if (activeDecoration.Count < 30)
        {
            CreateDecoration();
        }

        


    }

    public void CreateDecoration()
    {
        // Genera un nou tram de carretera
        GenerateRoadSection();
    }




    private void GenerateRoadSection()
    {
        

        //Debug.Log($"Carretera generada a Z: {currentZPosition}");

        // **2. Genera les voreres**
        GenerateSidewalks();

        // **3. Genera els elements decoratius**
        //GenerateSideElements();

        // **4. Incrementa la posició Z per al següent tram**
        //currentZPosition += roadLength;
    }

    private void GenerateSidewalks()
    {
        // **Genera la vorera esquerra amb el seu offset personalitzat**
        if (leftSidewalkPrefabs.Count > 0)
        {
            GameObject leftPrefab = leftSidewalkPrefabs[Random.Range(0, leftSidewalkPrefabs.Count)];
            Vector3 leftPosition = new Vector3(-leftSidewalkOffsetX, 0, lastDecorationGeneratedLeft.transform.position.z + 5);
            GameObject geo = Instantiate(leftPrefab, leftPosition, Quaternion.identity, decorationParent.transform);
            lastDecorationGeneratedLeft = geo;
            //Debug.Log($"Vorera esquerra generada a Z: {currentZPosition}");
        }

        // **Genera la vorera dreta amb el seu offset personalitzat**
        if (rightSidewalkPrefabs.Count > 0)
        {
            GameObject rightPrefab = rightSidewalkPrefabs[Random.Range(0, rightSidewalkPrefabs.Count)];
            Vector3 rightPosition = new Vector3(rightSidewalkOffsetX, 0, lastDecorationGeneratedRight.transform.position.z + 2.5f);
            GameObject geo = Instantiate(rightPrefab, rightPosition, Quaternion.identity, decorationParent.transform);
            lastDecorationGeneratedRight = geo;

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
            Instantiate(leftElement, leftPosition, Quaternion.identity, decorationParent.transform);
            //Debug.Log($"Element lateral esquerre generat a Z: {currentZPosition}");
        }

        // **Genera un element decoratiu a la dreta**
        if (rightSideElements.Count > 0)
        {
            GameObject rightElement = rightSideElements[Random.Range(0, rightSideElements.Count)];
            Vector3 rightPosition = new Vector3(sideElementOffsetX, 0, currentZPosition);
            Instantiate(rightElement, rightPosition, Quaternion.identity, decorationParent.transform);
            //Debug.Log($"Element lateral dret generat a Z: {currentZPosition}");
        }
    }

    public void RemoveDecoration(GameObject road)
    {
        activeDecoration.Remove(road);
    }
}
