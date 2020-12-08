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
}
