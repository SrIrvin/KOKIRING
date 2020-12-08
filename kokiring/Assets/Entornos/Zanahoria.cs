using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zanahoria : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player")) {
            Nivel0.puntos++;
            GameObject.Destroy(this.gameObject,0.01f);
        }
    }
}
