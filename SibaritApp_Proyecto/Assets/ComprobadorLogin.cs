using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class ComprobadorLogin : MonoBehaviour
{
    public InputField nombre_IF, contrase�a_IF;
    private string nombre,contrase�a;

    public string mensajeError;

    public void ErrorLogin()
    {
        nombre = nombre_IF.text;
        contrase�a = contrase�a_IF.text;

        if (nombre.Equals("adri") && contrase�a.Equals("1234"))
        {
            cambiarEscena("EscenaMenu");
        }
        else
        {
            mensajeError = "Error Usu contra no existen";
            Debug.Log(mensajeError);
            Debug.Log("Adios");
        }

        Debug.Log(nombre);
        Debug.Log(contrase�a);
        
    }

    public void cambiarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }


}
