using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{

    private Animator animator;
    private Rigidbody rb;
    public float lateralSpeed = 5f; // Velocitat de moviment lateral
    public float dodgeDistance = 3f; // Distància de l'esquiva
    public float dodgeSpeed = 10f; // Velocitat de l'esquiva
    private bool isDodging = false;

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

        // Comandes d'esquivar
        if (Input.GetKeyDown(KeyCode.Q) && !isDodging)
        {
            StartCoroutine(Dodge(Vector3.left));
            animator.SetTrigger("DodgeLeft");
        }
        else if (Input.GetKeyDown(KeyCode.E) && !isDodging)
        {
            StartCoroutine(Dodge(Vector3.right));
            animator.SetTrigger("DodgeRight");
        }

    }

    // Crea la funció d'esquivar
    private IEnumerator Dodge(Vector3 direction)
    {
        isDodging = true;
        float startTime = Time.time;
        while (Time.time < startTime + dodgeDistance / dodgeSpeed)
        {
            transform.Translate(direction * dodgeSpeed * Time.deltaTime);
            yield return null;
        }
        isDodging = false;
    }
}
