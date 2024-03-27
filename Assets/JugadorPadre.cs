

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class JugadorPadre : Jugador
{
    bool comio;
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Cuadricula")
        {
            GameController.Instance.OcuparPosicion(MyPosicion, collision.GetComponent<Cuadricula>());
            MyPosicion = collision.GetComponent<Cuadricula>();
            movimiento();
            transform.position = MyPosicion.transform.position;
            if (comio)
            {
                comio = false;
                CrearHijo();
            }
            /*switch (transform.rotation.z)
            {
                case 0:
                    {
                        transform.position = new Vector2(MyPosicion.transform.position.x + 0.01f, MyPosicion.transform.position.y);
                    }
                    break;
                case 90:
                    {
                        transform.position = new Vector2(MyPosicion.transform.position.x, MyPosicion.transform.position.y + 0.01f);
                    }
                    break;
                case 180:
                    {
                        transform.position = new Vector2(MyPosicion.transform.position.x - 0.01f, MyPosicion.transform.position.y);
                    }
                    break;
                case 270:
                    {
                        transform.position = new Vector2(MyPosicion.transform.position.x, MyPosicion.transform.position.y - 0.01f);
                    }
                    break;
            }*/

            print("colicionoConCuadricula");
        }
    }

    public void comida()
    {
        GameController.Instance.GenerarComida();
        comio = true;
        //CrearHijo();
    }

    public void Controles(InputAction.CallbackContext value)
    {
        if (LaDireccion != Direccion.Morir)
        {
            Vector2 Movimiento = value.ReadValue<Vector2>();
            if (Movimiento == Vector2.down)
            {
                LaDireccion = Direccion.Abajo;
                if (Rigidbody.velocity == Vector2.zero)
                {
                    movimiento();
                }
            }
            else if (Movimiento == Vector2.up)
            {
                LaDireccion = Direccion.Arriba;
                if (Rigidbody.velocity == Vector2.zero)
                {
                    movimiento();
                }
            }
            else if (Movimiento == Vector2.left)
            {
                LaDireccion = Direccion.Izquierda;
                if (Rigidbody.velocity == Vector2.zero)
                {
                    movimiento();
                }
            }
            else if (Movimiento == Vector2.right)
            {
                LaDireccion = Direccion.Derecha;
                if (Rigidbody.velocity == Vector2.zero)
                {
                    movimiento();
                }
            }
        }
        
    }



}
