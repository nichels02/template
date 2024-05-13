using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbadorDelObjectPoling : MonoBehaviour
{
    [SerializeField] ObjectPolingStatic ElObjectPolingDynamic;
    [SerializeField] float tiempoMax;
    [SerializeField] float tiempo;

    private void Update()
    {
        if(tiempo < tiempoMax)
        {
            tiempo += Time.deltaTime;
        }
        else
        {
            tiempo = 0;
            Disparar();
        }
    }


    void Disparar()
    {
        ElObjectPolingDynamic.PrenderObjeto(transform.position);
    }


}
