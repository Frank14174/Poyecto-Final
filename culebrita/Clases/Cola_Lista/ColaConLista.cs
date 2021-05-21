using System;
using System.Collections.Generic;
using System.Text;

namespace culebrita.Clases.Cola_Lista
{
    class ColaConLista
    {
        public Nodo frente;
        public Nodo fin;

        public ColaConLista()
        {
            frente = fin = null;
        }

        //verificar si la cola esta vacia
        public bool colaVacia()
        {
            return (frente == null);
        }

        //insertar pone elemento por el final de la cola
        public void insertar(Object elemento)
        {
            Nodo a;
            a = new Nodo(elemento);
            if (colaVacia())
            {
                frente = a;

            }
            else
            {
                fin.siguiente = a;

            }
            fin = a;
        }

        //quitar un elemento
        public Object quitar()
        {
            Object aux;
            if (!colaVacia())
            {
                aux = frente.elemento;
                frente = frente.siguiente;
            }
            else
            {
                throw new Exception("Error pq la cola esta vacia");
            }
            return aux;
        }

        //vaciar la cola, o liberar todos los nodos
        public void borrarCola()
        {

            for (; frente != null;)
            {
                frente = frente.siguiente;
            }
        }

        //Devolver el valor que esta al frente de la cola
        public Object frenteCola()
        {
            if (colaVacia())
            {
                throw new Exception("La cola esta vacia");
            }
            return frente.siguiente;

        }

        public Object finalCola() {
            if (colaVacia()) {
                throw new Exception("La Cola esta vacia al final");    
            }
            return (fin.elemento);
            
        }

        public int elem() {
            int n;
            Nodo a = frente;
            if (colaVacia())
            {
                n = 0;
            }
            else {
                n = 1;
                while (a!=fin) {
                    n++;
                    a = a.siguiente;
                }
            }
            return n;

        }
       
    }
}
