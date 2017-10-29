using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseScreen : MonoBehaviour
{
    bool active;
    bool neverDone;
    public Canvas canvasWinLose;
    public CharacterSelector charSelector;
    public PlayerController bluePlayerController;
    public PlayerController redPlayerController;
    public PlayerController humanPlayerController;
    public PlayerController greenPlayerController;

    // Use this for initialization
    void Start()
    {
        
        canvasWinLose = GetComponent<Canvas>();
        canvasWinLose.enabled = false; //Empieza en false para que no aparezca
        neverDone = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (neverDone) //Para que se ejecute solo una vez, cuando lo hace, se pone en false
        {
            EnableWinLoseScreen();
        }

    }

    public void EnableWinLoseScreen()
    {

        if (bluePlayerController.Dead == true)
        {

            active = !active; //cambiamos el valor de active a lo contrario
            canvasWinLose.enabled = active; //Alterna entre activo e inactivo
            neverDone = false;
        }

        if (redPlayerController.Dead == true)
        {

            active = !active; //cambiamos el valor de active a lo contrario
            canvasWinLose.enabled = active; //Alterna entre activo e inactivo
            neverDone = false;
        }

        if (greenPlayerController.Dead == true)
        {

            active = !active; //cambiamos el valor de active a lo contrario
            canvasWinLose.enabled = active; //Alterna entre activo e inactivo
            neverDone = false;
        }

        if (humanPlayerController.Dead == true)
        {

            active = !active; //cambiamos el valor de active a lo contrario
            canvasWinLose.enabled = active; //Alterna entre activo e inactivo
            neverDone = false;
        }

        //print(characterPlayable.characters.ToString());

        //Hay que hacerlo no para un personaje en específico, para el que esté seleccionado en el momento
        //if (!GameObject.Find(characterPlayable.characters[characterPlayable.I].ToString()))
        //{
        //    active = !active; //cambiamos el valor de active a lo contrario
        //    canvasWinLose.enabled = active; //Alterna entre activo e inactivo
        //    neverDone = false;
        //}

        //if (!GameObject.Find(charSelector.CharacterSelectedName))
        //{
        //    active = !active; //cambiamos el valor de active a lo contrario
        //    canvasWinLose.enabled = active; //Alterna entre activo e inactivo
        //    neverDone = false;
        //}
        //&& GameObject.Find("Green").activeInHierarchy == false && GameObject.Find("Red").activeInHierarchy == false)

        //if (!GameObject.Find("Blue"))
        //{
        //    active = !active; //cambiamos el valor de active a lo contrario
        //    canvasWinLose.enabled = active; //Alterna entre activo e inactivo
        //    neverDone = false;
        //}





        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            active = !active; //cambiamos el valor de active a lo contrario
            canvasWinLose.enabled = active; //Alterna entre activo e inactivo
            /*
            if (active)
            {
                Time.timeScale = 0; // 0 = quieto, 1 = velocidad de juego normal (100%)
            }
            else
            {
                Time.timeScale = 1f; // 0 = quieto, 1 = velocidad de juego normal (100%)
            }
            */

        }

    }



}