using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CambiarGaleria : MonoBehaviour
{
    // Campos declarados
    public string URIDatabase;
    private LlamarBBDD connector;
    public GameObject canvas;
    private string query;

    // Metodo para recoger el valor del Dropdown de Formularios  
    public void valorDropdownGaleria(int val)
    {
        // Creo objeto de la clase LlamaBBDD para poder usar sus metodos
        connector = gameObject.AddComponent<LlamarBBDD>();
        // Uso el metodo AbrirBBDD() de la clase LlamarBBDD para asegurarme de estar conectado a la BBDD
        connector.AbrirBBDD(URIDatabase);

        // Segun la opcion elegida se cargaran en la Escena unas imagenes u otras
        // Cada IF tiene una query para filtrar los campos de las imagenes
        if (val == 0)
        {
            query = "SELECT Imagen FROM Imagenes";
        }
        else if (val == 1)
        {
            query = "SELECT Imagen FROM Imagenes WHERE EstiloTatuaje = 'Anime'";
        }
        else if (val == 2)
        {
            query = "SELECT Imagen FROM Imagenes WHERE EstiloTatuaje = 'Black&Grey'";
        }
        else if (val == 3)
        {
            query = "SELECT Imagen FROM Imagenes WHERE EstiloTatuaje = 'Color'";
        }
        else if (val == 4)
        {
            query = "SELECT Imagen FROM Imagenes WHERE EstiloTatuaje = 'Neotradi'";
        }
        else if (val == 5)
        {
            query = "SELECT Imagen FROM Imagenes WHERE EstiloTatuaje = 'Realismo'";
        }
        // Llamo al metodo para cargarlas imagenes de la clase LlamarBBDD
        connector.SeleccionarImagenes(canvas,query);
    }
}
