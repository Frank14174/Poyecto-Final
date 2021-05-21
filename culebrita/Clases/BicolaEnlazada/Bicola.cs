using culebrita.Clases.Cola_Lista;
using System;
using System.Collections.Generic;
using System.Text;

namespace culebrita.Clases.BicolaEnlazada
{
    class Bicola : ColaConLista
    {
        //insertar por el final de la bicola
        public void ponerFinalbi(Object elemento)
        {
            insertar(elemento);
        }

        //insertar al frente 
        public void ponerFrentebi(Object elemento)
        {
            Nodo a;
            a = new Nodo(elemento);

            if (colaVacia())
            {
                fin = a;
            }
            else
            {
                a.siguiente = frente;
                frente = a;
            }
        }

        //quitar elemento
        public Object quitarFrentebi()
        {
            return quitar();
        }

        /*retirar elemento al final,
        Es metodo propio de BICOLA, Es
        Necesario Hacer una iteracion de la bicola para 
        llegar del nodo anterior al final, para despues enlazar y ajustar
        la cola*/

        public Object quitarFinalbi()
        {
            Object aux;

            if (!colaVacia())
            {
                if (frente == fin) // la bicola solo tiene un nodo
                {
                    aux = quitar();
                }
                else
                {
                    //No tiene elemento vamos a iterar
                    Nodo a = frente;

                    while (a.siguiente != fin)
                    {
                        a = a.siguiente;
                    }
                    //Siguiente del Nodo Anterior lo vamos a poner en NULL
                    a.siguiente = null;
                    aux = fin.elemento;
                    fin = a;
                }
            }
            else
            {
                throw new Exception("La cola esta vacia1");

            }
            return aux;
        }

        //retorna el valor que se encuentra en el primer elemento o frente de la cola
        public Object frenteBicola()
        {
            return frenteCola();
        }

        //devolver el final de la cola
        public Object finalBicola()
        {
            if (colaVacia())
            {
                throw new Exception("Cola Vacia2");
            }
            return (fin.elemento);
        }

        public bool biColaVacia()
        {

            return colaVacia();
        }

        public void borrarBicola()
        {
            borrarCola();
        }

        //conteo de elemntos
        public int numElementosBicola()
        {
            int n;
            Nodo a = frente;
            if (biColaVacia())
            {
                n = 0;
            }
            else
            {
                n = 1;
                while (a != fin)
                {
                    n++;
                    a = a.siguiente;
                }
            }
            return n;
        }
    }
}
