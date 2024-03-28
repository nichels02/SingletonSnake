using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene(0);
    }

    public void RegresarMenu()
    {
        SceneManager.LoadScene(1);
    }


}
