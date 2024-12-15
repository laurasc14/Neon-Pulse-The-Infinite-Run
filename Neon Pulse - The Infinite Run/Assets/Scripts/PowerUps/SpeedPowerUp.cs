using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    public float speedBoostDuration = 5f; // Durada del Speed Boost
    public float speedMultiplier = 1.5f;   // Multiplicador de velocitat

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            MovimientoCapusla movimiento = other.gameObject.GetComponent<MovimientoCapusla>();

            if (movimiento != null)
            {
                movimiento.ActivateSpeedBoost(speedMultiplier, speedBoostDuration);
                Destroy(gameObject); // Destrueix el power-up després d'activar-lo
            }
            else
            {
                Debug.LogError("MovimientoCapusla no trobat al jugador!");
            }
        }
    }
}
