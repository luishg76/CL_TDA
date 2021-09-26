using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Library_TDA
{
    /// <summary>
    /// Clase genérica que implementa una colección circular doblemente enlazada
    /// de elementos de cualquier tipo y con tamaño limitado solo por la capacidad
    /// de la máquina
    /// </summary>
    /// <typeparam name="T">
    /// Parámetro que recibe el tipo de dato que contrandra la colección 
    /// </typeparam>
    class TDoubleCirc<T>:TDoubleList<T>
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
        /// Método que inserta un nuevo elemento a la colección teniendo en cuenta la posición deseada
        /// </summary>
        /// <param name="pPos">
        /// Parámetro que recibe la posición del elemento a insertar
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
