using System;
using System.Collections.Generic;
using System.Text;

namespace culebrita.Clases.Cola_Arreglo
{
    class ColaLineal
    {
        public int fin;
        public static int MAXTAMQ = 103;
        public int frente;

        protected Object[] listaCola;

        public ColaLineal()
        {
            frente = 0;
            fin = -1;
            listaCola = new object[MAXTAMQ];
        }

        public bool colaVacia()
        {
            return frente > fin;
        }

        public bool colaLLena()
        {
            return fin == MAXTAMQ - 1;
        }

        //operaciones para trabajr con datos en la cola
        public void insertar(Object elemento)
        {
            if (!colaLLena())
            {
                listaCola[++fin] = elemento;
            }
            else
            {
                throw new Exception("Overflow de la Cola");
            }
        }

        //quitar elemento de la cola
        public Object quitar()
        {
            if (!colaVacia())
            {
                return listaCola[frente++];
            }
            else
            {
                throw new Exception("Cola Vacia quitar");

            }
        }

        //Limpiar la Cola 
        public void borrarCola()
        {
            frente = 0;
            fin = -1;
        }

        //Acceder al valor de frente de la cola
        public Object frenteCola()
        {
            if (!colaVacia())
            {
                return listaCola[frente];
            }
            else
            {
                throw new Exception("cola Vacia1");
            }
        }

        public Object finalCola() {
            if (!colaVacia())
            {
                return listaCola[fin];
                
            }
            else
            {

                throw new Exception("Cola Vacia2");
            }
            
        }
        public int el() {
            int n;
            if (!colaVacia())
            {
                n =0;

            }
            else {
                n = 1;

                while (frente!=fin) {
                    n++;
                    frente = fin;
                }
            }
            return n;
        }

    }
}
