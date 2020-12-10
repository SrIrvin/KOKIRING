using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuprincipal : MonoBehaviour
{
    // Carga la ecena definiendo el valor de save.
    // En caso de mo existir archivos solo entrara como juego nuevo para evirar errores
    public void cargar(string ecena) {
        PlayerPrefs.SetInt("save", 1);
        SceneManager.LoadScene(ecena);
    }

    // Carga la ecena definiendo el valor de save.
    public void nuevo(string ecena)
    {
        PlayerPrefs.SetInt("save", 0);
        SceneManager.LoadScene(ecena, LoadSceneMode.Single);
    }

    // Terminar porceso
    public void cerrar() {
        Application.Quit();
    }



}
