using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Asignar etiquetas "Ground" a los elementos suelo en Unity
public class CheckGround : MonoBehaviour {

	private PlayerController playerController;

	// Use this for initialization
	void Start () {
		playerController = GetComponentInParent<PlayerController>();
	}
	
	// Método para comprobar colisiones
	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Ground" || col.gameObject.tag ==  "PlatformMoving")//Comprobar si colisionador tiene etiqueta "Ground" o "PlatformMoving"
			playerController.grounded = true;	
	}

	// Método para salir de la colisión
	void OnCollisionExit2D(Collision2D col) {
		if (col.gameObject.tag == "Ground" || col.gameObject.tag == "PlatformMoving")
			playerController.grounded = false;
	}
}
