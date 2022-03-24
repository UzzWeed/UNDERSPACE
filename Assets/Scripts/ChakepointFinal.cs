using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChakepointFinal : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Cuando el jugador colisione con el chakepoint final, cambie de escena. [Aquí acaba el demo]
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("EndDemo");
        }
    }
}
