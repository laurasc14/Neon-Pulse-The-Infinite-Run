using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCapusla : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody rb;

    private float velocity = 5;

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
        if (Input.GetKeyDown(KeyCode.Space)) {
            rb.AddForce(new Vector3(0, 20, 0), ForceMode.Impulse );
        }
    }
}
