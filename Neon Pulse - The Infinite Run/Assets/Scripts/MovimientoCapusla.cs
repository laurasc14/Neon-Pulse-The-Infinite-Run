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

    float puntuacion = 0;

    float jumpPowerDuration = 0;
    bool jumpPowerActive = false;

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
            if(jumpPowerActive)
            {
                rb.AddForce(Vector3.up * jumpForce*1.25f, ForceMode.Impulse);
            }
            else
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }

        puntuacion += 10 * Time.deltaTime;
        if (puntuacion > 0)
        {
            int puntuacionEntera = Mathf.FloorToInt(puntuacion);
            puntuacion -= puntuacionEntera;
            ScoreManager.instance.AddPoints(puntuacionEntera);
        }
        if(jumpPowerDuration < Time.time)
        {
            jumpPowerActive = false;
            jumpPowerDuration = 0;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstaculo")) {
            SceneManager.LoadScene(0);
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.5f);
    }

    public void powerJump() {
        jumpPowerDuration = Time.time + 10;
        jumpPowerActive = true;
    }
}
