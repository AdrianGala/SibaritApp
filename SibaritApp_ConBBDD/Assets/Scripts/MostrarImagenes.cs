using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using UnityEngine.SceneManagement;
//using SQLite4Unity3d;
using System;
using System.IO;
using System.Data;
using UnityEngine.UI;
using System;
using System.Drawing;

public class MostrarImagenes : MonoBehaviour
{
    public string URIDatabase;
    private LlamarBBDD connector;
    public Image foto;

    // Start is called before the first frame update
    void Start()
    {
        connector = gameObject.AddComponent<LlamarBBDD>();
        connector.AbrirBBDD(URIDatabase);

        Debug.Log("Conectado");

        connector.SeleccionarImagenes();
        Debug.Log("Leido");

    }

}
