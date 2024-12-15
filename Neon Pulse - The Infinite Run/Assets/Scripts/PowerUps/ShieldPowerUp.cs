using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    public float shieldDuration = 10f; // Durada de l'escut en segons

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            MovimientoCapusla movimiento = other.gameObject.GetComponent<MovimientoCapusla>();

            if (movimiento != null)
            {
                movimiento.ActivateShield(shieldDuration);
                Destroy(gameObject); // Destrueix el power-up després d'activar-lo
            }
            else
            {
                Debug.LogError("MovimientoCapusla no trobat al jugador!");
            }
        }
    }
}
