using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    //Funci�n para reintentar el nivel
    public void Reintentar()
    {
        SceneManager.LoadScene("DemoLevel_1");
    }

    //Funci�n para salir al men� principal
    public void MenuPrincipal()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
