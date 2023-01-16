/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccesoBBDD : MonoBehaviour
{
    public string URIDatabase;

    private LlamarBBDD connector;

    

    void Start()
    {
        connector = gameObject.AddComponent<LlamarBBDD>();

        connector.AbrirBBDD("URI=file:Assets\\BBDD\\"+URIDatabase);
        connector.InsertarDatos("rubio","1234");
        connector.SeleccionarDatos();
        connector.ActualizarDatos("adri");
        connector.SeleccionarDatos();
        connector.CerrarBBDD();
    }
}*/
