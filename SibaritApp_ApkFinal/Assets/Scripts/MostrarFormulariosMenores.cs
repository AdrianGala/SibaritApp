using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.UIElements;

public class MostrarFormulariosMenores : MonoBehaviour
{
    // Campos declarados
    public string URIDatabase;
    private string mostrarTexto;
    private LlamarBBDD connector;
    public Text texto;

    // Este metodo se llama Start() para que la aplicación la ejecute al entrar en la Escena Visualizar Menores de la aplicacion Unity 
    public void Start()
    {
        // Creo objeto de la clase LlamaBBDD para poder usar sus metodos
        connector = gameObject.AddComponent<LlamarBBDD>();
        // Uso el metodo AbrirBBDD() de la clase LlamarBBDD para asegurarme de estar conectado a la BBDD
        connector.AbrirBBDD(URIDatabase);

        // vuelco en la variable mostrarTexto el contenido que devuelve el metodo SeleccionarDatosMenores() de la clase LlamarBBDD
        mostrarTexto = connector.SeleccionarDatosMenores();

        // vuelco en la variable texto.text que hace referencia al Contetn_SV_EVMe en Unity para mostrar el contenido que devuelve el metodo SeleccionarDatosMenores() de la clase LlamarBBDD
        texto.text = mostrarTexto;

    }
}




