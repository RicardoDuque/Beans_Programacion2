using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;

public class Shop : MonoBehaviour {

    public Points PointsScript;
    public int characterPrice = 5;
    public CharacterSelector characterSel;

    // Use this for initialization
    public void Start () {

    }

	// Update is called once per frame
	void Update () {
		
	}
    public void ConfirmSelection()
    {
        if (Points.points >= characterPrice)
        {
            characterSel.SavePlayerPrefs();
            //CharacterSelection();
        }

        LoadLevel();

    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("EscenaPrueba");
    }

    public void CharacterSelection()
    {
        Points.points -= characterPrice;//Resta 5 al puntaje global
        PointsScript.UpdatePoints(Points.points);

        //Points.points =- 1;Resto puntos
        //PlayerPrefs.SetInt("CharacterSelected", i);
    }

}
