using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    //Referencia del componente Rigidbody2D para poder mover el personaje
    private Rigidbody2D rb2D;
    
    //Variable para movimiento horizontal del jugador
    private float movimientoHorizontal = 0f;
    
    //Variable para la velocidad en el que se moverá el jugador
    public float velocidadDeMovimiento;
    
    //Variable para el suavizado del movimiento | Con el Rango hace que en el inspector de unity cambiemos el cuadro de texto a una barra deslizable
    [Range(0,0.3f)] public float suavizadoDeMovimiento;
    
    //Restringir la velocidad del eje Z, asignada en 0
    private Vector3 velocidad = Vector3.zero;

    //Variable booleana para verificar si el jugador está dirigiendose a la derecha o a la izquierda
    private bool mirandoDerecha = true;
 


    //Variable de la fuerza del salto del jugador
    public float fuerzaDeSalto;
    
    //Variable LayerMask para identificar superficies aptas para que el jugador salte
    public LayerMask queEsSuelo;
    
    //Controlador suelo que sera un objeto que tendrá el jugador en los pies
    public Transform ControladorSuelo;
    
    //Las dimensiones del objeto
    public Vector3 dimensionesCaja;
    
    //Variable booleana para que verifique si esta en el suelo o no
    public bool enSuelo;
    
    //Variable booleana que permitirá saltar el jugador
    private bool salto = false;



    //Variable para la activación de animnaciones del jugador
    private Animator animator;



    private void Start()
    {
        //Tomar el rigidbody del jugador
        rb2D = GetComponent<Rigidbody2D>();
        //Tomar el animator del jugador
        animator = GetComponent<Animator>();
    }



    private void Update()
    {
        //Tomar los controles del jugador
        //Tomar la dirección del control si el horizontal es negativo (Izquerda) o si es positivo (Derecha) multiplicado por la velocidad de movimiento
        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadDeMovimiento;

        //Elemento de la animación horizontal para el movimiento del mismo sobre un valor absoluto con esto para obtener un valor positivo.
        animator.SetFloat("Horizontal", Mathf.Abs(movimientoHorizontal));

        //Condición cuando se tome la función del botón saltar
        if (Input.GetButtonDown("Jump"))
        {
            //La variable booleana salto cambie a verdadero
            salto = true;
        }

    }



    //Este método tiene la misma función a la de Update, solamente que este se usa principalmente para las físicas.
    private void FixedUpdate()
    {
        //Lllamar la función Mover, sobre el movimiento horizontal del personaje y esté con el tiempo dependiendo de equipos rápidos o lentos vaya a la misma velocidad
        Mover(movimientoHorizontal * Time.fixedDeltaTime, salto);

        //Cuando el objeto toque algo que sea suelo, el jugador se encuetre en la posición 0.
        enSuelo = Physics2D.OverlapBox(ControladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);

        //La variable se establecerá en falsa para que se mantenga en señal contraria.
        salto = false;
    }



    //Función para el movimiento del jugador
    private void Mover(float mover, bool saltar)
    {
        //Velocidad objetivo sobre el eje x, mediante el rigidbody 2D esta no alterará la velocidad cuando salte o caiga el jugador
        Vector3 velocidadObjetivo = new Vector2(mover, rb2D.velocity.y);

        //La veolicidad del rigidbody con smoothdamp, esta función nos dará un suavizado a la hora de frenar o acelerar el personaje, tomando en cuenta en la velocidad que se encuentra luego a la que se quiere llegar y que tan rápido
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref velocidad, suavizadoDeMovimiento);

        //Condición para cuando el personaje diriga la mirada hacia la dirección que se esta moviendo
        if(mover>0 && !mirandoDerecha)
        {
            //Llamar la función girar
            Girar();

        }
        //Sentido contrario
        else if(mover<0 && mirandoDerecha)
        {
            //Llamar la función girar
            Girar();
        }

        //Condición para cuando el jugador se encuentre en el suelo este permita saltar
        if(enSuelo && saltar)
        {
            //Queda en falsa la variable
            enSuelo = false;
            //Agregamos una fuerza en la dirección.
            rb2D.AddForce(new Vector2(0f, fuerzaDeSalto));
        }
    }



    //Función para el giro del jugador
    private void Girar()
    {
        //Hacer que nuestra variable coloque al sentido contrario al que tenemos, si esta es falsa, verdadera y viceversa
        mirandoDerecha = !mirandoDerecha;
        //Variable para cambiar la escala del jugador
        Vector3 escala = transform.localScale;
        //La multiplicamos en el eje x en negativo
        escala.x *= -1;
        transform.localScale = escala;
    }



    //Función onDrawGizmos nos permite vizualizar la caja que creamos para el controlador del suelo, que por defecto no es visible en Unity
    private void OnDrawGizmos()
    {
        //Color del objeto
        Gizmos.color = Color.red;
        //Mandamos la posición que quedara y sus dimensiones
        Gizmos.DrawWireCube(ControladorSuelo.position, dimensionesCaja);
    }
}

