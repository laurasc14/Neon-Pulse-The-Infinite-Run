using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MovimientoCapusla : MonoBehaviour
{

    public InputActionReference moveAction;

    // Start is called before the first frame update

    private Rigidbody rb;

    public float velocity = 5;
    public float jumpForce = 25;

    public GameObject pies;
    public LayerMask suelo;

    float puntuacion = 0;

    private float jumpPowerDuration = 0;
    private bool jumpPowerActive = false;

    private bool isShieldActive = false;
    private float shieldDuration = 0f;

    private bool isSpeedBoostActive = false;
    private float speedBoostDuration = 0f;
    private float originalSpeed; // Per guardar la velocitat original

    private bool isMagnetActive = false;
    private float magnetDuration = 0f;
    public float magnetRange = 5f; // Distància d'atracció de monedes
    public float magnetSpeed = 10f; // Velocitat a la qual les monedes s'acosten

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalSpeed = velocity;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = moveAction.action.ReadValue<Vector2>();
        moveDirection.y = 0;
        rb.velocity = moveDirection * velocity + new Vector3(0, rb.velocity.y);


        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            if (jumpPowerActive)
            {
                rb.AddForce(Vector3.up * jumpForce * 1.25f, ForceMode.Impulse);
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
        if (jumpPowerDuration < Time.time)
        {
            jumpPowerActive = false;
            jumpPowerDuration = 0;
        }

        // Temporitzador per al shield
        if (isShieldActive && Time.time > shieldDuration)
        {
            DeactivateShield();
        }

        // Temporitzador del Speed Boost
        if (isSpeedBoostActive && Time.time > speedBoostDuration)
        {
            DeactivateSpeedBoost();
        }

        // Temporitzador del Magnetisme
        if (isMagnetActive && Time.time > magnetDuration)
        {
            DeactivateMagnet();
        }

        // Efecte de magnetisme
        if (isMagnetActive)
        {
            AttractCoins();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstaculo"))
        {
            if (isShieldActive)
            {
                Destroy(other.gameObject); // Destrueix l'obstacle si hi ha escut
            }
            else
            {
                SceneManager.LoadScene(0); // Reinicia el nivell 
            }
        }
        if (other.gameObject.CompareTag("JumpPlatform")) {
            rb.AddForce(Vector3.up * jumpForce * 1.25f, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.5f, suelo);
    }

    public void powerJump()
    {
        jumpPowerDuration = Time.time + 10;
        jumpPowerActive = true;
    }

    public void ActivateShield(float duration)
    {
        isShieldActive = true;
        shieldDuration = Time.time + duration;
    }

    private void DeactivateShield()
    {
        isShieldActive = false;
    }

    public void ActivateSpeedBoost(float multiplier, float duration)
    {
        if (!isSpeedBoostActive) // Només activa si no està actiu
        {
            isSpeedBoostActive = true;
            velocity *= multiplier; // Augmenta la velocitat
            speedBoostDuration = Time.time + duration; // Marca la durada
        }
    }

    private void DeactivateSpeedBoost()
    {
        isSpeedBoostActive = false;
        velocity = originalSpeed; // Restaura la velocitat original
    }

    public void ActivateMagnet(float duration)
    {
        isMagnetActive = true;
        magnetDuration = Time.time + duration;
        //Debug.Log("Magnet activat!");
    }

    private void DeactivateMagnet()
    {
        isMagnetActive = false;
    }

    private void AttractCoins()
    {
        // Troba totes les monedes a prop del jugador
        Collider[] coins = Physics.OverlapSphere(transform.position, magnetRange, LayerMask.GetMask("Coin"));

        foreach (Collider coin in coins)
        {
            if (coin.gameObject.CompareTag("Coin"))
            {
                // Atraure la moneda cap al jugador
                Vector3 direction = (transform.position - coin.transform.position).normalized;
                coin.transform.position += direction * magnetSpeed * Time.deltaTime;

                // Comprova si la moneda està prou a prop del jugador per ser recollida
                //if (Vector3.Distance(coin.transform.position, transform.position) < 0.8f) // Ajusta el valor segons calgui
                //{
                //    // Suma la moneda al comptador i destrueix-la
                //    ScoreManager.instance.AddCoin(1); // Incrementa les monedes
                //    Destroy(coin.gameObject); // Destrueix la moneda després d'atrapar-la
                //}
            }
        }

    }
}