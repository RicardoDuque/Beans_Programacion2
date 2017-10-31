using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour {

    public static int points;
    public Text textPoints;

    // Use this for initialization
    void Start () {
        UpdatePoints(points);
	}
	
	// Update is called once per frame
	void Update () {
        UpdatePoints(points);
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

    public void VictoryPoints() //Lo llama el PlayerController
    {
        points += 10;
        UpdatePoints(points);
    }

    public void SumaPuntosDownfall()
    {
        points += 10;
        UpdatePoints(points);
    }

}