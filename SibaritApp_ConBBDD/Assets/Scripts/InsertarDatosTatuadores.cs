using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class InsertarDatosTatuadores : MonoBehaviour
{
    // Campos declarados
    public InputField nombre_IF, apellido1_IF, apellido2_IF, dni_IF, telefono_IF, direccion_IF, email_IF, usuario_IF, contraseña_IF;
    public Text fNacimiento_T;
    private string nombre, apellido1, apellido2, dni, telefono, direccion, email, fNacimiento, usuario, contraseña,alerta;
    public Text t_ErrorNombre, t_ErrorApellido1, t_ErrorApellido2, t_ErrorDni, t_ErrorDireccion, t_ErrorTelefono, t_ErrorFNacimiento,t_ErrorUsuario,t_ErrorContraseña;

    public string URIDatabase;
    private LlamarBBDD connector;
    private string nombreEscena = "EscenaMenu";

    // Metodo que se llama en Unity para crear un nuevo tatuador
    public void InsertarTatuador()
    {
        // vuelvo el contenido que tendrán los campos de la Escena Registro de Unity en sus variables
        nombre = nombre_IF.text;
        apellido1 = apellido1_IF.text;
        apellido2 = apellido2_IF.text;
        dni = dni_IF.text;
        telefono = telefono_IF.text;
        direccion = direccion_IF.text;
        email = email_IF.text;
        fNacimiento = fNacimiento_T.text;
        usuario = usuario_IF.text;
        contraseña = contraseña_IF.text;


        // Creo objeto de la clase LlamaBBDD para poder usar sus metodos
        connector = gameObject.AddComponent<LlamarBBDD>();
        // Uso el metodo AbrirBBDD() de la clase LlamarBBDD para asegurarme de estar conectado a la BBDD
        connector.AbrirBBDD(URIDatabase);

        //"jar:file://" + Application.dataPath + "!/assets/"
        // /storage/emulated/0/Android/data/<packagename>/files

        // If para comprobar que no hay campos vacios del registro del tatuador y si los hay se mostrara mensaje de error en pantalla en forma de X al lado del campo sin rellenar
        if (nombre.Equals(""))
        {
            t_ErrorNombre.text = "X";
        }
        else
        {
            t_ErrorNombre.text = "";
        }
        if (apellido1.Equals(""))
        {
            t_ErrorApellido1.text = "X";
        }
        else
        {
            t_ErrorApellido1.text = "";
        }
        if (apellido2.Equals(""))
        {
            t_ErrorApellido2.text = "X";
        }
        else
        {
            t_ErrorApellido2.text = "";
        }
        if (dni.Equals(""))
        {
            t_ErrorDni.text = "X";
        }
        else
        {
            t_ErrorDni.text = "";
        }
        if (direccion.Equals(""))
        {
            t_ErrorDireccion.text = "X";
        }
        else
        {
            t_ErrorDireccion.text = "";
        }
        if (telefono.Equals(""))
        {
            t_ErrorTelefono.text = "X";
        }
        else
        {
            t_ErrorTelefono.text = "";
        }
        if (fNacimiento.Equals("") || fNacimiento.Equals("00 / 00 / 0000"))
        {
            t_ErrorFNacimiento.text = "X";
        }
        else
        {
            t_ErrorFNacimiento.text = "";
        }
        if (usuario.Equals(""))
        {
            t_ErrorUsuario.text = "X";
        }
        else
        {
            t_ErrorUsuario.text = "";
        }
        if (contraseña.Equals(""))
        {
            t_ErrorContraseña.text = "X";
        }
        else
        {
            t_ErrorContraseña.text = "";
        }

        //If para comprobar que no hay campos vacios. Si todos tienen contenido se creara y guardara un nuevo tatuador en la BBDD llamando al metodo InsertarDatosTatuador() de la clase LlamarBBDD
        if (!nombre.Equals("") && !apellido1.Equals("") && !apellido2.Equals("") && !dni.Equals("") && !telefono.Equals("") && !direccion.Equals("") && !fNacimiento.Equals("") && !usuario.Equals("") && !contraseña.Equals(""))
        {
            connector.InsertarDatosTatuador(nombre, apellido1, apellido2, dni, telefono, direccion, email, fNacimiento, usuario, contraseña);
            cambiarEscena(nombreEscena);
        }
        else
        {
            Debug.Log("Rellena los campos correctamente");
        }

    }

    // Metodo para cambiar de Escena (Introducir nombre de la Escena a la que se quiere ir)
    public void cambiarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }

}