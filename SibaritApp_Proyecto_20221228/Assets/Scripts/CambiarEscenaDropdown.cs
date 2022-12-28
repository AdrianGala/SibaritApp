using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscenaDropdown : MonoBehaviour
{
    // Metodo para cambiar de Escena (Introducir nombre de la Escena a la que se quiere ir)
    public void cambiarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }

    // Metodo para recoger el valor del Dropdown de Formularios
    // Segun la opcion elegida se llama a una Escena u otra
    public void valorDropdown(int val)
    {
        if (val == 0)
        {
            cambiarEscena("EscenaMenu");
        }
        else if (val == 1)
        {
            cambiarEscena("EscenaFormularioMenores");
        }
        else if (val == 2)
        {
            cambiarEscena("EscenaFormularioMayores");
        }
        else if (val == 3)
        {
            cambiarEscena("EscenaVisualizacionFormularios");
        }
        else if (val == 4)
        {
            cambiarEscena("EscenaVisualizacionFormularios");
        }

    }
}
