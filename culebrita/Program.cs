using culebrita.Clases.BicolaEnlazada;
using culebrita.Clases.Cola_Arreglo;
using culebrita.Clases.Cola_Lista;
using System;
namespace culebrita
{
    class Program
    {
        //convertirlo en un programa orietado a objetos
        //emitir beep cuando coma la comida
        //incrementar la velocidad conforme vaya avanzando
        //modificar el uso de queue y reemplazarlo con cada una de las estructuras de de cola vista en clase
        //Elaborar Video explicando el funcionamiento del código y del programa.
        
            
        static void Main(string[] args)
        {
            CulebritaLineal lineal = new CulebritaLineal();
            CulebritaCir circular = new CulebritaCir();
            CulebritaConLista lista = new CulebritaConLista();
            CulebritaBicola bi = new CulebritaBicola();

            //lineal.linealCulebrita();
            //circular.circularCulebrita();
            //lista.colaListaCulebrita();
            bi.biColaCulebrita();

        }
        
        }//end class
    }