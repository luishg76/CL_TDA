using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Library_TDA
{
    class TDoubleList<T>:TGLinkedList<T>
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
                aFirst = NewNode;
                ((TDobleNode<T>)NewNode).Prev = null;
            }
            else
            {
                TNode<T> Cursor = aFirst;
                while (Cursor.Next != null)
                   Cursor=Cursor.Next;
                   
                Cursor.Next = NewNode;
                ((TDobleNode<T>)NewNode).Prev =(TDobleNode<T>)Cursor; 
            }
            aLength++;  
        }

        /// <summary>
        /// Método que inserta un nuevo elemento a la colección en la posición especificada
        /// </summary>
        /// <param name="Element"></param>
        /// <param name="pPos">
        /// Parámetro que recibe la posición en la que se insertará el elemento 
        /// </param>
        public override void Insert(T Element,int pPos)
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
                        aFirst = NewNode;
                       ((TDobleNode<T>)NewNode).Prev = null;
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
                         CursorAnt.Next = NewNode;
                        ((TDobleNode<T>)Cursor).Prev = (TDobleNode<T>)NewNode;
                        ((TDobleNode<T>)NewNode).Prev = (TDobleNode<T>)CursorAnt;                              
                    }
                }
            }
            aLength++; 
        }

        /// <summary>
        /// Método que elimina un elemento de la colección en la posición especificada
        /// </summary>
        /// <param name="Ind">
        /// Parámetro que recibe la posición del elemento a eliminar
        /// </param>
        /// <returns>
        /// Valor que devuelve el elemento eliminado
        /// </returns>
        public override T Delete(int Ind)
        {
            if (Empty)
                throw new NullReferenceException();
            else
            {
                if ((Ind < 0) || (Ind >= Length))
                    throw new ArgumentOutOfRangeException();
                else
                {
                    TNode<T> Cursor = aFirst;
                    TNode<T> CursorAnt = null;
                    TNode<T> CursorPost = null;
                    int i = 0;
                    while (i < Ind)
                    {
                        CursorAnt = Cursor;
                        Cursor = Cursor.Next;
                        i++;
                    }
                    if (Cursor == aFirst)
                    {
                        aFirst = Cursor.Next;
                        ((TDobleNode<T>)aFirst).Prev = null;
                    }
                    else
                    {
                        CursorPost = Cursor.Next;
                        CursorAnt.Next = Cursor.Next;
                        ((TDobleNode<T>)CursorPost).Prev = (TDobleNode<T>)CursorAnt;
                    }
                    return Cursor.Information;
                }
            }
        }
  }
}
    

