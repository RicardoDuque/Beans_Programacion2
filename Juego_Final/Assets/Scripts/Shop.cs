using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

    public Points PointsScript;
    public CharacterSelector characterSel;
    public Text textPoints;

    public void ConfirmSelection()
    {
        Debug.Log(ItemSelection.Instance.BoolArray[characterSel.I]);

        if (ItemSelection.Instance.BoolArray[characterSel.I] == false && Points.points >= characterSel.Price) //Si no se ha comprado y tenemos más puntos que el precio
        {
            ItemSelection.Instance.SetCharacterBought(characterSel.I);
            Debug.Log(ItemSelection.Instance.BoolArray[characterSel.I]);

            characterSel.SavePlayerPrefs();
            TakePoints();
        }
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void TakePoints()
    {
        Points.points -= characterSel.Price;//Resta X al puntaje global
        PointsScript.UpdatePoints(Points.points);
    }

    public void Play()
    {
        if (ItemSelection.Instance.BoolArray[characterSel.I] == true)
        {
            characterSel.SavePlayerPrefs();
        }

        LoadLevel();
    }
}
