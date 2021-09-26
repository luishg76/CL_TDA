using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Library_TDA
{
    public class TLinkedQueue<T>:TLinkedList<T>
    {
        TNode<T> aLast;
//Constructor========================================================
        public TLinkedQueue() : base() 
        {
            aLast = null;        
        }

//Propiedades========================================================
        /// <summary>
        /// Propiedad de solo lectura que muestra el primer elemento de la colecci�n
        /// </summary>
        public TNode<T> FirstItem 
        {
            get { return aFirst; }
        }
//M�todos============================================================
        /// <summary>
        /// M�todo que inserta un nuevo elemento a la colecci�n 
        /// </summary>
        /// <param name="Element"></param>
        public override void Insert(T Element)
        {
            TNode<T> NewNode = new TNode<T>(Element);
            if (Empty)
            {
                aFirst = NewNode;
                aLast = NewNode;
            }
            else
            {
                aLast.Next = NewNode;
                aLast = NewNode;
            }
            aLength++;             
        }

        /// <summary>
        /// M�todo que elimina el primer elemento de la colecci�n
        /// </summary>
        /// <returns></returns>
        public T Delete() 
        {
           TNode<T> Cursor = aFirst;
            if (Empty)
                throw new NullReferenceException();
            else
            {
               aFirst = Cursor.Next;                
            }
            aLength--;
            return Cursor.Information;            
        }
    }
}
