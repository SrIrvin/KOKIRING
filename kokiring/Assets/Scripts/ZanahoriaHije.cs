using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Hereda de Zanahoria.
public class ZanahoriaHije : Zanahoria
{
    public float plus; // Velocidad que fue sumada.
  

    ZanahoriaHije(float plus) {
        this.plus = plus;
    }

    public float GetPlus() {
        return this.plus;
    }
    public void SetPlus(float plus) {
        this.plus = plus;
    }
    
    // Disparar al colicionar con el jugador
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            other.GetComponent<MovPly>().addVel(plus);
            SumarPunto();
            GameObject.Destroy(this.gameObject, 0.01f);
        }
    }

}
