using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance { get; private set; }


    [SerializeField] int TamanoMapa = 11;
    [SerializeField] float Separacion;
    public Cuadricula[,] ElMapa;
    [SerializeField] GameObject Comida;
    [SerializeField] GameObject ObjetoCuadricula;
    [SerializeField] GameObject JugadorPadre;
    [SerializeField] Vector2 PosicionInicial;
    List<Cuadricula> ListaLibre = new List<Cuadricula>();

    [SerializeField] PointsController PointsController;

    private void Awake()
    {
        if(instance!=null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }


    private void Start()
    {
        GenerarMapa();
    }
    public void GenerarMapa()
    {
        ElMapa = new Cuadricula[TamanoMapa, TamanoMapa];

        for(int i = 0; i < TamanoMapa; i++)
        {
            for (int j = 0; j < TamanoMapa; j++)
            {
                GameObject gameObject = Instantiate(ObjetoCuadricula, new Vector2(i * Separacion, j * Separacion)+PosicionInicial, Quaternion.identity);
                gameObject.GetComponent<Cuadricula>().posicion = new Vector2(i, j);
                ListaLibre.Add(gameObject.GetComponent<Cuadricula>());
                ElMapa[i, j] = gameObject.GetComponent<Cuadricula>();
            }
        }
        GameObject gameObject1 = Instantiate(JugadorPadre, ElMapa[3, 5].transform.position, Quaternion.identity);
        gameObject1.GetComponent<Jugador>().MyPosicion = ElMapa[3, 6];
        ListaLibre.Remove(ElMapa[3, 6]);
        ElMapa[3, 6].GetComponent<Cuadricula>().EstaOcupado = true;
        GenerarComida();
    }



    public void GenerarComida()
    {
        PointsController.AumentarPuntaje();
        bool termino = false;
        int posicion;
        while (!termino)
        {
            posicion = UnityEngine.Random.Range(0, ListaLibre.Count);
            if (ListaLibre[posicion].EstaOcupado == false)
            {
                termino = true;
                Instantiate(Comida, ListaLibre[posicion].transform.position, quaternion.identity);
                ListaLibre.Remove(ListaLibre[posicion]);
            }
        }
    }



    public void OcuparPosicion(Cuadricula posicionAntigua, Cuadricula posicionNueva)
    {
        ListaLibre.Add(posicionAntigua);
        ListaLibre.Remove(posicionNueva);
    }
    public void OcuparPosicion(Cuadricula posicionNueva)
    {
        ListaLibre.Remove(posicionNueva);
    }




}
