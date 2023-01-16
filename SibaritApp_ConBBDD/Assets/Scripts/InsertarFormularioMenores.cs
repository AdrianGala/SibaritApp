using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class InsertarFormularioMenores : MonoBehaviour
{
    // Campos declarados
    public InputField nombreAdulto_IF, apellido1Adulto_IF, apellido2Adulto_IF, dniAdulto_IF, telefonoAdulto_IF, direccionAdulto_IF, emailAdulto_IF;
    private string nombreAdulto, apellido1Adulto, apellido2Adulto, dniAdulto, direccionAdulto, telefonoAdulto, fNacimientoAdulto, emailAdulto;

    public InputField nombreMenor_IF, apellido1Menor_IF, apellido2Menor_IF, dniMenor_IF, telefonoMenor_IF, direccionMenor_IF, nombreTatuador_IF;
    private string nombreMenor, apellido1Menor, apellido2Menor, dniMenor, direccionMenor, telefonoMenor, fNacimientoMenor, tensionMenor, cardiacosMenor, epilepsiaMenor, alergiasMenor, vihMenor, hepatitisMenor, pielMenor, otrosMenor, nombreTatuador, estiloTatuaje;
    public Text fNacimientoAdulto_T,fNacimientoMenor_T;
    public Text t_ErrorNombreA, t_ErrorApellido1A, t_ErrorApellido2A, t_ErrorDniA, t_ErrorDireccionA, t_ErrorTelefonoA, t_ErrorFNacimientoA, t_ErrorNombreT, t_ErrorTerminos, t_ErrorCondiciones;
    public Text t_ErrorNombreM, t_ErrorApellido1M, t_ErrorApellido2M, t_ErrorDniM, t_ErrorDireccionM, t_ErrorTelefonoM, t_ErrorFNacimientoM;

    public Toggle Cb_tension;
    public Toggle Cb_problemas;
    public Toggle Cb_epilepsia;
    public Toggle Cb_alergias;
    public Toggle Cb_vih;
    public Toggle Cb_hepatitis;
    public Toggle Cb_piel;
    public Toggle Cb_otros;
    
    public string marcado = "si";
    public string desmarcado = "no";
    
    public Dropdown Dd_estiloTatuaje;

    public Toggle Cb_AceptoTerminos;
    public Toggle Cb_EstudioNoResponsable;
    private string AceptoTerminos, EstudioNoResponsable;

    public string URIDatabase;
    private LlamarBBDD connector;
    private string nombreEscena = "EscenaMenu";

    // Metodo para comprobar el contenido de los campos e insertar un nuevo registro de formulario de menores en la BBDD si estan bien
    public void ComprobacionEInsercion()
    {
        // vuelvo el contenido que tendrán los campos de la Escena Formulario Menores en sus variables
        nombreAdulto = nombreAdulto_IF.text;
        apellido1Adulto = apellido1Adulto_IF.text;
        apellido2Adulto = apellido2Adulto_IF.text;
        dniAdulto = dniAdulto_IF.text;
        telefonoAdulto = telefonoAdulto_IF.text;
        direccionAdulto = direccionAdulto_IF.text;
        emailAdulto = emailAdulto_IF.text;
        fNacimientoAdulto = fNacimientoAdulto_T.text;

        nombreMenor = nombreMenor_IF.text;
        apellido1Menor = apellido1Menor_IF.text;
        apellido2Menor = apellido2Menor_IF.text;
        dniMenor = dniMenor_IF.text;
        telefonoMenor = telefonoMenor_IF.text;
        direccionMenor = direccionMenor_IF.text;
        fNacimientoMenor = fNacimientoMenor_T.text;

        nombreTatuador = nombreTatuador_IF.text;
        estiloTatuaje = Dd_estiloTatuaje.options[Dd_estiloTatuaje.value].text;

        // Creo objeto de la clase LlamaBBDD para poder usar sus metodos
        connector = gameObject.AddComponent<LlamarBBDD>();
        // Uso el metodo AbrirBBDD() de la clase LlamarBBDD para asegurarme de estar conectado a la BBDD
        connector.AbrirBBDD(URIDatabase);

        // If para comprobar que no hay campos vacios de los adultos y si los hay se mostrara mensaje de error en pantalla en forma de X al lado del campo sin rellenar
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

        // If para comprobar que no hay campos vacios de los menores y si los hay se mostrara mensaje de error en pantalla en forma de X al lado del campo sin rellenar
        if (nombreMenor.Equals(""))
        {
            t_ErrorNombreM.text = "X";
        }
        else
        {
            t_ErrorNombreM.text = "";
        }
        if (apellido1Menor.Equals(""))
        {
            t_ErrorApellido1M.text = "X";
        }
        else
        {
            t_ErrorApellido1M.text = "";
        }
        if (apellido2Menor.Equals(""))
        {
            t_ErrorApellido2M.text = "X";
        }
        else
        {
            t_ErrorApellido2M.text = "";
        }
        if (dniMenor.Equals(""))
        {
            t_ErrorDniM.text = "X";
        }
        else
        {
            t_ErrorDniM.text = "";
        }
        if (direccionMenor.Equals(""))
        {
            t_ErrorDireccionM.text = "X";
        }
        else
        {
            t_ErrorDireccionM.text = "";
        }
        if (telefonoMenor.Equals(""))
        {
            t_ErrorTelefonoM.text = "X";
        }
        else
        {
            t_ErrorTelefonoM.text = "";
        }
        if (fNacimientoMenor.Equals("") || fNacimientoMenor.Equals("00 / 00 / 0000"))
        {
            t_ErrorFNacimientoM.text = "X";
        }
        else
        {
            t_ErrorFNacimientoM.text = "";
        }

        // If para comprobar si los Toggle de la Escena Formulario Menores de Unity estan marcados o no
        if (Cb_tension.isOn)
        {
            tensionMenor = marcado;
        }
        else
        {
            tensionMenor = desmarcado;
        }

        if (Cb_problemas.isOn)
        {
            cardiacosMenor = marcado;
        }
        else
        {
            cardiacosMenor = desmarcado;
        }

        if (Cb_epilepsia.isOn)
        {
            epilepsiaMenor = marcado;
        }
        else
        {
            epilepsiaMenor = desmarcado;
        }

        if (Cb_alergias.isOn)
        {
            alergiasMenor = marcado;
        }
        else
        {
            alergiasMenor = desmarcado;
        }

        if (Cb_vih.isOn)
        {
            vihMenor = marcado;
        }
        else
        {
            vihMenor = desmarcado;
        }

        if (Cb_hepatitis.isOn)
        {
            hepatitisMenor = marcado;
        }
        else
        {
            hepatitisMenor = desmarcado;
        }

        if (Cb_piel.isOn)
        {
            pielMenor = marcado;
        }
        else
        {
            pielMenor = desmarcado;
        }

        if (Cb_otros.isOn)
        {
            otrosMenor = marcado;
        }
        else
        {
            otrosMenor = desmarcado;
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

        //If para comprobar que no hay campos vacios. Si todos tienen contenido se creara y guardara un nuevo formulario de menores en la BBDD llamando al metodo InsertarDatosFormularioMenores() de la clase LlamarBBDD
        if (!nombreAdulto.Equals("") && !apellido1Adulto.Equals("") && !apellido2Adulto.Equals("") && !dniAdulto.Equals("") && !direccionAdulto.Equals("") && !telefonoAdulto.Equals("") && !fNacimientoAdulto.Equals("") && !nombreMenor.Equals("") && !apellido1Menor.Equals("") && !apellido2Menor.Equals("") && !dniMenor.Equals("") && !direccionMenor.Equals("") && !telefonoMenor.Equals("") && !fNacimientoMenor.Equals("") && !nombreTatuador.Equals("") && !estiloTatuaje.Equals("") && AceptoTerminos.Equals(marcado) && EstudioNoResponsable.Equals(marcado))
        {
            connector.InsertarDatosFormularioMenores(nombreAdulto, apellido1Adulto, apellido2Adulto, dniAdulto, direccionAdulto, telefonoAdulto, fNacimientoAdulto, emailAdulto, nombreMenor, apellido1Menor, apellido2Menor, dniMenor, direccionMenor, telefonoMenor, fNacimientoMenor, tensionMenor, cardiacosMenor, epilepsiaMenor, alergiasMenor, vihMenor, hepatitisMenor, pielMenor, otrosMenor, nombreTatuador, estiloTatuaje, AceptoTerminos, EstudioNoResponsable);
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
