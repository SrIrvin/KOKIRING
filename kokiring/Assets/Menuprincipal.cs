using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuprincipal : MonoBehaviour
{
    public void CambEce(string ecena) {
        SceneManager.LoadScene(ecena,LoadSceneMode.Single );
    }

}
