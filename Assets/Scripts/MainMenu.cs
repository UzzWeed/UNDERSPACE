using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Librer�a de unity para el control de escenas
public class MainMenu : MonoBehaviour
{
    //void Start(){}
    //void Update(){}

    //M�todo para cargar la escena del videojuego, en este caso se dirige al Demo del Nivel 1
    public void Jugar()
    {
        SceneManager.LoadScene("DemoLevel_1");
    }

    //M�todo para cargar la escena de opciones principales del men� para el videojuego.
    public void Opciones()
    {
        SceneManager.LoadScene("MainOptions");
    }

    //M�todo para especificar que escena cargar al darle click. (Usar este m�todo en un futuro).
    public void CargarNivel(string nombreNivel)
    {
        SceneManager.LoadScene("");
    }

    //M�todo para salir directamente del juego.
    public void Salir()
    {
        Application.Quit();
    }

}
