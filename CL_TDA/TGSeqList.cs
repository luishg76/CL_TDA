using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Library_TDA
{
    public class TGSeqList<T>:TSeqList<T>
    {
//Constructor==================================================
        public TGSeqList(int pSize) : base(pSize) { }

        public TGSeqList(int pSize,int pInc) : base(pSize,pInc) { }

//Métodos=========================================================
        public void Insert(T Element,int pPos)
        {
            if (Full)
                if (Increment == 0)
                    throw new NullReferenceException();
                 else
                    Expand();

            if ((pPos < 0) || (pPos > Length))
                throw new ArgumentOutOfRangeException();
            else
            {
                for (int i = Length; i > pPos;i--)
                   aList[i] = aList[i - 1]; 
                aList[pPos]=Element;
                aLength++;          
            }            
        }

        public T Delete(int pInd) 
        {
            if (Empty)
                throw new NullReferenceException();
            else
            {
                T Temp = this[pInd];
                for (int i =pInd; i < Length-1; i++)
                {
                    aList[i] = aList[i + 1];
                }
                aList[Length - 1] = default(T);
                aLength--;
                return Temp;
            }
        }

        public virtual void ForEach<D>(TDFuntionAction<D> pAction, ref D Ref)
        {
            for (int i = 0; i < Length; i++)
            {
                pAction(aList[i],ref Ref);
            }   
        }

        public virtual T FirstThat<D>(TDFuntionCondition<D> pCondition,ref D Ref)
        {
            bool Resp = false;
            int i = 0;
            while ((i < Length) && (!Resp))
            {
                if (pCondition(aList[i],ref Ref))
                    Resp = true;
                else
                    i++;
            }
            return (Resp) ? aList[i] : default(T);
        }
    }
}
