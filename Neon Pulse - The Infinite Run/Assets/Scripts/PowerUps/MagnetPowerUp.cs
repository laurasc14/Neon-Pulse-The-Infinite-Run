using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetPowerUp : MonoBehaviour
{
    public float magnetDuration = 5f; // Durada del magnetisme

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            //Debug.Log("Magnet power-up activat!");

            MovimientoCapusla movimiento = other.gameObject.GetComponent<MovimientoCapusla>();

            if (movimiento != null)
            {
                movimiento.ActivateMagnet(magnetDuration);
                Destroy(gameObject); // Destrueix el power-up després d'activar-lo
            }
            else
            {
                Debug.LogError("MovimientoCapusla no trobat al jugador!");
            }
        }
    }
}
