﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour {

    bool active;
    Canvas canvasPause;

    // Use this for initialization
    void Start()
    {
        canvasPause = GetComponent<Canvas>();
        canvasPause.enabled = false; //Empieza en false para que no aparezca
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetKeyDown("space"))
        {
            active = !active; //cambiamos el valor de active a lo contrario
            canvasPause.enabled = active; //Alterna entre activo e inactivo

            if (active)
            {
                Time.timeScale = 0; // 0 = quieto, 1 = velocidad de juego normal (100%)
            }
            else
            {
                Time.timeScale = 1f; // 0 = quieto, 1 = velocidad de juego normal (100%)
            }
            

        }

	}
}
