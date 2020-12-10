using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Pieza de codigo para manegar cinematicas finales
public class TerminarDemo : MonoBehaviour
{

    public bool end = true; //evalua la accion a realizar

    // Inicia una corrutina
    void Start()
    {
        if(end)
        StartCoroutine(Coroutine());
    }


    //la corrutina espera 30 segundos para cambiar de ecena
    IEnumerator Coroutine()
    {

        yield return new WaitForSeconds(30);
        
        Debug.Log("Fin del demo");
        SceneManager.LoadScene("MainMenu");
    }

    // Dispara cambio de ecena ante una collision.
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player")) {
            SceneManager.LoadScene("AnimacionFinal");
        }
    }
}
