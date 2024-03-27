
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Direccion
{
    Derecha,
    Izquierda,
    Arriba,
    Abajo,
    Morir
}


public class Jugador : MonoBehaviour
{
    public float velocity;
    public Cuadricula MyPosicion;
    public Direccion LaDireccion;
    public Direccion LaDireccionFinal;
    public Jugador hijo;
    public Jugador Padre;
    public Rigidbody2D Rigidbody;
    [SerializeField] GameObject PreFabJugador;
    [SerializeField] float distancia;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Cuadricula")
        {
            GameController.Instance.OcuparPosicion(MyPosicion, collision.GetComponent<Cuadricula>());
            MyPosicion = collision.GetComponent<Cuadricula>();
            

            print("colicionoConCuadricula");
        }
    }
    public void movimiento()
    {
        if (hijo != null)
        {
            hijo.movimiento();
        }
        if (Padre == null)
        {
            switch (LaDireccion)
            {
                case Direccion.Derecha:
                    {
                        if (LaDireccionFinal != Direccion.Izquierda)
                        {
                            LaDireccion = Direccion.Derecha;
                            LaDireccionFinal = Direccion.Derecha;
                            Rigidbody.velocity = Vector2.right * velocity;
                            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                        }
                    }
                    break;

                case Direccion.Izquierda:
                    {
                        if(LaDireccionFinal != Direccion.Derecha)
                        {
                            LaDireccionFinal = Direccion.Izquierda;
                            LaDireccion = Direccion.Izquierda;
                            Rigidbody.velocity = Vector2.left * velocity;
                            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
                        }
                    }
                    break;

                case Direccion.Arriba:
                    {
                        if (LaDireccionFinal != Direccion.Abajo)
                        {
                            LaDireccionFinal = Direccion.Arriba;
                            LaDireccion = Direccion.Arriba;
                            Rigidbody.velocity = Vector2.up * velocity;
                            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                        }
                        
                    }
                    break;

                case Direccion.Abajo:
                    {
                        if (LaDireccionFinal != Direccion.Arriba)
                        {
                            LaDireccionFinal = Direccion.Abajo;
                            LaDireccion = Direccion.Abajo;
                            Rigidbody.velocity = Vector2.down * velocity;
                            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 270));
                        }
                    }
                    break;
                case Direccion.Morir:
                    {
                        LaDireccion = Direccion.Morir;
                        Rigidbody.velocity = Vector2.zero;
                    }
                    break;
            }
        }
        else
        {
            print(Padre.name);
            switch (Padre.LaDireccionFinal)
            {
                case Direccion.Derecha:
                    {
                        if (LaDireccionFinal != Direccion.Izquierda)
                        {
                            transform.position = MyPosicion.transform.position;
                            LaDireccion = Direccion.Derecha;
                            LaDireccionFinal = Direccion.Derecha;
                            Rigidbody.velocity = Vector2.right * velocity;
                            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                        }
                    }
                    break;

                case Direccion.Izquierda:
                    {
                        if (LaDireccionFinal != Direccion.Derecha)
                        {
                            transform.position = MyPosicion.transform.position;
                            LaDireccionFinal = Direccion.Izquierda;
                            LaDireccion = Direccion.Izquierda;
                            Rigidbody.velocity = Vector2.left * velocity;
                            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
                        }
                    }
                    break;

                case Direccion.Arriba:
                    {
                        if (LaDireccionFinal != Direccion.Abajo)
                        {
                            transform.position = MyPosicion.transform.position;
                            LaDireccionFinal = Direccion.Arriba;
                            LaDireccion = Direccion.Arriba;
                            Rigidbody.velocity = Vector2.up * velocity;
                            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                        }

                    }
                    break;

                case Direccion.Abajo:
                    {
                        if (LaDireccionFinal != Direccion.Arriba)
                        {
                            transform.position = MyPosicion.transform.position;
                            LaDireccionFinal = Direccion.Abajo;
                            LaDireccion = Direccion.Abajo;
                            Rigidbody.velocity = Vector2.down * velocity;
                            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 270));
                        }
                    }
                    break;
                case Direccion.Morir:
                    {
                        LaDireccion = Direccion.Morir;
                        Rigidbody.velocity = Vector2.zero;
                    }
                    break;
                    /*
                case 0:
                    {
                        print("derecha");
                        LaDireccion = Direccion.Derecha;
                        Rigidbody.velocity = Vector2.right * velocity;
                        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                    }
                    break;

                case -180:
                    {
                        print("izquierda");
                        LaDireccion = Direccion.Izquierda;
                        Rigidbody.velocity = Vector2.left * velocity;
                        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
                    }
                    break;

                case 90:
                    {
                        print("arriba");
                        LaDireccion = Direccion.Arriba;
                        Rigidbody.velocity = Vector2.up * velocity;
                        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                    }
                    break;

                case -90:
                    {
                        print("abajo");
                        LaDireccion = Direccion.Abajo;
                        Rigidbody.velocity = Vector2.down * velocity;
                        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 270));
                    }
                    break;
                    */
            }
            transform.position = MyPosicion.transform.position;
        }
        
    }

    public void CrearHijo()
    {
        if (hijo != null)
        {
            hijo.CrearHijo();
        }
        else
        {
            switch (LaDireccion)
            {
                case Direccion.Derecha:
                    {
                        Vector2 posicion = new Vector2(MyPosicion.posicion.x - 1, MyPosicion.posicion.y);
                        Vector2 posicionParaInstanciar = GameController.Instance.ElMapa[(int)posicion.x, (int)posicion.y].transform.position;

                        GameObject gameObject = Instantiate(PreFabJugador, posicionParaInstanciar, Quaternion.identity);
                        hijo = gameObject.GetComponent<Jugador>();
                        hijo.Padre = this.GetComponent<Jugador>();
                        hijo.LaDireccionFinal = LaDireccionFinal;
                        hijo.MyPosicion = GameController.Instance.ElMapa[(int)posicion.x, (int)posicion.y];
                        hijo.movimiento();
                    }
                    break;

                case Direccion.Izquierda:
                    {
                        Vector2 posicion = new Vector2(MyPosicion.posicion.x + 1, MyPosicion.posicion.y);
                        Vector2 posicionParaInstanciar = GameController.Instance.ElMapa[(int)posicion.x, (int)posicion.y].transform.position;


                        GameObject gameObject = Instantiate(PreFabJugador, posicionParaInstanciar, Quaternion.identity);
                        hijo = gameObject.GetComponent<Jugador>();
                        hijo.Padre = this.GetComponent<Jugador>();
                        hijo.LaDireccionFinal = LaDireccionFinal;
                        hijo.MyPosicion = GameController.Instance.ElMapa[(int)posicion.x, (int)posicion.y];
                        hijo.movimiento();
                    }
                    break;

                case Direccion.Arriba:
                    {
                        Vector2 posicion = new Vector2(MyPosicion.posicion.x, MyPosicion.posicion.y - 1);
                        Vector2 posicionParaInstanciar = GameController.Instance.ElMapa[(int)posicion.x, (int)posicion.y].transform.position;

                        GameObject gameObject = Instantiate(PreFabJugador, posicionParaInstanciar, Quaternion.identity);
                        hijo = gameObject.GetComponent<Jugador>();
                        hijo.Padre = this.GetComponent<Jugador>();
                        hijo.LaDireccionFinal = LaDireccionFinal;
                        hijo.MyPosicion = GameController.Instance.ElMapa[(int)posicion.x, (int)posicion.y];
                        hijo.movimiento();
                    }
                    break;

                case Direccion.Abajo:
                    {
                        Vector2 posicion = new Vector2(MyPosicion.posicion.x, MyPosicion.posicion.y + 1);
                        Vector2 posicionParaInstanciar = GameController.Instance.ElMapa[(int)posicion.x, (int)posicion.y].transform.position;

                        GameObject gameObject = Instantiate(PreFabJugador, posicionParaInstanciar, Quaternion.identity);
                        hijo = gameObject.GetComponent<Jugador>();
                        hijo.Padre = this.GetComponent<Jugador>();
                        hijo.LaDireccionFinal = LaDireccionFinal;
                        hijo.MyPosicion = GameController.Instance.ElMapa[(int)posicion.x, (int)posicion.y];
                        hijo.movimiento();
                    }
                    break;
            }
            
        }
    }


    public void Muerte()
    {
        if (hijo != null)
        {
            hijo.Muerte();
        }
        LaDireccion = Direccion.Morir;
        Rigidbody.velocity = Vector2.zero;
    }


}
