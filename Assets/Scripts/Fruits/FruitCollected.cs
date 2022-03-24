using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitCollected : MonoBehaviour
{

    //Cuando el jugador entre a la colisión de la fruta
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si el gameobject tiene el tag de player 
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject, 0.5f);
        }
            
        
    }
}
