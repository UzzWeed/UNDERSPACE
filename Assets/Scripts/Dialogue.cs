using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    //Referencia para las líneas de dialogo que serán guardadas en un string. (El atributo serializefield nos deja modificar la variable de manera más segura. El atributo TextArea es para espicifcar cuantas líneas de texto contendrán los dialogos)
    [SerializeField, TextArea(4, 6)] private string[] lineasDeDialogo;

    //Referencia para activar y desactivar el panel
    [SerializeField] private GameObject panelDeDialogo;

    //Referencia al Text Mesh Pro, con la librería "using TMPro"
    [SerializeField] private TMP_Text dialogoDeTexto;

    //Variable booleana que indicará si el jugador está cerca del collider de dialogo o NPC.
    private bool jugadorEstaEnRango;

    //Variable booleana que indicará si el dialogo comenzó.
    private bool comenzoDialogo;

    //Variable entera que indicará que línea de dialogo esta mostrando
    private int lineIndex;

    //Variable flotante para el tiempo de nuestra corrutina de texto.
    private float tiempoDeEscrito = 0.05f;



    void Update()
    {
        //Si el jugador esta en rango del la colisión
        if (jugadorEstaEnRango)
        {
            //Si este se cumple comienza el dialogo
            if (!comenzoDialogo)
            {
                //Referencia de la función EmpezarDialogo
                EmpezarDialogo();

            } //Si el dialogo de texto completa las lineas de código del indice va poder saltar al siguiente dialogo dando click al fire1 del mouse
            else if (dialogoDeTexto.text == lineasDeDialogo[lineIndex] && Input.GetButtonDown("Fire1"))
            {
                SaltearLineaDialogo();
            
            } 
            
        }
    }



    //Función para la activación de dialogo.
    private void EmpezarDialogo() 
    {
        //Se activa la variable, cuando la conversación inició
        comenzoDialogo = true;
        //Mostrar el panel del dialogo
        panelDeDialogo.SetActive(true);
        //Setear las lineas del index a 0, para que muestre siempre desde la primera línea de texto al dialogo.
        lineIndex = 0;
        //Referencia nuestro método de corrutina para el type por segundo
        StartCoroutine(MostrarLinea());
    }



    //Función para que el jugador pueda saltear las lineas de dialogo
    private void SaltearLineaDialogo()
    {
        //Aumentar lineindex para poder typear la línea siguiente
        lineIndex++;
        //Si el lineindex es menor que la ray de las líneas de dialogo esto quiere decir que aún no hemos llegado a las últimas líneas
        if(lineIndex < lineasDeDialogo.Length)
        {
            //Podemos typear la línea con nuestra corrutina
            StartCoroutine(MostrarLinea());
        }
        else //Si no hay más líneas que mostrar
        {
            //El dialogo termino, se desactiva la variable
            comenzoDialogo = false;
            //Y desactivar el panel del dialogo.
            panelDeDialogo.SetActive(false);
        }
    }



    //Función para la corrutina, esto funciona a manera que el texto muestre caracter por caracter en rutina. 
   private IEnumerator MostrarLinea()
    {
        //Esto hace que el dialogo no muestre nada en un principio
        dialogoDeTexto.text = string.Empty;
        //Mostrar caracter por caracter con foreach
        foreach(char ch in lineasDeDialogo[lineIndex])
        {
            //Concatenará uno por uno
            dialogoDeTexto.text += ch;
            //Pasamos como parametro nuestra variable tiempoDeEscrito, en el cual por cada 5 segundos typeara 20 caracteres
            yield return new WaitForSeconds(tiempoDeEscrito);
        }
    }



    //Cuando el jugador entre a la colisión, la variable cambia a verdadero.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si el gameobject tiene el tag de player y esta colisionando, me active la función.
        if (collision.gameObject.CompareTag("Player"))
        {
            jugadorEstaEnRango = true;
            
        }
    }



    //Cuando el jugador esté fuera de la colisión, la variable cambia a falso.
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Si el gameobject tiene el tag de player y esta fuera de la colisión, me desactive la función.
        if (collision.gameObject.CompareTag("Player"))
        {
            jugadorEstaEnRango = false;
            panelDeDialogo.SetActive(false);

        }
    }
}
