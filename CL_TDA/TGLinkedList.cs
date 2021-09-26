using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Class_Library_TDA
{
    public class TGLinkedList<T>:TLinkedList<T>
    {       
//Métodos===========================================
         /// <summary>
         /// Método que inserta un nuevo elemento en la posición indicada
         /// </summary>
         /// <param name="Element"></param>
         /// <param name="pPos">
         /// Parámetro que recibe la posición en la que se insertará el elemento
         /// </param>
        public virtual void Insert(T Element,int pPos) 
        {
            TNode<T> NewNode = new TNode<T>(Element);
            if (Empty)
                throw new NullReferenceException();
            else
            {
                if ((pPos < 0) || (pPos > Length))
                    throw new ArgumentOutOfRangeException();
                else
                {
                    if (pPos == 0)
                    {
                        NewNode.Next = aFirst;
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
                        CursorAnt.Next = NewNode;
                    }
                    aLength++;
                }                
            }             
        }
        
        /// <summary>
        /// Método que elimina el elemento de la posición indicada
        /// </summary>
        /// <param name="Ind">
        /// Parámetro que recibe la posición del elemento ha eliminar
        /// </param>
        /// <returns>
        /// Valor que retorna el elemento eliminado
        /// </returns>
        public virtual T Delete(int Ind) 
        {
            if (Empty != true)
            {
                if ((Ind<0)||(Ind >Length))
                         throw new ArgumentOutOfRangeException();
                else
                {
                    TNode<T> Cursor = aFirst;
                    TNode<T> CursorAnt = null;
                    int i = 0;
                    while (i < Ind)
                    {
                        CursorAnt = Cursor;
                        Cursor = Cursor.Next;
                        i++;
                    }
                        if (Cursor == aFirst)
                            aFirst = Cursor.Next;
                        else
                            CursorAnt.Next = Cursor.Next;
                        aLength--;
                        return Cursor.Information;                  
                }
            }
            return default(T);
        }

        /// <summary>
        /// Método que elimina el elemento que resulte de la comparación indicada
        /// </summary>
        /// <typeparam name="D"></typeparam>
        /// <param name="Element"></param>
        /// <param name="Comp">
        /// Parámetro que recibe el tipo de comparación ha realizar
        /// </param>
        /// <returns>
        /// Valor que retorna el elemento eliminado
        /// </returns>
        public T Delete(T Element) 
        {
            if (Empty!=true)
            {
                    TNode<T> Cursor = aFirst;
                    TNode<T> CursorAnt = null;
                    while ((Cursor!=null)&&(!Cursor.Information.Equals(Element)))
                    {
                        CursorAnt = Cursor;
                        Cursor = Cursor.Next;                        
                    }
                    if (Cursor != null)//Lo encontre
                    {
                        if (Cursor == aFirst)
                            aFirst = Cursor.Next;
                        else
                            CursorAnt.Next = Cursor.Next;
                        aLength--;
                        return Cursor.Information;
                    }                    
              }            
              return default(T);
        }

        public T Eliminar<D>(TDFuntionCondition<D> pCondicion,ref D Ref) 
        {
            if (Empty!=true)                
            {
                TNode<T> Cursor = aFirst;
                TNode<T> CursorAnt = null;
                while ((Cursor != null) && (!pCondicion(Cursor.Information,ref Ref)))
                {
                    CursorAnt = Cursor;
                    Cursor = Cursor.Next;
                }
                if (Cursor != null)//Lo encontre
                {
                    if (Cursor == aFirst)
                        aFirst = Cursor.Next;
                    else
                        CursorAnt.Next = Cursor.Next;
                    aLength--;
                    return Cursor.Information;
                }
                else
                    return default(T);
            }
            else
                return default(T);          
        }

        /// <summary>
        /// Método que recorre la lista realizando la acción especificada
        /// </summary>
        /// <typeparam name="D"></typeparam>
        /// <param name="pAction">
        /// Parámetro que recibe la acción ha realizar
        /// </param>
        /// <param name="Ref">
        /// Parámetro que recibe una variable de referencia como otro valor de retorno
        /// </param>
        public virtual void ForEach<D>(TDFuntionAction<D> pAction, ref D Ref)
        {
            if (Empty!=true)
            {
                TNode<T> Cursor = aFirst;
                while (Cursor != null)
                {
                    pAction(Cursor.Information,ref Ref);
                    Cursor = Cursor.Next;
                }
            }
        }

        /// <summary>
        /// Método que recorre la lista y devuelve el primer elemento que cumpla con la condición indicada 
        /// </summary>
        /// <typeparam name="D"></typeparam>
        /// <param name="pCondition">
        /// Parámetro que recibe la condición deseada para realizar la búsqueda
        /// </param>
        /// <param name="Ref"></param>
        /// <returns>
        /// Valor que retorna el elemento encontrado
        /// </returns>
        public virtual T FirstThat<D>(TDFuntionCondition<D> pCondition, ref D Ref)
        {
            if (Empty!=true)                
            {
                TNode<T> Cursor = aFirst;
                while (Cursor != null)
                {
                    if (pCondition(Cursor.Information,ref Ref))
                        return Cursor.Information;
                    else
                      Cursor = Cursor.Next;
                }                              
            }           
            return default(T); 
        }       
    }
}
