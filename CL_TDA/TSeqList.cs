using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Library_TDA
{
    public abstract class TSeqList<T>:TBaseList<T>
    {
        protected T[] aList;
        protected int aSize;
        int aInc;
        
//Constructor=========================================
        public TSeqList(int aS) : this(aS, 0) { }
            
        public TSeqList(int aS, int aI) 
        {
            aSize=aS;
            aList = new T[aSize];
            aInc = aI;
        }

//Propiedades==========================================

        public int Size 
        {
          get { return aSize; }
        }

        public int Increment 
        {
            set { aInc = value; }
            get { return aInc; }
        }

        public bool Full 
        {
            get { return Length == Size; }
        }

//Métodos==============================================
        public override int IndexOf(T Element)
        {
            for (int i = 0; i < Length;i++)
            {
                if (aList[i].Equals(Element))
                    return i;
            }
            return -1;
        }

        public override void Insert(T Element)
        {
            if (Full)
                if (aInc == 0)
                    throw new ArgumentOutOfRangeException();
                else
                    Expand();                     
           
            aList[aLength++] = Element;
        }

        public virtual void Expand()
        {
          aSize = +Increment; 
          T[] ListTemp=new T [Size];
          for (int i = 0; i < Length;i++)
          {
              ListTemp[i] = aList[i];
          }
          aList = ListTemp;
        }

//Índice================================================
        public override T this[int Ind]
        {
            get 
            {
                if (Empty)
                    throw new NullReferenceException();
                else
                {
                    if ((Ind < 0) || (Ind > Length))
                        throw new ArgumentOutOfRangeException();
                    else
                        return aList[Ind];
                    
                }
            }
            set 
            {
                if (Empty)
                    throw new NullReferenceException();
                else
                {
                    if ((Ind < 0) || (Ind > Length))
                        throw new ArgumentOutOfRangeException();
                    else
                        aList[Ind]=value;
                }
            }
        }
       
    }
}
