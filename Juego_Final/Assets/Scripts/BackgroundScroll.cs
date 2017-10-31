using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
	}

    void Update()
    {
        if (Time.time == 2f) //Espere dos segundos antes de comenzar a mover
        {
            Vector2 offset = new Vector2(Time.time * speed, 0);
            GetComponent<Renderer>().material.mainTextureOffset = offset;
        }

    }
}
