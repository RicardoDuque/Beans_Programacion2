using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton (ayuda de monitor Simón)
/// </summary>
public class ItemSelection : MonoBehaviour {

    private bool[] boolArray = new bool[5];

    private static ItemSelection instance;

    public static ItemSelection Instance
    {
        get
        {
            return instance;
        }

        set
        {
            instance = value;
        }
    }

    public bool[] BoolArray
    {
        get
        {
            return boolArray;
        }
        set
        {
            boolArray = value;
        }
    }

    // Use this for initialization
    void Start () {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        StartGame();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {
        boolArray[0] = true;
        boolArray[1] = false;
        boolArray[2] = false;
        boolArray[3] = false;
        boolArray[4] = false;

    }

    public void SetCharacterBought(int characterID) //Cuando compra
    {
        boolArray[characterID] = true;
    }

    public void SetCharacterNotBought(int characterID)
    {
        boolArray[characterID] = false;
    }

}
