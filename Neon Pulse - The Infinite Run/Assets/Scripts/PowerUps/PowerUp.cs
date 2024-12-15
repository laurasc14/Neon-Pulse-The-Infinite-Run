using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float duration = 5f; // Durada comuna del Power-Up

    // Aquest mètode serà implementat pels fills
    //public abstract void ApplyEffect(MovimientoCapusla player);

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            MovimientoCapusla movimiento = other.gameObject.GetComponent<MovimientoCapusla>();

            if (movimiento != null)
            {
                //ApplyEffect(movimiento); // Aplica l'efecte específic
                Destroy(gameObject); // Destrueix el power-up després d'usar-lo
            }
            else
            {
                Debug.LogError("MovimientoCapusla no trobat al jugador!");
            }
        }
    }
}
