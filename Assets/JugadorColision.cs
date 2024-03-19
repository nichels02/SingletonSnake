using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorColision : MonoBehaviour
{
    [SerializeField] JugadorPadre JugadorPadre;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.name);
        if (collision.tag == "Comida")
        {
            print("Comida");
            Destroy(collision.gameObject);
            JugadorPadre.comida();
        }
        else if (collision.tag == "Muro")
        {
            JugadorPadre.Muerte();
        }
    }
}
