using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPlayable : MonoBehaviour
{

    public static GameObject Characters1, Characters2, Characters3, Characters4;
    public GameObject[] characters = new GameObject[4] { Characters1, Characters2, Characters3, Characters4 }; //Se puede hacer mejor con GetChilds
    private int i = 0;

    public int I
    {
        get
        {
            return i;
        }
    }

    // Use this for initialization
    void Start()
    {

        i = PlayerPrefs.GetInt("CharacterSelected");

        foreach (GameObject go in characters)
            go.SetActive(false);

        characters[i].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

}
