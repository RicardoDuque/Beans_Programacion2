﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Se encarga de administrar las escenas

public class SoundManagerMenu : MonoBehaviour {
    private static SoundManagerMenu instance;

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

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
