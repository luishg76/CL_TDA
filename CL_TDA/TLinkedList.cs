using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Class_Library_TDA
{
     public abstract class TLinkedList<T>:TBaseList<T>
    {
         protected TNode<T> aFirst;
        
 //Constructor===================================================
         public TLinkedList()
         {
             aFirst = null;             
         }

 //M�todos====================================================
         /// <summary>
         /// M�todo que devuelve el �ndice del elemento que se le pase como par�metro realizando 
         /// una comparaci�n por referencia
         /// </summary>
         /// <param name="Element">
         /// Par�metro que recibe el elemento del cual se quiere conocer su �ndice
         /// </param>
         /// <returns>
         /// Retorna un entero que representa la posici�n del elemento
         /// </returns>
         public override int IndexOf(T Element)
         {
             int i = 0;
             TNode<T> Cursor = aFirst;
             while (Cursor != null) 
             {
                 if (Cursor.Information.Equals(Element))
                     return i;
                 Cursor = Cursor.Next;
                 i++;
             }
              return -1;             
         }

         /// <summary>
         /// M�todo que devuelve el �ndice del elemento que se le pase como par�metro realizando 
         /// la comparaci�n atendiendo a la pasada como par�metro
         /// </summary>
         /// <param name="Element">
         /// Par�metro que recibe el elemento del cual se quiere conocer su �ndice
         /// </param>
         /// <param name="Comp">
         /// Par�metro que recibe la comparaci�n a realizar
         /// </param>
         /// <returns>
         /// Retorna un entero que representa la posici�n del elemento
         /// </returns>
         public int IndexOf(T Element,IComparer Comp)
         {
             int i = 0;
             TNode<T> Cursor = aFirst;
             while (Cursor != null)
             {
                 if (Comp.Compare(Cursor.Information,Element)!=0)
                     return i;
                 Cursor = Cursor.Next;
                 i++;
             }
             return -1;
         }

         /// <summary>
         /// M�todo que inserta un nuevo elemento a la colecci�n del tipo especificado
         /// </summary>
         /// <param name="Element">
         /// Par�metro que recibe el elemento ha insertar
         /// </param>
         public override void Insert(T Element)
         {
             TNode<T> NewNode = new TNode<T>(Element);
             if (Empty)
                 aFirst = NewNode;
             else
             {
                 TNode<T> Cursor=aFirst;
                 while (Cursor.Next != null) 
                     Cursor = Cursor.Next;
                 Cursor.Next=NewNode;
             }
             aLength++;             
         }

         /// <summary>
         /// M�todo que limpia la colecci�n
         /// </summary>
         public void Clear() 
         {
             aFirst = null;
             this.aLength = 0;
         }

 //�ndices==================================================
         /// <summary>
         /// �ndice que permite recorrer los elementos de la colecci�n entrando un n�mero entero
         /// que represente la posici�n del elemento comenzando por el uno
         /// </summary>
         /// <param name="Ind"></param>
         /// <returns></returns>
         public override T this[int Ind]
         {
             get
             {
                 if (Empty)
                     throw new NullReferenceException();
                 else
                 {
                     int i = 0;
                     TNode<T> Cursor = aFirst;
                     if ((Ind<0)||(Ind >Length))
                         throw new ArgumentOutOfRangeException();
                     else
                     {
                         while ((Cursor != null) && (i < Ind))
                         {
                             Cursor = Cursor.Next;
                             i++;
                         }
                         return Cursor.Information;
                     }                        
                 }               
            }
                set
                {
                    if (Empty)
                        throw new NullReferenceException();
                    else
                    {
                        int i = 0;
                        TNode<T> Cursor = aFirst;
                        if ((Ind < 0) || (Ind > Length))
                            throw new ArgumentOutOfRangeException();
                        else
                        {
                            while ((Cursor != null) && (i < Ind))
                            {
                                Cursor = Cursor.Next;
                                i++;
                            }
                            Cursor.Information=value;
                        }
                    }       
                }
        }       
    }
}
