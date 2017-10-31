using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDownfall : MonoBehaviour {

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "SueloDestruye") //Si colisiona con 
        {
            Destroy(gameObject);
        }

    }
}
