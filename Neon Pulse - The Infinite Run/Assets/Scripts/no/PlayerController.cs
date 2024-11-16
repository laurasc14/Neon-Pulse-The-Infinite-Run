using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Animator animator;
    private Rigidbody rb;

    public float speed = 5f;
    public float jumpForce = 5f;

    private int coinCount = 0; // Comptador de monedes

    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // Moviment bàsic endavant
        float moveHorizontal = Input.GetAxis("Horizontal"); // Detecció de moviments esquerra/dreta
        Vector3 movement = new Vector3(moveHorizontal * speed * Time.deltaTime, 0, 0);
        transform.Translate(movement);

        // Control de salt
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetTrigger("Jump");
        }
    }

    // Funció per afegir monedes
    public void AddCoins(int amount)
    {

        coinCount += amount;
        Debug.Log("Monedes recollides: " + coinCount);

    }
}
