using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour {

    public float speed;
    public Vector2 offset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        offset.x += speed / 10000;
        offset.x %= 1;
        GetComponent<Renderer>().material.mainTextureOffset = offset;
	}
}
