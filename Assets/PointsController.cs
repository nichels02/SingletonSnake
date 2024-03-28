using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsController : MonoBehaviour
{
    [Header("FinDePartida")]
    [SerializeField] GameObject Panel;
    [SerializeField] TMP_Text PointsFin;
    [SerializeField] TMP_Text PointsMaxFin;
    [Header("Partida")]
    [SerializeField] TMP_Text Points;
    [SerializeField] TMP_Text PointsMax;
    int Puntaje = -1;
    int PuntajeMax = -1;

    private void Start()
    {
        Panel.SetActive(false);
    }

    public void AumentarPuntaje()
    {
        Puntaje++;
        Points.text = "Points: " + Puntaje;
        if(Puntaje > PuntajeMax )
        {
            PuntajeMax++;
            PointsMax.text = "Points Max: " + PuntajeMax;
        }
    }

    public void ActualizarPuntajeFin()
    {
        Panel.SetActive(true);
        PointsFin.text = "Puntaje: " + Puntaje;
        PointsMaxFin.text = "Puntaje Max: " + PuntajeMax;
    }



}
