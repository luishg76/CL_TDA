using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Library_TDA
{
    public class TBinTreeNode<T>
    {
        protected T aInfo;
        TBinTreeNode<T> aLeft;
        TBinTreeNode<T> aRight;

  //Constructor====================================================
         public TBinTreeNode(T pInfo)
        {
            aLeft = null;
            aRight = null;
            aInfo = pInfo;
        }

   //Propiedades==============================================
        
        /// <summary>
        /// Propiedad de lectura y escritura que asigna o devuelve la información que contiene el nodo
        /// </summary>        
        public T Information 
        {
            get { return aInfo; }
            set { aInfo = value; }
        }
        
        /// <summary>
        /// Propiedad de lectura y escritura que asigna o devuelve el hijo izquierdo del nodo
        /// </summary>
        public TBinTreeNode<T> Left 
        {
            get { return aLeft; }
            set { aLeft = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura que asigna o devuelve el hijo derecho del nodo
        /// </summary>
        public TBinTreeNode<T> Right
        {
            get { return aRight; }
            set { aRight  = value; }
        }

        /// <summary>
        /// propiedad de solo lectura que devuelve el Grado del nodo
        /// </summary>
        /// <returns></returns>     
        public int Degree
        {
            get
            {
                if (IsLeaft)
                    return 0;
                else if (Left != null && Right != null)
                { return 2; }
                else
                { return 1; }
            }
        }

        /// <summary>
        /// Propiedad de solo lectura que devuelve true si el nodo es hoja o false si no
        /// </summary>
        /// <returns></returns>
        public bool IsLeaft
        {
            get { return (aLeft == null) && (aRight == null); }
        }

                
    }
}
