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
//Métodos======================================================
        /// <summary>
        /// Método que inserta un nuevo elemento a la colección
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
        /// Método que devuelve el primer elemento de la colección y lo elimina
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
