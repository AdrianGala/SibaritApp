using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
   // Metodo para cambiar de Escena (Introducir nombre de la Escena a la que se quiere ir)
   public void cambiarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }
}
