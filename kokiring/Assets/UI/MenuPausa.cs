using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    private bool estado=false;
    // Start is called before the first frame update
    public void methswitch() {
        estado = !estado;
        GetComponent<Animator>().SetBool("on", estado);
    }
}
