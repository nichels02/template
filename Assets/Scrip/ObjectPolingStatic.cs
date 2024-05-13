using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectPolingStatic : ObjectPoling
{
    [SerializeField] int CantidadMaxima;
    bool EstaPendiente;
    [SerializeField] int cantidadPendiente;
    [SerializeField] Queue<Vector2> ListaDePosiciones = new Queue<Vector2>();

    public ObjectPolingStatic() { }
    public ObjectPolingStatic(int cantidadMaxima, GameObject elObjeto)
    {
        CantidadMaxima = cantidadMaxima;
        ElObjeto = elObjeto;
        metodoIniciador();
    }

    private void Awake()
    {
        metodoIniciador();
    }

    void metodoIniciador()
    {
        for (int i = 0; i < CantidadMaxima; i++)
        {
            nuevoObjeto(Vector2.zero);
            cantidadApagados++;
        }
    }
    public override void PrenderObjeto(Vector2 position)
    {
        if (cantidadApagados > 0)
        {
            foreach(GameObject objeto in ListaDeObjetos)
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
            ListaDePosiciones.Enqueue(position);
            cantidadPendiente++;
            EstaPendiente = true;
        }
    }
    protected override void nuevoObjeto(Vector2 position)
    {
        GameObject Objeto = Instantiate(ElObjeto, transform.parent);
        Objeto.SetActive(false);
        Objeto.GetComponent<IObjetoDeObjectsPooling>().ElObjectPoling = this;
        ListaDeObjetos.Add(Objeto);
    }


    public override void DesactivarUnObjeto()
    {
        cantidadApagados++;
        if (EstaPendiente)
        {
            cantidadPendiente--;
            Vector2 LaPosicion = ListaDePosiciones.Peek();
            PrenderObjeto(LaPosicion);
            ListaDePosiciones.Dequeue();
            EstaPendiente = cantidadPendiente == 0 ? false : true;
        }
    }
    public override void DesactivarTodosLosObjetos()
    {
        foreach(GameObject gameObject in ListaDeObjetos)
        {
            gameObject.SetActive(false);
            cantidadApagados++;
        }
    }
}
