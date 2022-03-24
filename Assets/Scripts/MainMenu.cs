using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Librería de unity para el control de escenas
public class MainMenu : MonoBehaviour
{
    //Función para cargar la escena del videojuego, en este caso se dirige al Demo del Nivel 1
    public void Jugar()
    {
        SceneManager.LoadScene("DemoLevel_1");
    }



    //Función para cargar la escena de opciones principales del menú para el videojuego.
    public void Opciones()
    {
        SceneManager.LoadScene("MainOptions");
    }



    //Función para especificar que escena cargar al darle click. (Usar este método en un futuro).
    public void CargarNivel(string nombreNivel)
    {
        SceneManager.LoadScene("");
    }



    //Función para salir directamente del juego.
    public void Salir()
    {
        Application.Quit();
    }

}
