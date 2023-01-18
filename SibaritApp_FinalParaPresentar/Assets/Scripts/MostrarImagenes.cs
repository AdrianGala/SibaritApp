using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Data;
using UnityEngine.UI;
using System.Drawing;

public class MostrarImagenes : MonoBehaviour
{
    // Campos declarados
    public string URIDatabase;
    private LlamarBBDD connector;
    public GameObject canvas;
    private string query;

    //Este metodo se llama Start() para que la aplicación la ejecute al entrar en la Escena
    void Start()
    {
        // Creo objeto de la clase LlamaBBDD para poder usar sus metodos
        connector = gameObject.AddComponent<LlamarBBDD>();
        // Uso el metodo AbrirBBDD() de la clase LlamarBBDD para asegurarme de estar conectado a la BBDD
        connector.AbrirBBDD(URIDatabase);

        query = "SELECT Imagen FROM Imagenes";
        // Uso el metodo SeleccionarImagenes() de la clase LlamarBBDD para recuperar todas las imagenes
        connector.SeleccionarImagenes(canvas,query);
    }

}


