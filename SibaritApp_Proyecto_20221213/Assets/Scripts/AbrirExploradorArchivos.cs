using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class AbrirExploradorArchivos : MonoBehaviour
{
    public Image imagen;
    string[] extensiones = {"image files","png,jpg,jpeg" };

    [ContextMenu("buscarImagen")]

    public void buscarImagen()
    {
        var path = EditorUtility.OpenFilePanelWithFilters("Seleccione una imagen", "",extensiones);

        if (!File.Exists(path))
        {
            return;
        }
        byte[] byteImagen = File.ReadAllBytes(path);
        Texture2D nuevaTextura = new Texture2D(1, 1);
        nuevaTextura.LoadImage(byteImagen);
        Sprite sprite = Sprite.Create(nuevaTextura, new Rect(0, 0, nuevaTextura.width, nuevaTextura.height), new Vector2(.5f, .5f));
        imagen.sprite = sprite;


    }

}
