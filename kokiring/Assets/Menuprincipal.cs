using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuprincipal : MonoBehaviour
{



    public void cargar(string ecena) {
        PlayerPrefs.SetInt("save", 1);
        SceneManager.LoadScene(ecena);
    }

    public void nuevo(string ecena)
    {
        PlayerPrefs.SetInt("save", 0);
        SceneManager.LoadScene(ecena, LoadSceneMode.Single);
    }

    public void cerrar() {
        Application.Quit();
    }



}
