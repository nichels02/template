using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPolingDynamic : ObjectPoling
{
    public ObjectPolingDynamic() { }
    public ObjectPolingDynamic(GameObject objeto)
    {
        ElObjeto = objeto;
    }
    public override void PrenderObjeto(Vector2 position)
    {
        if (cantidadApagados > 0)
        {
            foreach (GameObject objeto in ListaDeObjetos)
            {
                if (!objeto.activeSelf)
                {
                    objeto.SetActive(true);
                    objeto.transform.position = position;
                    break;
                }
            }
            cantidadApagados--;
        }
        else
        {
            nuevoObjeto(position);
        }
    }
    protected override void nuevoObjeto(Vector2 position)
    {
        GameObject Objeto = Instantiate(ElObjeto, position, Quaternion.identity, transform.parent);
        Objeto.GetComponent<IObjetoDeObjectsPooling>().ElObjectPoling = this;
        ListaDeObjetos.Add(Objeto);
    }



    public override void DesactivarUnObjeto()
    {
        cantidadApagados++;
    }
    public override void DesactivarTodosLosObjetos()
    {
        foreach (GameObject gameObject in ListaDeObjetos)
        {
            gameObject.SetActive(false);
            cantidadApagados++;
        }
    }
}
