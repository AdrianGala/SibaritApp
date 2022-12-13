using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class ComprobadorLogin : MonoBehaviour
{
    public InputField nombre_IF, contraseņa_IF;
    private string nombre,contraseņa;

    public string mensajeError;

    public void ErrorLogin()
    {
        nombre = nombre_IF.text;
        contraseņa = contraseņa_IF.text;

        if (nombre.Equals("adri") && contraseņa.Equals("1234"))
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
        Debug.Log(contraseņa);
        
    }

    public void cambiarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }


}
