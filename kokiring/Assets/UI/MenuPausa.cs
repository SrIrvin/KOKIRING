using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Pieza de codigo apara controlar animación de de el menu de pausa.
public class MenuPausa : MonoBehaviour
{

    private bool estado=false;
    
    public void methswitch() {
        estado = !estado;
        GetComponent<Animator>().SetBool("on", estado);
    }
}
