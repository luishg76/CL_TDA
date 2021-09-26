using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Library_TDA
{
    public class TCircLinked<T>:TGLinkedList<T>
    {
//Métodos=============================================================
        /// <summary>
        /// Método que inserta un nuevo elemento a la colección
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
