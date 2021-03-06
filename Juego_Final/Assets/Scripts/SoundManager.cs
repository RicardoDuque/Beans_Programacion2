﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    
    public static AudioClip audioJump, audioCash, audioSelect, audioVictory, audioDead; //Audios
    static AudioSource audioSrc;

    // Use this for initialization
    void Start () {




        //Audios
        audioJump = Resources.Load<AudioClip>("Jump"); //Busca el archivo de audio "" en la carpeta Resources
        audioCash = Resources.Load<AudioClip>("Cash");
        audioSelect = Resources.Load<AudioClip>("Select");
        audioVictory = Resources.Load<AudioClip>("Victory");
        audioDead = Resources.Load<AudioClip>("Dead");


        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {//Crear un caso por cada sonido
            case "Jump": //SoundManager.PlaySound("Jump"); //Reproduce sonido Jump
                audioSrc.PlayOneShot(audioJump);
                break;
            case "Cash":
                audioSrc.PlayOneShot(audioCash);
                break;
            case "Select":
                audioSrc.PlayOneShot(audioSelect);
                break;
            case "Victory":
                audioSrc.PlayOneShot(audioVictory);
                break;
            case "Dead":
                audioSrc.PlayOneShot(audioDead);
                break;
        }
    }

}
