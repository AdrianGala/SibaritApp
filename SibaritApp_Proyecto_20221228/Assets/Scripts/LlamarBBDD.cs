using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class LlamarBBDD : MonoBehaviour
{
    private SqliteConnection conexion;
    private SqliteCommand command;
    private SqliteDataReader reader;
    private string query;

    public void AbrirBBDD(string nombreBBDD)
    {
        conexion = new SqliteConnection(nombreBBDD);
        conexion.Open();
    }

    public void SeleccionarDatos(string myquery)
    {
        query = myquery;
        command = conexion.CreateCommand();
        command.CommandText = query;
        reader = command.ExecuteReader();

        if (reader != null)
        {
            while (reader.Read())
            {
                print(reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString());
            }
        }
    }

    public void InsertarDatos(string myquery, string usuario, string contraseña)
    {
        query = myquery;
        command = conexion.CreateCommand();
        command.CommandText = query;
        command.ExecuteReader();
    }

    public void ActualizarDatos(string usuario, string myquery)
    {

        query = myquery;
        command = conexion.CreateCommand();
        command.CommandText = query;
        command.ExecuteReader();
    }

    public void CerrarBBDD()
    {
        reader.Close();
        reader = null;
        command = null;
        conexion.Close();
        conexion = null;

    }
}
