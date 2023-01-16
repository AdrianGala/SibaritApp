using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Drawing;
using UnityEngine.SceneManagement;

public class ComprobadorCampos : MonoBehaviour
{
    // Campos declarados
    public InputField nombre_IF, apellido1_IF, apellido2_IF, dni_IF, telefono_IF, direccion_IF, email_IF,nombreTatuador_IF;
    private string nombreAdulto, apellido1Adulto, apellido2Adulto, dniAdulto, direccionAdulto, telefonoAdulto, fNacimientoAdulto, emailAdulto, tensionAdulto, cardiacosAdulto, epilepsiaAdulto, alergiasAdulto, vihAdulto, hepatitisAdulto, pielAdulto, otrosAdulto,nombreTatuador,estiloTatuaje;
    public Text fNacimiento_T;

    public Text t_ErrorNombreA, t_ErrorApellido1A, t_ErrorApellido2A, t_ErrorDniA, t_ErrorDireccionA, t_ErrorTelefonoA, t_ErrorFNacimientoA, t_ErrorNombreT, t_ErrorTerminos, t_ErrorCondiciones;

    public Toggle Cb_tension;
    public Toggle Cb_problemas;
    public Toggle Cb_epilepsia;
    public Toggle Cb_alergias;
    public Toggle Cb_vih;
    public Toggle Cb_hepatitis;
    public Toggle Cb_piel;
    public Toggle Cb_otros;
    public Toggle Cb_AceptoTerminos;
    public Toggle Cb_EstudioNoResponsable;
    
    public string marcado = "si";
    public string desmarcado = "no";
    
    public Dropdown Dd_estiloTatuaje;

    private string AceptoTerminos, EstudioNoResponsable;
    public string URIDatabase;
    private LlamarBBDD connector;
    private string nombreEscena = "EscenaMenu";

    // Metodo para comprobar el contenido de los campos e insertar un nuevo registro de formulario de mayores en la BBDD si estan bien
    public void ErrorCheck()
    {
        // vuelvo el contenido que tendrán los campos de la Escena Formulario Mayores en sus variables
        nombreAdulto = nombre_IF.text;
        apellido1Adulto = apellido1_IF.text;
        apellido2Adulto = apellido2_IF.text;
        dniAdulto = dni_IF.text;
        telefonoAdulto = telefono_IF.text;
        direccionAdulto = direccion_IF.text;
        emailAdulto = email_IF.text;
        fNacimientoAdulto = fNacimiento_T.text;
        nombreTatuador = nombreTatuador_IF.text;
        estiloTatuaje = Dd_estiloTatuaje.options[Dd_estiloTatuaje.value].text;

        // Creo objeto de la clase LlamaBBDD para poder usar sus metodos
        connector = gameObject.AddComponent<LlamarBBDD>();
        // Uso el metodo AbrirBBDD() de la clase LlamarBBDD para asegurarme de estar conectado a la BBDD
        connector.AbrirBBDD(URIDatabase);

        // If para comprobar que no hay campos vacios y si los hay se mostrara mensaje de error en pantalla en forma de X al lado del campo sin rellenar
        if (nombreAdulto.Equals(""))
        {
            t_ErrorNombreA.text = "X";
        }
        else
        {
            t_ErrorNombreA.text = "";
        }
        if (apellido1Adulto.Equals(""))
        {
            t_ErrorApellido1A.text = "X";
        }
        else
        {
            t_ErrorApellido1A.text = "";
        }
        if (apellido2Adulto.Equals(""))
        {
            t_ErrorApellido2A.text = "X";
        }
        else
        {
            t_ErrorApellido2A.text = "";
        }
        if (dniAdulto.Equals(""))
        {
            t_ErrorDniA.text = "X";
        }
        else
        {
            t_ErrorDniA.text = "";
        }
        if (direccionAdulto.Equals(""))
        {
            t_ErrorDireccionA.text = "X";
        }
        else
        {
            t_ErrorDireccionA.text = "";
        }
        if (telefonoAdulto.Equals(""))
        {
            t_ErrorTelefonoA.text = "X";
        }
        else
        {
            t_ErrorTelefonoA.text = "";
        }
        if (fNacimientoAdulto.Equals("") || fNacimientoAdulto.Equals("00 / 00 / 0000"))
        {
            t_ErrorFNacimientoA.text = "X";
        }
        else
        {
            t_ErrorFNacimientoA.text = "";
        }
        if (nombreTatuador.Equals(""))
        {
            t_ErrorNombreT.text = "X";
        }
        else
        {
            t_ErrorNombreT.text = "";
        }

        // If para comprobar si los Toggle de la Escena Formulario Mayores de Unity estan marcados o no
        if (Cb_tension.isOn)
        {
            tensionAdulto = marcado;
        }
        else
        {
            tensionAdulto = desmarcado;
        }

        if (Cb_problemas.isOn)
        {
            cardiacosAdulto = marcado;
        }
        else
        {
            cardiacosAdulto = desmarcado;
        }

        if (Cb_epilepsia.isOn)
        {
            epilepsiaAdulto = marcado;
        }
        else
        {
            epilepsiaAdulto = desmarcado;
        }

        if (Cb_alergias.isOn)
        {
            alergiasAdulto = marcado;
        }
        else
        {
            alergiasAdulto = desmarcado;
        }

        if (Cb_vih.isOn)
        {
            vihAdulto = marcado;
        }
        else
        {
            vihAdulto = desmarcado;
        }

        if (Cb_hepatitis.isOn)
        {
            hepatitisAdulto = marcado;
        }
        else
        {
            hepatitisAdulto = desmarcado;
        }

        if (Cb_piel.isOn)
        {
            pielAdulto = marcado;
        }
        else
        {
            pielAdulto = desmarcado;
        }

        if (Cb_otros.isOn)
        {
            otrosAdulto = marcado;
        }
        else
        {
            otrosAdulto = desmarcado;
        }
        if (Cb_AceptoTerminos.isOn)
        {
            t_ErrorTerminos.text = "";
            AceptoTerminos = marcado;          
        }
        else
        {
            t_ErrorTerminos.text = "X";
            AceptoTerminos = desmarcado;
        }

        if (Cb_EstudioNoResponsable.isOn)
        {
            t_ErrorCondiciones.text = "";
            EstudioNoResponsable = marcado;
        }
        else
        {
            t_ErrorCondiciones.text = "X";
            EstudioNoResponsable = desmarcado;
        }

        //If para comprobar que no hay campos vacios. Si todos tienen contenido se creara y guardara un nuevo formulario de mayores en la BBDD llamando al metodo InsertarDatosFormularioMayores() de la clase LlamarBBDD  
        if (!nombreAdulto.Equals("") && !apellido1Adulto.Equals("") && !apellido2Adulto.Equals("") && !dniAdulto.Equals("") && !direccionAdulto.Equals("") && !telefonoAdulto.Equals("") && !fNacimientoAdulto.Equals("") && !nombreTatuador.Equals("") && !estiloTatuaje.Equals("") && AceptoTerminos.Equals(marcado) && EstudioNoResponsable.Equals(marcado) )
        {
            connector.InsertarDatosFormularioMayores(nombreAdulto, apellido1Adulto, apellido2Adulto, dniAdulto, direccionAdulto, telefonoAdulto, fNacimientoAdulto, emailAdulto, tensionAdulto, cardiacosAdulto, epilepsiaAdulto, alergiasAdulto, vihAdulto, hepatitisAdulto, pielAdulto, otrosAdulto,nombreTatuador,estiloTatuaje, AceptoTerminos, EstudioNoResponsable);
            cambiarEscena(nombreEscena);
        }
        else
        {
            Debug.Log("Rellena los campos pedazo de insensato");
            
        }
    }

    // Metodo para cambiar de Escena (Introducir nombre de la Escena a la que se quiere ir)
    public void cambiarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }

}
