using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.IO;


public class LlamarGaleria : MonoBehaviour
{	
	public Image imagen;
	
	public void PickImage(int maximo)
	{
		NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
		{
			Debug.Log("Image path: " + path);
			if (path != null)
			{
				if (!File.Exists(path))
				{
					return;
				}

				// Create Texture from selected image
				Texture2D nuevaTextura = NativeGallery.LoadImageAtPath(path, maximo);
				Debug.Log("222222222222 ");
				Debug.Log("Image path: " + path);
				Sprite sprite = Sprite.Create(nuevaTextura, new Rect(0, 0, nuevaTextura.width, nuevaTextura.height), new Vector2(.5f, .5f));
				Debug.Log("4444444444 ");
				Debug.Log("Image path: " + path);
				imagen.sprite = sprite;
				Debug.Log("555555555555555 ");
				Debug.Log("Image path: " + path);
				if (nuevaTextura == null)
				{
					Debug.Log("Couldn't load texture from " + path);
					return;
				}
				
				//Debug.Log("Permission result: " + permission);
			}
		}); 
	}
}
