using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.UIElements;

public class BorrarFormularioMayores : MonoBehaviour
{
    // Campos declarados
    public string URIDatabase;
    public InputField filtrar_IF;
    public Text texto;
    private LlamarBBDD connector;
    private string borrar;


    // Metodo que se llama al pulsar el boton de lupa en la Escena Visualizar Mayores de Unity
    public void BorrarAdultosFiltrados()
    {
        // Creo objeto de la clase LlamaBBDD para poder usar sus metodos
        connector = gameObject.AddComponent<LlamarBBDD>();
        // Uso el metodo AbrirBBDD() de la clase LlamarBBDD para asegurarme de estar conectado a la BBDD
        connector.AbrirBBDD(URIDatabase);

        // vuelco en la variable filtro el contenido que tendrá el campo InputField filtrar de la Escena Visualizar Mayores
        borrar = filtrar_IF.text;
        // vuelco en la variable texto.text que hace referencia al Contetn_SV_EVMa en Unity para mostrar el filtrado que esta declarado en la clase LlamarBBDD
        connector.BorrarAdultos(URIDatabase,borrar);

        texto.text = connector.SeleccionarDatosMenores();

        Debug.Log("Eliminado");

    }


}
