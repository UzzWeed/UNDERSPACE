using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    //Función para reintentar el nivel
    public void Reintentar()
    {
        SceneManager.LoadScene("DemoLevel_1");
    }

    //Función para salir al menú principal
    public void MenuPrincipal()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
