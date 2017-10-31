using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorController : MonoBehaviour
{
    public Points PointsScript;
    public GameObject enemyPrefab;
    public float generatorTimer = 1.75F; //Genera instancias cada X segundos
    public float puntosTimer = 20f; //Asigna puntos cada X segundos
    float x;
    float y;
    float z;
    Vector3 randomPosition;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("CreateEnemy", 2f, generatorTimer); //Invoca la función "" al "" tiempo de inicio, cada "" tiempo
        InvokeRepeating("CreateEnemy", 10f, generatorTimer);
        InvokeRepeating("CreateEnemy", 10f, 1f);
        InvokeRepeating("CreateEnemy", 20f, generatorTimer);
        InvokeRepeating("CreateEnemy", 25f, generatorTimer);
        InvokeRepeating("CreateEnemy", 30f, 1.5f); //Luego de 30 segundos genera más y más rápido
        InvokeRepeating("CreateEnemy", 40f, 1.5f);
        InvokeRepeating("CreateEnemy", 60f, 1.5f);
        InvokeRepeating("CreateEnemy", 70f, 1f);
        InvokeRepeating("CreateEnemy", 75f, 1f);
        InvokeRepeating("CreateEnemy", 80f, 1f);
        InvokeRepeating("CreateEnemy", 90f, 1f);


        InvokeRepeating("SumaPuntos", 20f, puntosTimer); //Cada 20 segundos da 10 puntos
    }

    // Update is called once per frame
    void Update()
    {
        x = Random.Range(-27, 27);
        y = 17;
        z = 0;
        randomPosition = new Vector3(x, y, z);

    }

    void CreateEnemy()
    {
        Instantiate(enemyPrefab, randomPosition, Quaternion.identity); //Instancia un "" en la posición "" con la rotación ""
    }

    void SumaPuntos()
    {
        PointsScript.SumaPuntosDownfall();
    }
}