using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Library_TDA
{
     public class TSeqStack<T>:TSeqList<T> 
    {
//Constructor======================================
        TSeqStack(int pSize) : this(pSize,0) { }

        TSeqStack(int pSize,int pInc) : base(pSize,pInc) { }   

//Propiedades===========================================
         public T Tope 
         {
             get 
             {
                 if (Empty)
                     throw new NullReferenceException();
                 else
                 { 
                   return aList[Length-1];
                 }
             }
         }

//Métodos================================================
         public T Delete()
         {
             if (Empty)
                 throw new NullReferenceException();
             else
             {
                 T Temp = Tope;
                 aList[Length - 1] = default(T);
                 aLength--;
                 return Temp;
             }                 
         } 
    }
}
