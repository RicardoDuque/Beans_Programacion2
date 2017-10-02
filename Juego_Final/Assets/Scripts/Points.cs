using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour {

    public static int points = 0;
    public Text textPoints;

    /*
    public static int showPoints{
        get{return points;}
        set{points = value;}
    }
    */
    // Use this for initialization
    void Start () {
        UpdatePoints(points);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdatePoints(int points)
    {
        textPoints.text = "Puntos: " + points; //Muestra variable points
    }

    public void GetPoints()
    {
        points++; //Suma puntos a la variable points
        UpdatePoints(points); //Cada vez que ganaun punto, se muestra
    }

}
