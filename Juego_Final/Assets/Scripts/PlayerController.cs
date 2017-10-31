using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 20f; //Modificador velocidad
	public bool grounded;//Saber si estamos tocando el suelo
	public float jumpPower = 6.5f; //Variable para el salto
	private Animator anim; //Importar animaciones
	private Rigidbody2D rb2d; //Importar RigidBody
	private bool jump; //Para detectar botón
    private bool dead;
    private bool victory;
    public Points points;

    
    // Use this for initialization
    void Start () {

        dead = false;
        victory = false;
        
		rb2d = GetComponent<Rigidbody2D> (); //Fuerza RigidBody // Hace referencia al RigidBody del objeto Player	
		anim = GetComponent<Animator>();//Importar animaciones del Player

	}


    void Update()
    {
        //float move = Input.GetAxis ("Horizontal");
        bool leftMove = Input.GetKey(KeyCode.LeftArrow);
        bool rightMove = Input.GetKey(KeyCode.RightArrow);

        //Movimiento jugador
        if (leftMove)
        {
            rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
            transform.localScale = new Vector3(-1f, transform.localScale.y, 1f);    //Voltea el sprite        
        }
        if (rightMove)
        {
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            transform.localScale = new Vector3(1f, transform.localScale.y, 1f); //Voltea el sprite
        }

        
		//Detener jugador al soltar tecla		
		if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
			rb2d.velocity = new Vector2 (0, rb2d.velocity.y);
        }
		
        //Jugador no se deslice
        Vector3 fixedVelocity = rb2d.velocity;
        fixedVelocity.x *= 0.75f;
        if (grounded)
            rb2d.velocity = fixedVelocity;
        else
            rb2d.velocity = fixedVelocity;
        
        //Para cambbio animaciones
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x)); //Mathf.Abs: Busca el valor absoluto o la distancia que hay entre un punto
                                                            //y otro punto, independientemente de si es positivo o negativo, es la dist. 
        anim.SetBool("Grounded", grounded);//Saber si estamos tocando el suelo


        //Detectar si estamos en el suelo y poder saltar
        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            jump = true;
            SoundManager.PlaySound("Jump"); //Reproduce sonido Jump
        }
        if (jump)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0); //Si salta dos veces, que a la segunda vez no tome impulso y de un salto
                                                             //grande, sino normal; que no se agregue la fuerza y se sumen
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;

        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Damage") //Si colisiona con 
        {
            
            dead = true;
            GameObject.Find("CanvasDead").GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;
            Destroy(gameObject);
            
        }

        if(other.gameObject.tag == "Victory")
        {
            victory = true;
            GameObject.Find("CanvasVictory").GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;
            points.VictoryPoints();
        }

        rb2d.velocity = new Vector2(rb2d.velocity.x, 0);

    }

    public void OnTriggerEnter2D(Collider2D collision) //Para lvl Downfall
    {
        if (collision.gameObject.tag == "Damage") //Si colisiona con 
        {
            dead = true;
            GameObject.Find("CanvasDead").GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;
            Destroy(gameObject);
        }
    }

    public bool Dead
    {
        get
        {
            return dead;
        }
    }

    public bool Victory
    {
        get
        {
            return victory;
        }
    }

}