using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Guía https://www.youtube.com/watch?v=IFTjcPvCZaM

public class CharacterSelector : MonoBehaviour
{

    public static GameObject Characters1, Characters2, Characters3;
    public GameObject[] characters = new GameObject[3] { Characters1, Characters2, Characters3 }; //Se puede hacer mejor con GetChilds
    private int i = 0;
    public int indexPP = 0;

    public Shop shop;

    public int IndexPlayerPrefs
    {
        get
        {
            return indexPP;
        }

        set
        {
            indexPP = value;
        }
    }


    // Use this for initialization
    void Start()
    {
        //Points points = GetComponent<Points>();//Acceder a la variable points del script Points

        i = PlayerPrefs.GetInt("CharacterSelected");

        foreach (GameObject go in characters)
            go.SetActive(false);

        characters[i].SetActive(true); //Comienza mostrando el primer character

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextCharacter()
    {
        characters[i].SetActive(false);

        if (i == characters.Length - 1) //Reinicie contador a 0 cuando llega al final
            i = 0;
        else //Si no, suma uno al contador para mostrar el siguiente
            i++;

        characters[i].SetActive(true); //Muestra

        //Contador para almacenar PLayerPrefs
        indexPP = i;
    }

    public void PreviousCharacter()
    {
        characters[i].SetActive(false);

        if (i == 0) //Reinicie contador a 3 cuando llega al final
            i = characters.Length - 1;
        else //Si no, resta uno al contador para mostrar el anterior
            i--;

        characters[i].SetActive(true); //Muestra

        //Contador para almacenar PlayerPrefs
        indexPP = i;
    }

    public void SavePlayerPrefs()
    {
        shop.CharacterSelection();
        PlayerPrefs.SetInt("CharacterSelected", i);
    }
}
