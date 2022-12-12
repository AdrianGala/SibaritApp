using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscenaDropdown : MonoBehaviour
{
    public void cambiarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }

    public void valorDropdown(int val)
    {
        if (val == 0)
        {
            cambiarEscena("EscenaMenu");
        }
        if (val == 1)
        {
            cambiarEscena("EscenaFormularioMenores");
        }
        if (val == 2)
        {
            cambiarEscena("EscenaFormularioMayores");
        }
        if (val == 3)
        {
            cambiarEscena("EscenaVisualizacionFormularios");
        }
        if (val == 4)
        {
            cambiarEscena("EscenaVisualizacionFormularios");
        }

    }
}
