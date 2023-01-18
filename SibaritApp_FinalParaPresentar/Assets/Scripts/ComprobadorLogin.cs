using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class ComprobadorLogin : MonoBehaviour
{
    // Campos declarados
    public InputField usuario_IF, contrase�a_IF;
    private string usuario, contrase�a;
    public string nombreEscena;
    public string URIDatabase;
    private LlamarBBDD connector;
    public Text textoAlerta;

    // Metodo para comprobar el contendio de los campos del Login
    public void ErrorLogin()
    {
        // vuelvo el contenido que tendr�n los campos de la Escena Login en sus variables
        usuario = usuario_IF.text;
        contrase�a = contrase�a_IF.text;

        // Creo objeto de la clase LlamaBBDD para poder usar sus metodos
        connector = gameObject.AddComponent<LlamarBBDD>();
        // Uso el metodo AbrirBBDD() de la clase LlamarBBDD para asegurarme de estar conectado a la BBDD
        connector.AbrirBBDD(URIDatabase);
        // Uso el metodo ComprobarCamposLogin() de la clase LlamarBBDD 
        if (!connector.ComprobarCamposLogin(usuario, contrase�a,nombreEscena))
        {
            textoAlerta.text = "Usuario o Contrase�a Incorrectas";
        }
        
    }

}

