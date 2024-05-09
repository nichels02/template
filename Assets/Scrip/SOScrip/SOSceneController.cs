using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

[CreateAssetMenu(fileName = "NuevoObjeto", menuName = "SO/Escena")]
public class SOSceneController : ScriptableObject
{
    [SerializeField] SceneAsset Escena;
    public bool EstaActivo;
    public void CargarEscena()
    {
        if (!EstaActivo)
        {
            SceneManager.LoadSceneAsync(Escena.name, LoadSceneMode.Additive);
            EstaActivo = true;
        }
    }

    public void DescargarEscena()
    {
        if (EstaActivo)
        {
            SceneManager.UnloadSceneAsync(Escena.name, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
            EstaActivo = false;
        }
        // Descargar la escena por su nombre
        
    }
}