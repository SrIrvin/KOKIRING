using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nivel0 : MonoBehaviour
{
    public Text txPutn;         // Texto donde se imprime el puntaje
    public static int puntos=0; // Entero que guarda puntos


    //Inicializar puntos cargando en los archivos
    void Start()
    {

        if (PlayerPrefs.HasKey("save"))
            if (PlayerPrefs.GetInt("save") == 1)
                puntos = GetComponent<SaveData>().LoadKey<int>("los puntos");
            else puntos = 0;
    }

    // Actualisación de puntaje.
    void Update()
    {
        txPutn.text = "Score :  "+ puntos;
    }

    // Suma 1 punto
    public void addScore()
    {
        puntos++;
    }

    //Guardar puntaje 
    public void savePuntos() {
        GetComponent<SaveData>().Save<int>(puntos,"los puntos");
        Transform tr= GameObject.Find("Ply").GetComponent<Transform>();
        GetComponent<SaveData>().Save<string>(tr.position + new Vector3(0,.5f,0) + "", "player"); ;

    }



}
