using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Data;
using UnityEngine.UI;
using System.Drawing;


public class LlamarBBDD : MonoBehaviour
{
    // Campos declarados
    private SqliteConnection conexion;
    private SqliteCommand command;
    private SqliteDataReader reader;
    private string query;
    private string UsuarioRecuperado,ContraseñaRecuperada;
    private string nombreAdulto, apellido1Adulto, apellido2Adulto, dniAdulto, direccionAdulto, telefonoAdulto, fNacimientoAdulto, emailAdulto, tensionAdulto, cardiacosAdulto, epilepsiaAdulto, alergiasAdulto, vihAdulto, hepatitisAdulto, pielAdulto, otrosAdulto;
    private string nombreTatuador, estiloTatuaje, aceptoTerminos,estudioNoResponsable;
    private string nombreMenor, apellido1Menor, apellido2Menor, dniMenor, direccionMenor, telefonoMenor, fNacimientoMenor, emailMenor, tensionMenor, cardiacosMenor, epilepsiaMenor, alergiasMenor, vihMenor, hepatitisMenor, pielMenor, otrosMenor;
    private string mensajeAlerta;
    private bool valido;
    private Text t_Alerta;
    public string URIDatabase;

    // Metodo para abrir la Base de datos
    public void AbrirBBDD(string nombreBBDD)
    {
        //Abre la conexion con la base de datos si se ejecuta desde un ordenador
        query = "URI=file://" + Application.dataPath + "/BBDD/" + nombreBBDD; //Path to database.
        conexion = new SqliteConnection(query);
        conexion.Open(); 

        //-------------------ESTA PARTE DEBERIA HACER QUE LA BASE DE DATOS SE EJECUTASE EN UN DISPOSITIVO MOVIL PERO NO ME FUNCIONA------------------------------------
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

        //-------------------ESTA PARTE ES OTRA FORMA QUE DEBERIA HACER QUE LA BASE DE DATOS SE EJECUTASE EN UN DISPOSITIVO MOVIL PERO TAMPOCO ME FUNCIONA ME FUNCIONA------------------------------------
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

    // Este metodo devuelve todos los datos de los tatuadores
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
                UsuarioRecuperado = reader.GetValue(0).ToString();
                ContraseñaRecuperada = reader.GetValue(1).ToString();
                respuesta += UsuarioRecuperado + " " + ContraseñaRecuperada;
            }
        }
        return respuesta;
    }

    // Este metodo mete en variables todos los datos de los ClientesAdultos y los devuelve 
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

    // Este metodo mete en variables todos los datos de los ClientesMenores y los devuelve 
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

    // Este metodo filtra los ClientesAdultos por su nombre con el string que recibe del texto filtrar en Unity y devuelve los filtrados
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

    // Este metodo filtra los ClientesMenores por su nombre o por el nombre del adulto que le autorizo con el string que recibe del texto filtrar en Unity y devuelve los filtrados
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

    // Este metodo carga la imagenes según la seleccion que reciba en la Query 
    // Necesita recibir un GameObject que sera la Canvas de mi pantalla Unity para poder crear los cuadros Image en ella
    public void SeleccionarImagenes(GameObject canvas,string myquery)
    {
        // Declaro Campos necesarios
        var tex = new Texture2D(512, 512);
        string path;
        query = myquery;
        command = conexion.CreateCommand();
        command.CommandText = query;
        reader = command.ExecuteReader();
        Texture2D nuevaTextura;

        int x = 200;
        int y = 1500;
        int contadorX = 0;
        int contadorY = 0;

        if (reader != null)
        {
             while (reader.Read())
             {
                if (contadorY <= 3)
                {
                    contadorX++;

                    // Creo un GameObject que sera donde ira la Imagen
                    GameObject imgObject = new GameObject("MiCuadroImagen");
                    // Declaro las posiciones y el tamaño que tendrá el GameObject que reciba la imagen
                    RectTransform trans = imgObject.AddComponent<RectTransform>();
                    trans.anchoredPosition = new Vector2(0.5f, 0.5f);
                    trans.localPosition = new Vector3(0, 0, 0);
                    trans.position = new Vector3(x, y, 0);
                    trans.sizeDelta = new Vector2(310, 310);

                    // Creo la Imagen con sus texturas y la agrego al GameObject creado
                    Image image = imgObject.AddComponent<Image>();
                    path = reader.GetValue(0).ToString();
                    nuevaTextura = NativeGallery.LoadImageAtPath(path, 512);
                    image.sprite = Sprite.Create(nuevaTextura, new Rect(0, 0, nuevaTextura.width, nuevaTextura.height), new Vector2(.5f, .5f));
                    imgObject.transform.SetParent(canvas.transform);

                    //Control de la posicion de las imagenes
                    x = x + 350;
                    if (contadorX >= 3)
                    {
                        x = 200;
                        y = y - 500;
                        contadorX = 0;
                        contadorY++;
                    }

                }
            }
        }
    }

    // Metodo para Insertar las Imagenes en la base de datos
    public void InsertarImagen(string imagen,string estilo)
    {
        query = "INSERT INTO Imagenes VALUES('" + imagen + "', '" + estilo + "')";
        command = conexion.CreateCommand();
        command.CommandText = query;
        command.ExecuteReader();
    }

    // Metodo para borrar ClientesAdultos de la base de datos
    public void BorrarAdultos(string nombreBBDD, string borrar)
    {
        conexion = new SqliteConnection("URI=file://" + Application.dataPath + "/BBDD/" + nombreBBDD);
        conexion.Open();
        query = "DELETE FROM ClientesAdultos WHERE NombreAdulto like '"+ borrar + "%'";
        command = conexion.CreateCommand();
        command = new SqliteCommand(query,conexion);
        command.ExecuteNonQuery();
        
    }
    // Metodo para borrar ClientesMenores de la base de datos
    public void BorrarMenores(string nombreBBDD,string borrar)
    {
        conexion = new SqliteConnection("URI=file://" + Application.dataPath + "/BBDD/" + nombreBBDD);
        conexion.Open();
        query = "DELETE FROM ClientesMenores WHERE NombreAdulto like '" + borrar + "%' OR NombreMenor like '" + borrar + "%'";
        command = conexion.CreateCommand();
        command = new SqliteCommand(query, conexion);
        command.ExecuteNonQuery();
    }

    // Metodo para borrar InsertarDatos segun la query recibida de la base de datos
    public void InsertarDatos(string myquery, string usuario, string contraseña)
    {
        query = myquery;
        command = conexion.CreateCommand();
        command.CommandText = query;
        command.ExecuteReader();
    }

    //Metodo para recargar los datos de la base de datos
    public void ActualizarDatos(string usuario, string myquery)
    {

        query = myquery;
        command = conexion.CreateCommand();
        command.CommandText = query;
        command.ExecuteReader();
    }
    // Metodo para cerrar todas las conexiones de la base de datos
    public void CerrarBBDD()
    {
        reader.Close();
        reader = null;
        command = null;
        conexion.Close();
        conexion = null;
    }

    // Metodo para inserta ClientesAdultos de la base de datos
    public void InsertarDatosFormularioMayores(string nombreAdulto, string apellido1Adulto, string apellido2Adulto, string dniAdulto, string direccionAdulto, string telefonoAdulto, string fNacimientoAdulto, string emailAdulto, string tensionAdulto, string cardiacosAdulto, string epilepsiaAdulto, string alergiasAdulto, string vihAdulto, string hepatitisAdulto, string pielAdulto, string otrosAdulto,string nombreTatuador, string estiloTatuaje, string aceptoTerminos, string estudioNoResponsable)
    {
        query = "INSERT INTO ClientesAdultos VALUES('" + nombreAdulto + "', '" + apellido1Adulto + "', '" + apellido2Adulto + "', '" + dniAdulto + "', '" + direccionAdulto + "', '" + telefonoAdulto + "', '" + fNacimientoAdulto + "', '" + emailAdulto + "', '" + tensionAdulto + "', '" + cardiacosAdulto + "', '" + epilepsiaAdulto + "', '" + alergiasAdulto + "', '" + vihAdulto + "', '" + hepatitisAdulto + "', '" + pielAdulto + "', '" + otrosAdulto + "', '" + nombreTatuador + "', '" + estiloTatuaje + "','" + aceptoTerminos + "', '" + estudioNoResponsable + "')";
        command = conexion.CreateCommand();
        command.CommandText = query;
        command.ExecuteReader();
    }

    // Metodo para inserta ClientesMenores de la base de datos
    public void InsertarDatosFormularioMenores(string nombreAdulto, string apellido1Adulto, string apellido2Adulto, string dniAdulto, string direccionAdulto, string telefonoAdulto, string fNacimientoAdulto, string emailAdulto, string nombreMenor, string apellido1Menor, string apellido2Menor, string dniMenor, string direccionMenor, string telefonoMenor, string fNacimientoMenor, string tensionMenor, string cardiacosMenor, string epilepsiaMenor, string alergiasMenor, string vihMenor, string hepatitisMenor, string pielMenor, string otrosMenor, string nombreTatuador, string estiloTatuaje, string aceptoTerminos, string estudioNoResponsable)
    {
        query = "INSERT INTO ClientesMenores VALUES('" + nombreAdulto + "', '" + apellido1Adulto + "', '" + apellido2Adulto + "', '" + dniAdulto + "', '" + direccionAdulto + "', '" + telefonoAdulto + "', '" + fNacimientoAdulto + "', '" + emailAdulto + "', '" + nombreMenor + "', '" + apellido1Menor + "', '" + apellido2Menor + "', '" + dniMenor + "', '" + direccionMenor + "', '" + telefonoMenor + "', '" + fNacimientoMenor + "', '" + tensionMenor + "', '" + cardiacosMenor + "', '" + epilepsiaMenor + "', '" + alergiasMenor + "', '" + vihMenor + "', '" + hepatitisMenor + "', '" + pielMenor + "', '" + otrosMenor + "', '" + nombreTatuador + "', '" + estiloTatuaje + "','" + aceptoTerminos + "', '" + estudioNoResponsable + "')";
        command = conexion.CreateCommand();
        command.CommandText = query;
        command.ExecuteReader();
    }

    // Metodo para inserta un nuevo tatuador de la base de datos
    public void InsertarDatosTatuador(string nombre, string apellido1, string apellido2, string dni, string telefono, string direccion, string email, string fNacimiento, string usuario, string contraseña,string errorUsuario)
    {   
        query = "INSERT INTO Tatuadores VALUES('" + nombre + "', '" + apellido1 + "', '" + apellido2 + "', '" + dni + "', '" + telefono + "', '" + direccion + "', '" + email + "', '" + fNacimiento + "', '" + usuario + "', '" + contraseña + "')";
        command = conexion.CreateCommand();
        command.CommandText = query;
        try 
        {
            command.ExecuteReader();
            
        } catch(SqliteException e) 
        {
           t_Alerta.text = errorUsuario;
            Debug.Log(e);
        }
        
    }
    
    //Metodo booleano para comprobar los campos del Login de la aplicacion
    public bool ComprobarCamposLogin(string usuario, string contraseña,string nombreEscena)
    { 
        
        query = "SELECT Usuario, Contraseña FROM Tatuadores";
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
