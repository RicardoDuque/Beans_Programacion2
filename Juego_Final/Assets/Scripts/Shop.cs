using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

    public Points PointsScript;
    public int characterPrice = 5;
    public CharacterSelector characterSel;
    public Text textPoints;


    // Use this for initialization
    public void Start() {
        //DontDestroyOnLoad(gameObject);
        //InteractableConfirmation();
        /*
        if (characterSel.IsCharacterBuyed == 0)
            confirmButton.interactable = true;
        else
        {
            textPrice.text = "Ya lo has comprado";
            confirmButton.interactable = false;
        }
        */
    }

    public void ConfirmSelection()
    {
        /*
            if (Points.points >= characterPrice)
            {
                PlayerPrefs.SetInt("IsCharacterBuyed", 1);
                confirmButton.interactable = false;

                characterSel.SavePlayerPrefs();
                //CharacterSelection();

                LoadLevel();
            }
        */
        Debug.Log(ItemSelection.Instance.BoolArray[characterSel.I]);

        if (ItemSelection.Instance.BoolArray[characterSel.I] == false)
        {
            if (Points.points >= characterPrice)
            {
                ItemSelection.Instance.SetCharacterBought(characterSel.I);
                Debug.Log(ItemSelection.Instance.BoolArray[characterSel.I]);

                characterSel.SavePlayerPrefs();
                TakePoints();

                //PointsScript.UpdatePoints(Points.points); //Actualiza puntos en juego
                textPoints.text = "Puntos: " + Points.points; //Actualiza texto puntos

            }
        }


    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void TakePoints()
    {
        Points.points -= characterSel.Price;//Resta 5 al puntaje global
        PointsScript.UpdatePoints(Points.points);

        //Points.points =- 1;Resto puntos
        //PlayerPrefs.SetInt("CharacterSelected", i);
    }

    /*
    public void InteractableConfirmation()
    {
        if (Points.points >= characterPrice)    //Si tiene los puntos suficientes, que pueda interactuar
            confirmButton.interactable = true;

        else
            confirmButton.interactable = false;
            //textPrice.text = "Ya lo has comprado";
    }
    */

    public void Play()
    {
        if (ItemSelection.Instance.BoolArray[characterSel.I] == true)
        {
            characterSel.SavePlayerPrefs();
        }

        LoadLevel();
    }
}
