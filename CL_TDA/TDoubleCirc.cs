using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Library_TDA
{
    /// <summary>
    /// Clase gen�rica que implementa una colecci�n circular doblemente enlazada
    /// de elementos de cualquier tipo y con tama�o limitado solo por la capacidad
    /// de la m�quina
    /// </summary>
    /// <typeparam name="T">
    /// Par�metro que recibe el tipo de dato que contrandra la colecci�n 
    /// </typeparam>
    class TDoubleCirc<T>:TDoubleList<T>
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
            {
                NewNode.Next = aFirst;
                aFirst = NewNode;
                ((TDobleNode<T>)NewNode).Prev =(TDobleNode<T>) aFirst;                
            }
            else
            {
                TNode<T> Cursor = aFirst;
                while (Cursor.Next != null)
                    Cursor = Cursor.Next;

                Cursor.Next = NewNode;
                ((TDobleNode<T>)NewNode).Prev = (TDobleNode<T>)Cursor;
                ((TDobleNode<T>)aFirst).Prev = (TDobleNode<T>)NewNode;
                NewNode.Next = aFirst;
            }
            
            aLength++;       
        }
        /// <summary>
        /// M�todo que inserta un nuevo elemento a la colecci�n teniendo en cuenta la posici�n deseada
        /// </summary>
        /// <param name="pPos">
        /// Par�metro que recibe la posici�n del elemento a insertar
        /// </param>
        public override void Insert(T Element, int pPos)
        {
            TNode<T> NewNode = new TNode<T>(Element);
            if (Empty)
                throw new NullReferenceException();
            else
            {
                if ((pPos < 0) || (pPos >= aLength))
                    throw new ArgumentOutOfRangeException();
                else
                {
                    if (pPos == 0)
                    {
                        NewNode.Next = aFirst;
                        ((TDobleNode<T>)NewNode).Prev = ((TDobleNode<T>)aFirst).Prev; 
                        aFirst = NewNode;                         
                    }
                    else
                    {
                        int i = 0;
                        TNode<T> CursorAnt = null;
                        TNode<T> Cursor = aFirst;
                        while (i < pPos)
                        {
                            CursorAnt = Cursor;
                            Cursor = Cursor.Next;
                            i++;
                        }
                        NewNode.Next = Cursor;
                        ((TDobleNode<T>)NewNode).Prev = (TDobleNode<T>)CursorAnt;
                        CursorAnt.Next = NewNode;
                        ((TDobleNode<T>)Cursor).Prev = (TDobleNode<T>)NewNode;                       
                    }
                }
            }
            aLength++;                       
        }
    }
}
