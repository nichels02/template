using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevoObjeto", menuName = "SO/Escenas/SceneController")]

public class SOSceneList : ScriptableObject
{
    [SerializeField] List<SOSceneController> ListaDeEscenas;

    public void ActivarEscena(int i)
    {
        Debug.Log("1");
        ListaDeEscenas[i].CargarEscena();
    }

    public void DesactivarEscena(int i)
    {
        ListaDeEscenas[i].DescargarEscena();
    }
}
