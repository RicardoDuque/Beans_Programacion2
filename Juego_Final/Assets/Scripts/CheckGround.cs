using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Asignar etiquetas "Ground" a los elementos suelo en Unity

public class CheckGround : MonoBehaviour {

	private PlayerController playerController;

	// Use this for initialization
	void Start () {
		//player = GetComponentInParent<PlayerController>();
		playerController = GetComponentInParent<PlayerController> ();
	}
	
	// Método para comprobar colisiones
	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Ground" || col.gameObject.tag ==  "PlatformMoving")//Comprobar si colisionador tiene etiqueta "Ground" o "PlatformMoving"
			//player.grounded = true;
			playerController.grounded = true;	
	}

	// Método para salir de la colisión
	void OnCollisionExit2D(Collision2D col) {
		if (col.gameObject.tag == "Ground" || col.gameObject.tag == "PlatformMoving")
			//player.grounded = false;
			playerController.grounded = false;
	}
}
