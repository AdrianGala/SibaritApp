using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;


public class InsertarDatosTatuadores : MonoBehaviour
{
    // Campos declarados
    public InputField nombre_IF, apellido1_IF, apellido2_IF, dni_IF, telefono_IF, direccion_IF, email_IF, usuario_IF, contraseña_IF;
    public Text fNacimiento_T;
    private string nombre, apellido1, apellido2, dni, telefono, direccion, email, fNacimiento, usuario, contraseña,alerta;
    public Text t_ErrorNombre, t_ErrorApellido1, t_ErrorApellido2, t_ErrorDni, t_ErrorDireccion, t_ErrorTelefono, t_ErrorEmail, t_ErrorFNacimiento,t_ErrorUsuario,t_ErrorContraseña,t_AlertaUsuario;

    public string URIDatabase;
    private LlamarBBDD connector;
    private string nombreEscena = "EscenaMenu";

    private string emailPattern = @"^\w+@[a-zA-Z_]+?\.[a-zA-Z]";
    private string nifRegex = @"^[0-9]{8}[A-Z]";
    private string telefonoRegex = @"[6|7|9][0-9]{8}";


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
        t_AlertaUsuario.text = "Usuario ya existe";
        alerta = t_AlertaUsuario.text;

        // Creo variables bool y uso la Regex.IsMatch que devuelve true si la variable cumple con el  patrón 
        bool isEmailValid = Regex.IsMatch(email, emailPattern);
        bool isnifRegExValid = Regex.IsMatch(dni, nifRegex);
        bool isPhoneValid = Regex.IsMatch(telefono, telefonoRegex);

        // Creo objeto de la clase LlamaBBDD para poder usar sus metodos
        connector = gameObject.AddComponent<LlamarBBDD>();
        // Uso el metodo AbrirBBDD() de la clase LlamarBBDD para asegurarme de estar conectado a la BBDD
        connector.AbrirBBDD(URIDatabase);

        int fechaSistema = System.DateTime.Today.Year;
        int fechaElegida = DateTime.Parse(fNacimiento).Year;
        int diferenciaFechas = (fechaSistema - fechaElegida);

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
        if (!dni.Equals("") && isnifRegExValid)
        {
            t_ErrorDni.text = "";
        }
        else
        {
            t_ErrorDni.text = "X";
        }
        if (direccion.Equals(""))
        {
            t_ErrorDireccion.text = "X";
        }
        else
        {
            t_ErrorDireccion.text = "";
        }
        if (!telefono.Equals("") && isPhoneValid)
        {
            t_ErrorTelefono.text = "";
        }
        else
        {
            t_ErrorTelefono.text = "X";
        }
        if (!isEmailValid)
        {
            t_ErrorEmail.text = "X";
        }
        else
        {
            t_ErrorEmail.text = "";
        }

        if (fNacimiento.Equals("") || fNacimiento.Equals("00 / 00 / 0000") || diferenciaFechas < 18 )
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
            connector.InsertarDatosTatuador(nombre, apellido1, apellido2, dni, telefono, direccion, email, fNacimiento, usuario, contraseña, alerta);
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