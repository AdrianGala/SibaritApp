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
using System.Drawing;

public class LlamarBBDD : MonoBehaviour
{
    private SqliteConnection conexion;
    private SqliteCommand command;
    private SqliteDataReader reader;
    private string query;
    private string valor1, valor2,valor3,valor4;
    private string nombreAdulto, apellido1Adulto, apellido2Adulto, dniAdulto, direccionAdulto, telefonoAdulto, fNacimientoAdulto, emailAdulto, tensionAdulto, cardiacosAdulto, epilepsiaAdulto, alergiasAdulto, vihAdulto, hepatitisAdulto, pielAdulto, otrosAdulto;
    private string nombreTatuador, estiloTatuaje, aceptoTerminos,estudioNoResponsable;
    private string nombreMenor, apellido1Menor, apellido2Menor, dniMenor, direccionMenor, telefonoMenor, fNacimientoMenor, emailMenor, tensionMenor, cardiacosMenor, epilepsiaMenor, alergiasMenor, vihMenor, hepatitisMenor, pielMenor, otrosMenor;
    private string mensajeAlerta;
    private bool valido;
    public string textoAlerta;
    public Text t_Alerta;
    private Image foto;
    //private string conn;
    //private IDbConnection dbconn;
    //private IDbCommand dbcmd = null;

    /*public void Start()
    {
        StartCoroutine(AbrirBBDD("BBDD_Sibarita.db"));
    }*/


    public void AbrirBBDD(string nombreBBDD)
    {
        //Esta funciona en el ordenador
        query = "URI=file://" + Application.dataPath + "/BBDD/" + nombreBBDD; //Path to database.
        conexion = new SqliteConnection(query);
        conexion.Open(); //Open connection to the database.


        //Where to copy the db to
        /*string dbDestination = Path.Combine(Application.persistentDataPath, "data");
        dbDestination = Path.Combine(dbDestination, nombreBBDD);

        //Check if the File do not exist then copy it
        if (!File.Exists(dbDestination))
        {
            //Where the db file is at
            string dbStreamingAsset = Path.Combine(Application.streamingAssetsPath, nombreBBDD);

            byte[] result;

            //Read the File from streamingAssets. Use WWW for Android
            if (dbStreamingAsset.Contains("://") || dbStreamingAsset.Contains(":///"))
            {
                WWW www = new WWW(dbStreamingAsset);
                yield return www;
                result = www.bytes;
            }
            else
            {
                result = File.ReadAllBytes(dbStreamingAsset);
            }
            Debug.Log("Loaded db file");

            //Create Directory if it does not exist
            if (!Directory.Exists(Path.GetDirectoryName(dbDestination)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(dbDestination));
            }

            //Copy the data to the persistentDataPath where the database API can freely access the file
            File.WriteAllBytes(dbDestination, result);
            Debug.Log("Copied db file");
        }

        try
        {
            //Tell the db final location for debugging
            Debug.Log("DB Path: " + dbDestination.Replace("/", "\\"));
            //Add "URI=file:" to the front of the url beore using it with the Sqlite API
            dbDestination = "URI=file:" + dbDestination;

            //Now you can do the database operation below
            //open db connection
            var connection = new SqliteConnection(dbDestination);
            connection.Open();
            conexion = connection;

            var command = connection.CreateCommand();
            Debug.Log("Success!");
        }
        catch (Exception e)
        {
            Debug.Log("Failed: " + e.Message);
        }*/



        //string filepath = Application.dataPath + "/BBDD/" + nombreBBDD;
        //string filepath = "/storage/emulated/0/Android/data/com.DefaultCompany.com.unity.template.mobile2D/files/" + nombreBBDD;
        /*string filepath = Application.persistentDataPath + nombreBBDD;
        Debug.Log(filepath);

        if (!File.Exists(filepath))
        {

            var loadDb = new WWW("jar:file://" + Application.streamingAssetsPath + "/" + nombreBBDD);  // this is the path to your StreamingAssets in android
            Debug.Log(loadDb);
            while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
                                        // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDb.bytes);


        }*/
        //query = "/storage/emulated/0/Android/data/com.DefaultCompany.com.unity.template.mobile2D/files/" + nombreBBDD;
        // query = "URI=file://" + filepath;
        /* query = Application.persistentDataPath + nombreBBDD;
         conexion = new SqliteConnection(query);
         conexion.Open();
         Debug.Log(query);
         Debug.Log("Conectado");*/

        //---------------------------------------------------------------

        //  string filepath = Application.dataPath + "/BBDD/" + nombreBBDD;
        //Debug.Log(filepath);

        //  if (File.Exists(filepath))

        //{

        //  Debug.LogWarning("Estamos File \"" + filepath + "\" does not exist. Attempting to create from \"" + Application.dataPath + "!/assets/" + nombreBBDD);

        // if it doesn't ->

        // open StreamingAssets directory and load the db ->

        //  var loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/" + nombreBBDD);

        // while (!loadDB.isDone) { }

        // then save to Application.persistentDataPath

        // File.WriteAllBytes(filepath, loadDB.bytes);

        // }

        //open db connection

        /* query = "URI=file:" + filepath;

         Debug.Log("Stablishing connection to: " + query);

         conexion = new SqliteConnection(query);

         conexion.Open();

         Debug.Log(filepath);
         Debug.Log("Conectado");*/

        /*var filepath = string.Format("{0}/{1}", Application.persistentDataPath, nombreBBDD);
        var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + nombreBBDD);  // this is the path to your StreamingAssets in android
        while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
                                    // then save to Application.persistentDataPath
        File.WriteAllBytes(filepath, loadDb.bytes);
        conexion = new SqliteConnection(nombreBBDD);
        conexion.Open();*/

        /*conn = "jar:file://" + Application.dataPath + "!/assets/" + nombreBBDD; //Path to database.

        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.*/


        //query = "URI=file://" + Application.dataPath + "!/Assets/BBDD/" + nombreBBDD; //Path to database.
        //query = string.Format("Server={0};port={1};Database={2};User ID={3};Password={4};",ip,puerto,nombreBD,usuarioMySql,contraseñaMySql);
        //  / storage / emulated / 0 / Android / data /< packagename >/ files




        /*if (UNITY_EDITOR)
        { 
            var dbPath = string.Format(@"Assets/StreamingAssets/{0}", nombreBBDD);
            conexion = new SqliteConnection(nombreBBDD);
            conexion.Open();
        }
        else 
        { 
            // check if file exists in Application.persistentDataPath
            var filepath = string.Format("{0}/{1}", Application.persistentDataPath, nombreBBDD);

            if (!File.Exists(filepath))
            {
                Debug.Log("Database not in Persistent path");
                // if it doesn't ->
                // open StreamingAssets directory and load the db ->

                if (UNITY_ANDROID)
                { 
                    var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + nombreBBDD);  // this is the path to your StreamingAssets in android
                    while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
                   
        
        // then save to Application.persistentDataPath

                    File.WriteAllBytes(filepath, loadDb.bytes);
                    conexion = new SqliteConnection(nombreBBDD);
                    conexion.Open();
                }
            }
        }*/
    }

    public string SeleccionarDatos()
    {
        string respuesta = "";
        query = "SELECT * FROM Tatuadores";
        command = conexion.CreateCommand();
        command.CommandText = query;
        reader = command.ExecuteReader();

        if (reader != null)
        {
            while (reader.Read())
            {
                //print(reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString());
                valor3 = reader.GetValue(0).ToString();
                valor4 = reader.GetValue(1).ToString();
                respuesta += valor3 + " " + valor4;
            }
        }
        return respuesta;
    }

    public string SeleccionarDatosMayores()
    {
        string respuesta = "";
        query = "SELECT * FROM ClientesAdultos";
        command = conexion.CreateCommand();
        command.CommandText = query;
        reader = command.ExecuteReader();

        if (reader != null)
        {
            while (reader.Read())
            {
                //print(reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString());
                nombreAdulto = reader.GetValue(0).ToString();
                apellido1Adulto = reader.GetValue(1).ToString();
                apellido2Adulto = reader.GetValue(2).ToString();
                dniAdulto = reader.GetValue(3).ToString();
                direccionAdulto = reader.GetValue(4).ToString();
                telefonoAdulto = reader.GetValue(5).ToString();
                fNacimientoAdulto = reader.GetValue(6).ToString();
                emailAdulto = reader.GetValue(7).ToString();
                tensionAdulto = reader.GetValue(8).ToString();
                cardiacosAdulto = reader.GetValue(9).ToString();
                epilepsiaAdulto = reader.GetValue(10).ToString();
                alergiasAdulto = reader.GetValue(11).ToString();
                vihAdulto = reader.GetValue(12).ToString();
                hepatitisAdulto = reader.GetValue(13).ToString();
                pielAdulto = reader.GetValue(14).ToString();
                otrosAdulto = reader.GetValue(15).ToString();
                nombreTatuador = reader.GetValue(16).ToString();
                estiloTatuaje = reader.GetValue(17).ToString();
                aceptoTerminos = reader.GetValue(18).ToString();
                estudioNoResponsable = reader.GetValue(19).ToString();

                respuesta += nombreAdulto + " " + apellido1Adulto + " " + apellido2Adulto + " " + dniAdulto + " " + direccionAdulto + " " + telefonoAdulto + " " + fNacimientoAdulto + " " + emailAdulto + " " + tensionAdulto + " " + cardiacosAdulto + " " + epilepsiaAdulto + " " + alergiasAdulto + " " + vihAdulto + " " + hepatitisAdulto + " " + pielAdulto + " " + otrosAdulto + " " + nombreTatuador + " " + estiloTatuaje + " " + aceptoTerminos + " " + estudioNoResponsable + "\n\n\n";
            }
        }
        return respuesta;
    }

    public string SeleccionarDatosMenores()
    {
        string respuesta = "";
        query = "SELECT * FROM ClientesMenores";
        command = conexion.CreateCommand();
        command.CommandText = query;
        reader = command.ExecuteReader();

        if (reader != null)
        {
            while (reader.Read())
            {
                //print(reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString());
                nombreAdulto = reader.GetValue(0).ToString();
                apellido1Adulto = reader.GetValue(1).ToString();
                apellido2Adulto = reader.GetValue(2).ToString();
                dniAdulto = reader.GetValue(3).ToString();
                direccionAdulto = reader.GetValue(4).ToString();
                telefonoAdulto = reader.GetValue(5).ToString();
                fNacimientoAdulto = reader.GetValue(6).ToString();
                emailAdulto = reader.GetValue(7).ToString();
                nombreMenor = reader.GetValue(8).ToString();
                apellido1Menor = reader.GetValue(9).ToString();
                apellido2Menor = reader.GetValue(10).ToString();
                dniMenor = reader.GetValue(11).ToString();
                direccionMenor = reader.GetValue(12).ToString();
                telefonoMenor = reader.GetValue(13).ToString();
                fNacimientoMenor = reader.GetValue(14).ToString();
                tensionMenor = reader.GetValue(15).ToString();
                cardiacosMenor = reader.GetValue(16).ToString();
                epilepsiaMenor = reader.GetValue(17).ToString();
                alergiasMenor = reader.GetValue(18).ToString();
                vihMenor = reader.GetValue(19).ToString();
                hepatitisMenor = reader.GetValue(20).ToString();
                pielMenor = reader.GetValue(21).ToString();
                otrosMenor = reader.GetValue(22).ToString();
                nombreTatuador = reader.GetValue(23).ToString();
                estiloTatuaje = reader.GetValue(24).ToString();
                aceptoTerminos = reader.GetValue(25).ToString();
                estudioNoResponsable = reader.GetValue(26).ToString();

                respuesta += nombreAdulto + " " + apellido1Adulto + " " + apellido2Adulto + " " + dniAdulto + " " + direccionAdulto + " " + telefonoAdulto + " " + fNacimientoAdulto + " " + nombreMenor + " " + apellido1Menor + " " + apellido2Menor + " " + dniMenor + " " + direccionMenor + " " + telefonoMenor + " " + fNacimientoMenor + " " + emailMenor + " " + tensionMenor + " " + cardiacosMenor + " " + epilepsiaMenor + " " + alergiasMenor + " " + vihMenor + " " + hepatitisMenor + " " + pielMenor + " " + otrosMenor + " " + nombreTatuador + " " + estiloTatuaje + " " + aceptoTerminos + " " + estudioNoResponsable + "\n\n\n";
            }
        }
        return respuesta;
    }

    public string FiltrarAdultos(string filtro)
    {
        string respuesta = "";
        query = "SELECT * FROM ClientesAdultos where NombreAdulto like '%" + filtro + "%'";
        command = conexion.CreateCommand();
        command.CommandText = query;
        reader = command.ExecuteReader();

        if (reader != null)
        {
            while (reader.Read())
            {
                nombreAdulto = reader.GetValue(0).ToString();
                apellido1Adulto = reader.GetValue(1).ToString();
                apellido2Adulto = reader.GetValue(2).ToString();
                dniAdulto = reader.GetValue(3).ToString();
                direccionAdulto = reader.GetValue(4).ToString();
                telefonoAdulto = reader.GetValue(5).ToString();
                fNacimientoAdulto = reader.GetValue(6).ToString();
                emailAdulto = reader.GetValue(7).ToString();
                tensionAdulto = reader.GetValue(8).ToString();
                cardiacosAdulto = reader.GetValue(9).ToString();
                epilepsiaAdulto = reader.GetValue(10).ToString();
                alergiasAdulto = reader.GetValue(11).ToString();
                vihAdulto = reader.GetValue(12).ToString();
                hepatitisAdulto = reader.GetValue(13).ToString();
                pielAdulto = reader.GetValue(14).ToString();
                otrosAdulto = reader.GetValue(15).ToString();
                nombreTatuador = reader.GetValue(16).ToString();
                estiloTatuaje = reader.GetValue(17).ToString();
                aceptoTerminos = reader.GetValue(18).ToString();
                estudioNoResponsable = reader.GetValue(19).ToString();

                respuesta += nombreAdulto + " " + apellido1Adulto + " " + apellido2Adulto + " " + dniAdulto + " " + direccionAdulto + " " + telefonoAdulto + " " + fNacimientoAdulto + " " + emailAdulto + " " + tensionAdulto + " " + cardiacosAdulto + " " + epilepsiaAdulto + " " + alergiasAdulto + " " + vihAdulto + " " + hepatitisAdulto + " " + pielAdulto + " " + otrosAdulto + " " + nombreTatuador + " " + estiloTatuaje + " " + aceptoTerminos + " " + estudioNoResponsable + "\n\n\n";
            }
        }
        return respuesta;
    }

    public string FiltrarMenores(string filtro)
    {
        string respuesta = "";
        query = "SELECT * FROM ClientesMenores where NombreAdulto like '%" + filtro + "%' OR NombreMenor like '%" + filtro + "%'";
        command = conexion.CreateCommand();
        command.CommandText = query;
        reader = command.ExecuteReader();

        if (reader != null)
        {
            while (reader.Read())
            {
                //print(reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString());
                nombreAdulto = reader.GetValue(0).ToString();
                apellido1Adulto = reader.GetValue(1).ToString();
                apellido2Adulto = reader.GetValue(2).ToString();
                dniAdulto = reader.GetValue(3).ToString();
                direccionAdulto = reader.GetValue(4).ToString();
                telefonoAdulto = reader.GetValue(5).ToString();
                fNacimientoAdulto = reader.GetValue(6).ToString();
                emailAdulto = reader.GetValue(7).ToString();
                nombreMenor = reader.GetValue(8).ToString();
                apellido1Menor = reader.GetValue(9).ToString();
                apellido2Menor = reader.GetValue(10).ToString();
                dniMenor = reader.GetValue(11).ToString();
                direccionMenor = reader.GetValue(12).ToString();
                telefonoMenor = reader.GetValue(13).ToString();
                fNacimientoMenor = reader.GetValue(14).ToString();
                tensionMenor = reader.GetValue(15).ToString();
                cardiacosMenor = reader.GetValue(16).ToString();
                epilepsiaMenor = reader.GetValue(17).ToString();
                alergiasMenor = reader.GetValue(18).ToString();
                vihMenor = reader.GetValue(19).ToString();
                hepatitisMenor = reader.GetValue(20).ToString();
                pielMenor = reader.GetValue(21).ToString();
                otrosMenor = reader.GetValue(22).ToString();
                nombreTatuador = reader.GetValue(23).ToString();
                estiloTatuaje = reader.GetValue(24).ToString();
                aceptoTerminos = reader.GetValue(25).ToString();
                estudioNoResponsable = reader.GetValue(26).ToString();

                respuesta += nombreAdulto + " " + apellido1Adulto + " " + apellido2Adulto + " " + dniAdulto + " " + direccionAdulto + " " + telefonoAdulto + " " + fNacimientoAdulto + " " + nombreMenor + " " + apellido1Menor + " " + apellido2Menor + " " + dniMenor + " " + direccionMenor + " " + telefonoMenor + " " + fNacimientoMenor + " " + emailMenor + " " + tensionMenor + " " + cardiacosMenor + " " + epilepsiaMenor + " " + alergiasMenor + " " + vihMenor + " " + hepatitisMenor + " " + pielMenor + " " + otrosMenor + " " + nombreTatuador + " " + estiloTatuaje + " " + aceptoTerminos + " " + estudioNoResponsable + "\n\n\n";
            }
        }
        return respuesta;
    }

    public void SeleccionarImagenes()
    {
        var tex = new Texture2D(512, 512);
        string respuesta = "";
        query = "SELECT Imagen FROM Imagenes";
        command = conexion.CreateCommand();
        command.CommandText = query;
        reader = command.ExecuteReader();
         
        
        if (reader != null)
        {
            while (reader.Read())
            {
                byte[] img = (byte[])reader["Imagen"];


                Debug.Log(img[1]);


                string imageBase64 = Convert.ToBase64String(img);

               // string imagenNormal = Conver

                string hex = BitConverter.ToString(img).Replace("-", string.Empty);

                //  string imageHex = Convert.ToHex(img);

               // string cadena = "X'"+hex+"'"; 

                //Debug.Log(cadena);

                // byte[] bytes = (byte[])System.Convert.FromBase64String(imageBase64);

                Debug.Log(imageBase64);
                InsertarImagen(hex, "Color");
                Debug.Log("EEEIIIII1");
               // tex.LoadImage(imageBase64);
                // image 266x199
                GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0, 0, 266, 199), new Vector2(0.5f, 0.5f));
                Debug.Log("EEEIIIII");


                ////Convert Byte[] to Base64, you can store Base64String to the Sqlite DB  
                ///

               // var result = GetFileBytes(PhotoPath);


   


                //Convert Base64string to Stream.  

                
                //Foto.Source = ImageSource.FromStream(() => new MemoryStream(bytes));
            }
        }
    }

    public void InsertarImagen(string imagen,string estilo)
    {
        query = "INSERT INTO Imagenes VALUES('" + imagen + "', '" + estilo + "')";
        command = conexion.CreateCommand();
        command.CommandText = query;
        command.ExecuteReader();
    }

    public void BorrarAdultos(string nombreBBDD, string borrar)
    {
        conexion = new SqliteConnection("URI=file://" + Application.dataPath + "/BBDD/" + nombreBBDD);
        conexion.Open();
        query = "DELETE FROM ClientesAdultos WHERE NombreAdulto like '"+ borrar + "%'";
        command = conexion.CreateCommand();
        command = new SqliteCommand(query,conexion);
        command.ExecuteNonQuery();
        
    }

    public void BorrarMenores(string nombreBBDD,string borrar)
    {
        conexion = new SqliteConnection("URI=file://" + Application.dataPath + "/BBDD/" + nombreBBDD);
        conexion.Open();
        query = "DELETE FROM ClientesMenores WHERE NombreAdulto like '" + borrar + "%' OR NombreMenor like '" + borrar + "%'";
        command = conexion.CreateCommand();
        command = new SqliteCommand(query, conexion);
        command.ExecuteNonQuery();
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

    public void InsertarDatosFormularioMayores(string nombreAdulto, string apellido1Adulto, string apellido2Adulto, string dniAdulto, string direccionAdulto, string telefonoAdulto, string fNacimientoAdulto, string emailAdulto, string tensionAdulto, string cardiacosAdulto, string epilepsiaAdulto, string alergiasAdulto, string vihAdulto, string hepatitisAdulto, string pielAdulto, string otrosAdulto,string nombreTatuador, string estiloTatuaje, string aceptoTerminos, string estudioNoResponsable)
    {
        query = "INSERT INTO ClientesAdultos VALUES('" + nombreAdulto + "', '" + apellido1Adulto + "', '" + apellido2Adulto + "', '" + dniAdulto + "', '" + direccionAdulto + "', '" + telefonoAdulto + "', '" + fNacimientoAdulto + "', '" + emailAdulto + "', '" + tensionAdulto + "', '" + cardiacosAdulto + "', '" + epilepsiaAdulto + "', '" + alergiasAdulto + "', '" + vihAdulto + "', '" + hepatitisAdulto + "', '" + pielAdulto + "', '" + otrosAdulto + "', '" + nombreTatuador + "', '" + estiloTatuaje + "','" + aceptoTerminos + "', '" + estudioNoResponsable + "')";
        command = conexion.CreateCommand();
        command.CommandText = query;
        command.ExecuteReader();
    }

    public void InsertarDatosFormularioMenores(string nombreAdulto, string apellido1Adulto, string apellido2Adulto, string dniAdulto, string direccionAdulto, string telefonoAdulto, string fNacimientoAdulto, string emailAdulto, string nombreMenor, string apellido1Menor, string apellido2Menor, string dniMenor, string direccionMenor, string telefonoMenor, string fNacimientoMenor, string tensionMenor, string cardiacosMenor, string epilepsiaMenor, string alergiasMenor, string vihMenor, string hepatitisMenor, string pielMenor, string otrosMenor, string nombreTatuador, string estiloTatuaje, string aceptoTerminos, string estudioNoResponsable)
    {
        query = "INSERT INTO ClientesMenores VALUES('" + nombreAdulto + "', '" + apellido1Adulto + "', '" + apellido2Adulto + "', '" + dniAdulto + "', '" + direccionAdulto + "', '" + telefonoAdulto + "', '" + fNacimientoAdulto + "', '" + emailAdulto + "', '" + nombreMenor + "', '" + apellido1Menor + "', '" + apellido2Menor + "', '" + dniMenor + "', '" + direccionMenor + "', '" + telefonoMenor + "', '" + fNacimientoMenor + "', '" + tensionMenor + "', '" + cardiacosMenor + "', '" + epilepsiaMenor + "', '" + alergiasMenor + "', '" + vihMenor + "', '" + hepatitisMenor + "', '" + pielMenor + "', '" + otrosMenor + "', '" + nombreTatuador + "', '" + estiloTatuaje + "','" + aceptoTerminos + "', '" + estudioNoResponsable + "')";
        command = conexion.CreateCommand();
        command.CommandText = query;
        command.ExecuteReader();
    }



    public void InsertarDatosTatuador(string nombre, string apellido1, string apellido2, string dni, string telefono, string direccion, string email, string fNacimiento, string usuario, string contraseña)
    {
        
        query = "INSERT INTO Tatuadores VALUES('" + nombre + "', '" + apellido1 + "', '" + apellido2 + "', '" + dni + "', '" + telefono + "', '" + direccion + "', '" + email + "', '" + fNacimiento + "', '" + usuario + "', '" + contraseña + "')";
        command = conexion.CreateCommand();
        command.CommandText = query;
        try 
        { 
            command.ExecuteReader();
        
        } catch(SqliteException e) 
        {
           t_Alerta.text = "Usuario ya existe";
        }
        
    }

    public bool ComprobarCamposLogin(string usuario, string contraseña,string nombreEscena)
    { 
        
        query = "SELECT Usuario, Contraseña FROM Tatuadores";

        //          query = "INSERT INTO Tatuadores VALUES('" + usuario + "', '" + contraseña + "')";

        //          query = "SELECT * FROM Tatuadores WHERE Usuario=" + usuario + " AND Contraseña=" + contraseña + ";

        command = conexion.CreateCommand();
        command.CommandText = query;
        reader = command.ExecuteReader();
    
        if (reader != null)
        {
        
            while (reader.Read())
            {
                string usuarioLeido = reader.GetValue(0).ToString();
                string contraseñaLeida = reader.GetValue(1).ToString();
                if (usuarioLeido.Equals(usuario) && contraseñaLeida.Equals(contraseña) && !usuario.Equals("") && !contraseña.Equals("")) 
                {
                    valido = true;
                    SceneManager.LoadScene(nombreEscena);
                }
                else
                {
                    valido = false;
                    //mensajeAlerta = "Usuario o Contraseña Incorrectas";
                }
            }    
                   
        }
        return valido;
        
    }
    
}               
