using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CerrarApp : MonoBehaviour
{
    public void cerrarApp()
    {
        Application.Quit();
        Debug.Log("Adios");
    }
    
    
}
