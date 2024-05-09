using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iniciador : MonoBehaviour
{
    [SerializeField] SOSceneList SOSceneControler;
    private void Awake()
    {
        SOSceneControler.ActivarEscena(0);
    }
}
