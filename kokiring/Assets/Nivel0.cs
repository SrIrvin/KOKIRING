using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nivel0 : MonoBehaviour
{
    public Text txPutn;
    public static int puntos=0;



    void Start()
    {
        puntos = GetComponent<SaveData>().LoadKey<int>("los puntos");
    }

    // Update is called once per frame
    void Update()
    {
        txPutn.text = "Score :  "+ puntos;
    }
    public void addScore()
    {
        puntos++;
    }
    public void savePuntos() {
        GetComponent<SaveData>().Save<int>(puntos,"los puntos");
    }
}
