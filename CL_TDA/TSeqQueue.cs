using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Library_TDA
{
    public class TSeqQueue<T>:TSeqList<T>
    {
        int aFirst;
        int aLast;

//Constructor=================================================
        public TSeqQueue(int S, int I) : base(S, I) 
        {
            aFirst = 0;
            aLast = -1;
        }

        public TSeqQueue(int S) : this(S, 0) { }
       
//Métodos======================================================
        public override int IndexOf(T Element)
        {
            if (aFirst == 0)
                return base.IndexOf(Element);
            else
            {
                for (int i = aFirst; i < aLast; i++)
                {
                    if (aList[i].Equals(Element))
                        return i;
                }
            }
            return -1;
        }

        public override void Insert(T Element)
        {
            if (aFirst == 0)
            {
                base.Insert(Element);
                aLast++;
            }
            else
            {
                if(aLast==aSize)
                {
                    for (int i = aFirst; i < aLast;i++)
                    {
                        aList[i - 1] = aList[i];
                    }
                    aList[aLast] = Element;
                    aLength++;
                    aFirst--;                    
                }
            }
        }

        public T Delete() 
        {
            T temp = default(T);
            if (Empty)
                throw new NullReferenceException();
            else
            {
                temp = aList[aFirst];             
                aList[aFirst] = default(T);
                aFirst++;
                aLength--;
            }
            return temp;
        }

//Índice=========================================================
        public override T this[int Ind]
        {
            get
            {
                if (aFirst == 0)
                    return base[Ind];
                else
                {
                    if ((Ind < aFirst) || (Ind > aLast))
                        throw new ArgumentOutOfRangeException();
                    else
                        return aList[Ind];
                }
            }
            set 
            {
                if (aFirst == 0)
                    base[Ind]=value;
                else
                {
                    if ((Ind < aFirst) || (Ind > aLast))
                        throw new ArgumentOutOfRangeException();
                    else
                       aList[Ind]=value;
                }
            
            }
        }
    }
}
