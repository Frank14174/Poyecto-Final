using System;
using System.Collections.Generic;
using System.Text;

namespace culebrita.Clases.Cola_Arreglo
{
    class ColaCircular
    {
        private static int fin;
        private static int MAXTAMQ = 100;
        protected int frente;

        protected Object[] listaCola;


        //avanza una posicion
        private int siguiente(int r)
        {
            return (r + 1) % MAXTAMQ;

        }

        //Constructor
        public ColaCircular()
        {
            frente = 0;
            fin = MAXTAMQ - 1;
            listaCola = new Object[MAXTAMQ];
        }

        //Validaciones
        public bool colaVacia()
        {
            return frente == siguiente(fin);
        }

        public bool colaLLena()
        {
            return frente == siguiente(siguiente(fin));
        }

        //operaciones de modificacion de cola
        public void insertar(Object elemento)
        {
            if (!colaLLena())
            {
                fin = siguiente(fin);
                listaCola[fin] = elemento;

            }
            else
            {
                throw new Exception("Overflow de la cola");
            }

        }

        //quitar elemento
        public Object quitar()
        {
            if (!colaVacia())
            {
                Object tm = listaCola[frente];
                frente = siguiente(frente);
                return tm;
            }
            else
            {
                throw new Exception("Cola Vacia");
            }

        }

        public void borrarCola()
        {
            frente = 0;
            fin = MAXTAMQ - 1;
        }

        //obtener el valor de frente
        public Object frenteCola()
        {
            if (!colaVacia())
            {
                return listaCola[frente];
            }
            else
            {
                throw new Exception("Esta Vacia");
            }
        }

        public Object finalCola() {
            if (!colaVacia())
            {
                return
                    listaCola[fin];
            }
            else {
                throw new Exception("Esta vacia2");
            }
        }

        public int ele() {
            int n;
            if (!colaVacia()) {
                n = 0;
            }
            else{
                n = 1;
                while (frente!=fin) {
                    n++;
                    frente =MAXTAMQ;
                }
            }
            return n;
        }

    }
}
