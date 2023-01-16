using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscenaDropdown : MonoBehaviour
{
    // Campos declarados
    public string URIDatabase;
    private LlamarBBDD connector;

    // Metodo para cambiar de Escena (Introducir en Unity nombre de la Escena a la que se quiere ir)
    public void cambiarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }

    // Metodo para recoger el valor del Dropdown de Formularios  
    public void valorDropdown(int val)
    {
        // Creo objeto de la clase LlamaBBDD para poder usar sus metodos
        connector = gameObject.AddComponent<LlamarBBDD>();
        // Uso el metodo AbrirBBDD() de la clase LlamarBBDD para asegurarme de estar conectado a la BBDD
        connector.AbrirBBDD(URIDatabase);

        // Segun la opcion elegida se llama a una Escena u otra
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
            cambiarEscena("EscenaVisualizarMenores");
        }
        else if (val == 4)
        {
            cambiarEscena("EscenaVisualizarMayores");
        }

    }
}
