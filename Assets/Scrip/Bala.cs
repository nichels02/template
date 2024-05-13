using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour, IObjetoDeObjectsPooling
{
    public ObjectPoling ElObjectPoling { get; set; }
    [SerializeField] float velocity;
    [SerializeField] float PosicionFinal;

    private void Update()
    {
        transform.position += new Vector3(1, 0, 0) * velocity * Time.deltaTime;
        if (PosicionFinal > transform.position.x)
        {
            gameObject.SetActive(false);
            ElObjectPoling.DesactivarUnObjeto();
        }
    }
}
