using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public int coinValue = 1; // Valor de la moneda
    public AudioClip coinSound; // So de la moneda

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            // Reprodueix el so de recollida
            AudioSource.PlayClipAtPoint(coinSound, transform.position);

            // Afegeix la moneda al comptador de monedes
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.AddCoins(coinValue);
            }

            // Destrueix la moneda o desactiva-la
            Destroy(gameObject);
        }
    }

}
