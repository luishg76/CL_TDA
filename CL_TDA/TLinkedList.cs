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

 //Métodos====================================================
         /// <summary>
         /// Método que devuelve el índice del elemento que se le pase como parámetro realizando 
         /// una comparación por referencia
         /// </summary>
         /// <param name="Element">
         /// Parámetro que recibe el elemento del cual se quiere conocer su índice
         /// </param>
         /// <returns>
         /// Retorna un entero que representa la posición del elemento
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
         /// Método que devuelve el índice del elemento que se le pase como parámetro realizando 
         /// la comparación atendiendo a la pasada como parámetro
         /// </summary>
         /// <param name="Element">
         /// Parámetro que recibe el elemento del cual se quiere conocer su índice
         /// </param>
         /// <param name="Comp">
         /// Parámetro que recibe la comparación a realizar
         /// </param>
         /// <returns>
         /// Retorna un entero que representa la posición del elemento
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
         /// Método que inserta un nuevo elemento a la colección del tipo especificado
         /// </summary>
         /// <param name="Element">
         /// Parámetro que recibe el elemento ha insertar
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
         /// Método que limpia la colección
         /// </summary>
         public void Clear() 
         {
             aFirst = null;
             this.aLength = 0;
         }

 //Índices==================================================
         /// <summary>
         /// Índice que permite recorrer los elementos de la colección entrando un número entero
         /// que represente la posición del elemento comenzando por el uno
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
