using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Drawing;

public class CerrarApp : MonoBehaviour
{

    // Metodo para cerrar la aplicacion
    public void cerrarApp()
    {

        Application.Quit();
        Debug.Log("Adios");
        
    }
    
    
}
