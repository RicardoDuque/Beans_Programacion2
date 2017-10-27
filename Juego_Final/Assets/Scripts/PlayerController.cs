﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 20f; //Modificador velocidad
	public bool grounded;//Saber si estamos tocando el suelo
	public float jumpPower = 6.5f; //Variable para el salto
	private Animator anim; //Importar animaciones
	private Rigidbody2D rb2d; //Importar RigidBody
    private SpriteRenderer spr; //Sprite que se muestra
	private bool jump; //Para detectar botón

	// Use this for initialization
	void Start () {

		rb2d = GetComponent<Rigidbody2D> (); //Fuerza RigidBody // Hace referencia al RigidBody del objeto Player	
		anim = GetComponent<Animator>();//Importar animaciones del Player
        spr = GetComponent<SpriteRenderer>();
	}

    private void FixedUpdate()
    {
        //float move = Input.GetAxis ("Horizontal");
        bool leftMove = Input.GetKey(KeyCode.LeftArrow);
        bool rightMove = Input.GetKey(KeyCode.RightArrow);

        //Movimiento jugador
        if (leftMove)
        {
            rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
            transform.localScale = new Vector3(-1f, 1f, 1f);    //Voltea el sprite        
        }
        if (rightMove)
        {
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            transform.localScale = new Vector3(1f, 1f, 1f); //Voltea el sprite
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
        }
        if (jump)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0); //Si salta dos veces, que a la segunda vez no tome impulso y de un salto
                                                             //grande, sino normal; que no se agregue la fuerza y se sumen
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;

        }
    }
    /*
    void OnBecameInvisible(){ //Detecta cuando desaparecemos de la escena

        //Vector3 punto = (mainCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, mainCamera.nearClipPlane)));
        //rb2d.transform.position = new Vector3(0, -4, 0);
        //Debug.Log(mainCamera.gameObject.transform.position.x);
        //   Rect(Screen.width / 2, Screen.height);
        float centerPos = Camera.current.transform.position.x;

        transform.position = new Vector3(centerPos, -4, 0);

    }
    */

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Respawn")
            Destroy(gameObject);
    }


    public void EnemyCollision()
    {
        jump = true;
        spr.color = Color.red;
    }

}