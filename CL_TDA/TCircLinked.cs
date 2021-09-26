using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Library_TDA
{
    public class TCircLinked<T>:TGLinkedList<T>
    {
//M�todos=============================================================
        /// <summary>
        /// M�todo que inserta un nuevo elemento a la colecci�n
        /// </summary>
        /// <param name="Element"></param>
        public override void Insert(T Element)
        {
            TNode<T> NewNode = new TNode<T>(Element);
            if (Empty)            
                aFirst = NewNode;  
            else
            {
                TNode<T> Cursor = aFirst;
                while (Cursor.Next != null)
                    Cursor = Cursor.Next;
                Cursor.Next = NewNode;

            }
            NewNode.Next = aFirst;
            aLength++;             
        }   
    }
}
