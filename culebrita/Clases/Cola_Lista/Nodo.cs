using System;
using System.Collections.Generic;
using System.Text;

namespace culebrita.Clases.Cola_Lista
{
    class Nodo
    {
        public Object elemento;
        public Nodo siguiente;

        public Nodo(Object x)
        {
            elemento = x;
            siguiente = null;
        }
    }
}
