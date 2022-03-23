using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    //Referencia para las l�neas de dialogo que ser�n guardadas en un string. (El atributo serializefield nos deja modificar la variable de manera m�s segura. El atributo TextArea es para espicifcar cuantas l�neas de texto contendr�n los dialogos)
    [SerializeField, TextArea(4, 6)] private string[] lineasDeDialogo;

    //Referencia para activar y desactivar el panel
    [SerializeField] private GameObject panelDeDialogo;

    //Referencia al Text Mesh Pro, con la librer�a "using TMPro"
    [SerializeField] private TMP_Text dialogoDeTexto;

    //Variable booleana que indicar� si el jugador est� cerca del collider de dialogo o NPC.
    private bool jugadorEstaEnRango;

    //Variable booleana que indicar� si el dialogo comenz�.
    private bool comenzoDialogo;

    //Variable entera que indicar� que l�nea de dialogo esta mostrando
    private int lineIndex;

    //Variable flotante para el tiempo de nuestra corrutina de texto.
    private float tiempoDeEscrito = 0.05f;



    void Update()
    {
        //Si el jugador esta en rango del la colisi�n
        if (jugadorEstaEnRango)
        {
            //Si este se cumple comienza el dialogo
            if (!comenzoDialogo)
            {
                //Referencia de la funci�n EmpezarDialogo
                EmpezarDialogo();

            } //Si el dialogo de texto completa las lineas de c�digo del indice va poder saltar al siguiente dialogo dando click al fire1 del mouse
            else if (dialogoDeTexto.text == lineasDeDialogo[lineIndex] && Input.GetButtonDown("Fire1"))
            {
                SaltearLineaDialogo();
            
            } 
            
        }
    }



    //Funci�n para la activaci�n de dialogo.
    private void EmpezarDialogo() 
    {
        //Se activa la variable, cuando la conversaci�n inici�
        comenzoDialogo = true;
        //Mostrar el panel del dialogo
        panelDeDialogo.SetActive(true);
        //Setear las lineas del index a 0, para que muestre siempre desde la primera l�nea de texto al dialogo.
        lineIndex = 0;
        //Referencia nuestro m�todo de corrutina para el type por segundo
        StartCoroutine(MostrarLinea());
    }



    //Funci�n para que el jugador pueda saltear las lineas de dialogo
    private void SaltearLineaDialogo()
    {
        //Aumentar lineindex para poder typear la l�nea siguiente
        lineIndex++;
        //Si el lineindex es menor que la ray de las l�neas de dialogo esto quiere decir que a�n no hemos llegado a las �ltimas l�neas
        if(lineIndex < lineasDeDialogo.Length)
        {
            //Podemos typear la l�nea con nuestra corrutina
            StartCoroutine(MostrarLinea());
        }
        else //Si no hay m�s l�neas que mostrar
        {
            //El dialogo termino, se desactiva la variable
            comenzoDialogo = false;
            //Y desactivar el panel del dialogo.
            panelDeDialogo.SetActive(false);
        }
    }



    //Funci�n para la corrutina, esto funciona a manera que el texto muestre caracter por caracter en rutina. 
   private IEnumerator MostrarLinea()
    {
        //Esto hace que el dialogo no muestre nada en un principio
        dialogoDeTexto.text = string.Empty;
        //Mostrar caracter por caracter con foreach
        foreach(char ch in lineasDeDialogo[lineIndex])
        {
            //Concatenar� uno por uno
            dialogoDeTexto.text += ch;
            //Pasamos como parametro nuestra variable tiempoDeEscrito, en el cual por cada 5 segundos typeara 20 caracteres
            yield return new WaitForSeconds(tiempoDeEscrito);
        }
    }



    //Cuando el jugador entre a la colisi�n, la variable cambia a verdadero.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si el gameobject tiene el tag de player y esta colisionando, me active la funci�n.
        if (collision.gameObject.CompareTag("Player"))
        {
            jugadorEstaEnRango = true;
            
        }
    }



    //Cuando el jugador est� fuera de la colisi�n, la variable cambia a falso.
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Si el gameobject tiene el tag de player y esta fuera de la colisi�n, me desactive la funci�n.
        if (collision.gameObject.CompareTag("Player"))
        {
            jugadorEstaEnRango = false;
            panelDeDialogo.SetActive(false);

        }
    }
}
