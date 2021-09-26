using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Library_TDA
{
    class TDoubleList<T>:TGLinkedList<T>
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
        /// M�todo que inserta un nuevo elemento a la colecci�n en la posici�n especificada
        /// </summary>
        /// <param name="Element"></param>
        /// <param name="pPos">
        /// Par�metro que recibe la posici�n en la que se insertar� el elemento 
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
        /// M�todo que elimina un elemento de la colecci�n en la posici�n especificada
        /// </summary>
        /// <param name="Ind">
        /// Par�metro que recibe la posici�n del elemento a eliminar
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
    

