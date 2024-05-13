using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Iniciador : MonoBehaviour
{
    [SerializeField] SOSceneList SOSceneControler;
    private void Awake()
    {
        print("hola");
        //string sceneName = SceneManager.GetActiveScene().name;
        //SceneManager.UnloadScene(sceneName);
        SOSceneControler.ActivarEscena(0);
    }
}
