using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.IO;


public class LlamarGaleria : MonoBehaviour
{
	// Campos declarados
	public Image imagen;
	public string URIDatabase;
	private LlamarBBDD connector;
	public Dropdown Dd_estiloTatuaje;
	private string estiloTatuaje;

	// Metodo para seleccionar una imagen en Unity
	public void PickImage(int maximo)
	{
		// NativeGallery permite pedir permisos si se usa en un móvil para poder acceder a la galería del telefono
		// En el simulador al usarse con el ordenador abre el explorador de archivos
		NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
		{
			// Si el path(ruta donde esta la imagen) existe y no esta vacío...
			if (path != null)
			{
				if (!File.Exists(path))
				{
					return;
				}

				// Crea la Textura de la imagen seleccionada y la muestra en el campo Imagen
				Texture2D nuevaTextura = NativeGallery.LoadImageAtPath(path, maximo);
				Sprite sprite = Sprite.Create(nuevaTextura, new Rect(0, 0, nuevaTextura.width, nuevaTextura.height), new Vector2(.5f, .5f));
				imagen.sprite = sprite;
				if (nuevaTextura == null)
				{
					Debug.Log("Couldn't load texture from " + path);
					return;
				}


				// Creo objeto de la clase LlamaBBDD para poder usar sus metodos
				connector = gameObject.AddComponent<LlamarBBDD>();
				// Uso el metodo AbrirBBDD() de la clase LlamarBBDD para asegurarme de estar conectado a la BBDD
				connector.AbrirBBDD(URIDatabase);

				// Recojo el valos de la caja Estilo de tatuaje de Unity
				estiloTatuaje = Dd_estiloTatuaje.options[Dd_estiloTatuaje.value].text;

				// Con el metodo InsertarImagen() de la clase LlamarBBDD inserto la imagen en la BBDD 
				connector.InsertarImagen(path, estiloTatuaje);

			}
		}); 
	}
}
