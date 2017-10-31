using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Guía https://www.youtube.com/watch?v=IFTjcPvCZaM

public class CharacterSelector : MonoBehaviour
{
    public static GameObject Characters1, Characters2, Characters3, Characters4, Characters5;
    public GameObject[] characters = new GameObject[5] { Characters1, Characters2, Characters3, Characters4, Characters5 }; //Se puede hacer mejor con GetChilds
    private int i = 0;
    private string characterSelectedName;

    public Shop shop;
    public Text textPrice;
    private int price;

    public int Price
    {
        get
        {
            return price;
        }
    }

    public int I
    {
        get
        {
            return i;
        }
    }

   

    void Start()
    {
        i = PlayerPrefs.GetInt("CharacterSelected");

        //isCharacterBuyed = PlayerPrefs.GetInt("IsCharacterBuyed");

        foreach (GameObject go in characters)
            go.SetActive(false);

        characters[i].SetActive(true); //Comienza mostrando el primer character
    }

    void Update()
    {
        if (ItemSelection.Instance.BoolArray[i] == true)
        {
            textPrice.text = "Comprado";
        }

        if (ItemSelection.Instance.BoolArray[i] == false)
        {
            //PRECIOS JUGADORES
            if (i == 0)
                price = 5;

            if (i == 1)
                price = 10;

            if (i == 2)
                price = 15;

            if (i == 3)
                price = 20;

            if (i == 4)
                price = 50;

            UpdatePrice(price); //Cambia texto de precio
        }
    }

    public void NextCharacter()
    {
        characters[i].SetActive(false);

        if (i == characters.Length - 1) //Reinicie contador a 0 cuando llega al final
            i = 0;
        else //Si no, suma uno al contador para mostrar el siguiente
            i++;

        characters[i].SetActive(true); //Muestra

        Debug.Log(ItemSelection.Instance.BoolArray[i]);


    }

    public void PreviousCharacter()
    {

        characters[i].SetActive(false);

        if (i == 0) //Reinicie contador a 3 cuando llega al final
            i = characters.Length - 1;
        else //Si no, resta uno al contador para mostrar el anterior
            i--;

        characters[i].SetActive(true); //Muestra

        Debug.Log(ItemSelection.Instance.BoolArray[i]);
    }

    public void SavePlayerPrefs()
    {
        PlayerPrefs.SetInt("CharacterSelected", i);
        characterSelectedName = PlayerPrefs.GetInt("CharacterSelected").ToString();

        SoundManager.PlaySound("Cash");
    }

    public void UpdatePrice(int price)
    {
        textPrice.text = "Precio: " + price;
    }

    public string CharacterSelectedName
    {
        get
        {
            return characterSelectedName;
        }

    }

}
