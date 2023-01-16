using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.UIElements;

public class FiltrarFormulariosAdultos : MonoBehaviour
{
    // Campos declarados
    public string URIDatabase;
    public InputField filtrar_IF;
    public Text texto;
    private LlamarBBDD connector;
    private string filtro;
    
    // Metodo que se llama al pulsar el boton de lupa en la Escena Visualizar Mayores de Unity
    public void FormulariosAdultosFiltrados()
    {
        // Creo objeto de la clase LlamaBBDD para poder usar sus metodos
        connector = gameObject.AddComponent<LlamarBBDD>();
        // Uso el metodo AbrirBBDD() de la clase LlamarBBDD para asegurarme de estar conectado a la BBDD
        connector.AbrirBBDD(URIDatabase);

        // vuelco en la variable filtro el contenido que tendrá el campo InputField filtrar de la Escena Visualizar Mayores
        filtro = filtrar_IF.text;
        // vuelco en la variable texto.text que hace referencia al Contetn_SV_EVMa en Unity para mostrar el filtrado que esta declarado en la clase LlamarBBDD
        texto.text =connector.FiltrarAdultos(filtro);

    }

}
