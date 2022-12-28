using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class ComprobadorLogin : MonoBehaviour
{
    public InputField nombre_IF, contraseña_IF;
    private string nombre,contraseña;
    public string mensajeError;

    // Metodo para comprobar el contendio de los campos del Login
    public void ErrorLogin()
    {
        nombre = nombre_IF.text;
        contraseña = contraseña_IF.text;

        // Si el contenido de los campos es igual al esperado se accede a la Escena Menu
        //    sino error porque se espra otro contenido
        if (nombre.Equals("adri") && contraseña.Equals("1234"))
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
        Debug.Log(contraseña);
        
    }

    // Metodo para cambiar de Escena (Introducir nombre de la Escena a la que se quiere ir)
    public void cambiarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }


}
