using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class ComprobadorCampos : MonoBehaviour
{
    public InputField nombre_IF, apellido1_IF, apellido2_IF, dni_IF, telefono_IF, direccion_IF, email_IF;
    private string nombre, apellido1, apellido2, dni, telefono, direccion, email;

    public Toggle Cb_tension;
    public Toggle Cb_problemas;
    public Toggle Cb_epilepsia;
    public Toggle Cb_alergias;
    public Toggle Cb_vih;
    public Toggle Cb_hepatitis;
    public Toggle Cb_piel;
    public Toggle Cb_otros;
    public string mensajeError;

    // Metodo para comprobar el contenido de los campos
    public void ErrorCheck()
    {
        nombre = nombre_IF.text;
        apellido1 = apellido1_IF.text;
        apellido2 = apellido2_IF.text;
        dni = dni_IF.text;
        telefono = telefono_IF.text;
        direccion = direccion_IF.text;
        email = email_IF.text;

        if (!Cb_tension.isOn)
        {
            mensajeError = "X";
            Debug.Log(mensajeError);
            Debug.Log("Error");
        }
        else
        {
            mensajeError = "CORRECTO";
            Debug.Log(mensajeError);
            Debug.Log("Adios");
        }

        Debug.Log(nombre);
        Debug.Log(apellido1);
        Debug.Log(apellido2);
        Debug.Log(dni);
        Debug.Log(telefono);
        Debug.Log(direccion);
        Debug.Log(email);

    }
}
