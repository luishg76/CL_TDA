using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Class_Library_TDA
{
    public class TGLinkedList<T>:TLinkedList<T>
    {       
//M�todos===========================================
         /// <summary>
         /// M�todo que inserta un nuevo elemento en la posici�n indicada
         /// </summary>
         /// <param name="Element"></param>
         /// <param name="pPos">
         /// Par�metro que recibe la posici�n en la que se insertar� el elemento
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
        /// M�todo que elimina el elemento de la posici�n indicada
        /// </summary>
        /// <param name="Ind">
        /// Par�metro que recibe la posici�n del elemento ha eliminar
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
        /// M�todo que elimina el elemento que resulte de la comparaci�n indicada
        /// </summary>
        /// <typeparam name="D"></typeparam>
        /// <param name="Element"></param>
        /// <param name="Comp">
        /// Par�metro que recibe el tipo de comparaci�n ha realizar
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
        /// M�todo que recorre la lista realizando la acci�n especificada
        /// </summary>
        /// <typeparam name="D"></typeparam>
        /// <param name="pAction">
        /// Par�metro que recibe la acci�n ha realizar
        /// </param>
        /// <param name="Ref">
        /// Par�metro que recibe una variable de referencia como otro valor de retorno
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
        /// M�todo que recorre la lista y devuelve el primer elemento que cumpla con la condici�n indicada 
        /// </summary>
        /// <typeparam name="D"></typeparam>
        /// <param name="pCondition">
        /// Par�metro que recibe la condici�n deseada para realizar la b�squeda
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
