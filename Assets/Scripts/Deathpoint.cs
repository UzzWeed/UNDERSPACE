using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathpoint : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Cuando el jugador colisione a la caída, cambie de escena de Game Over.
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameOver");
        }
        
    }
}
