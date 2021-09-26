using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Library_TDA
{
    public class TLinkedStack<T>: TLinkedList<T>
    {
          
//Propiedades==================================================
        /// <summary>
        /// Propiedad de solo lectura que muestra el ultimo elemento entrado o el primero en salir
        /// </summary>
        public T Tope 
        {
          get { return aFirst.Information; }
        }
//M�todos======================================================
        /// <summary>
        /// M�todo que inserta un nuevo elemento a la colecci�n
        /// </summary>
        /// <param name="Element"></param>
        public new void  Insert(T Element)
        {
            TNode<T> n = new TNode<T>(Element);
            if (Empty)
                aFirst = n;
            else
            {
                n.Next = aFirst;
                aFirst= n;
            }
            aLength++;
        }

        /// <summary>
        /// M�todo que devuelve el primer elemento de la colecci�n y lo elimina
        /// </summary>
        /// <returns></returns>
        public T Delete() 
        {
            TNode<T> Temp = aFirst;
            if (Empty)
                throw new InvalidOperationException();
            else
            {     
                aFirst = aFirst.Next;
                aLength--;
            }
            return Temp.Information;
        }
    }
}
