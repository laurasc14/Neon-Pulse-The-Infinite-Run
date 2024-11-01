using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{

    private Animator animator;
    private Rigidbody rb;
    public float lateralSpeed = 5f; // Velocitat de moviment lateral

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        // Detecta moviment del jugador endavant
        bool isRunning = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        animator.SetBool("IsRunning", isRunning);

        // Detecta moviment lateral
        float horizontalInput = Input.GetAxis("Horizontal"); // Retorna valors entre -1 i 1
        animator.SetFloat("Horizontal", horizontalInput);

        // Aplicar moviment lateral
        Vector3 lateralMovement = new Vector3(horizontalInput * lateralSpeed * Time.deltaTime, 0, 0);
        transform.Translate(lateralMovement);

        // Salt
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump"); // Per a l’animació de saltar
        }        
    }
}
