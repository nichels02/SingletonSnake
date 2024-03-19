using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsController : MonoBehaviour
{
    [SerializeField] TMP_Text Points;
    [SerializeField] TMP_Text PointsMax;
    int Puntaje = 0;
    int PuntajeMax = 0;

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



}
