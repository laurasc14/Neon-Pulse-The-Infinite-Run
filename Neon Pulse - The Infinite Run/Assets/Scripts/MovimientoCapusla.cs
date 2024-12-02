using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimientoCapusla : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody rb;

    public float velocity = 5;
    public float jumpForce = 25;
    //private bool ensuelo = false;
    public GameObject pies;
    public LayerMask suelo;

    public TMP_Text texto;
    float puntuacion = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = - transform.right * velocity + new Vector3(0, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = transform.right * velocity + new Vector3(0, rb.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        puntuacion += 10 * Time.deltaTime;
        texto.text = puntuacion.ToString("F0");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstaculo")) {
            SceneManager.LoadScene(0);
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}
