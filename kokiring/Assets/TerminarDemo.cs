using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TerminarDemo : MonoBehaviour
{

    public bool end = true;
    // Start is called before the first frame update
    void Start()
    {
        if(end)
        StartCoroutine(Coroutine());
    }

    IEnumerator Coroutine()
    {

        yield return new WaitForSeconds(30);
        
        Debug.Log("Fin del demo");
        SceneManager.LoadScene("MainMenu");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player")) {
            SceneManager.LoadScene("AnimacionFinal");
        }
    }
}
