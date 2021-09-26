using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Library_TDA
{   
    /// <summary>
    /// Clase gen�rica que implementa una colecci�n de elementos en una estructura arbor�a binaria,
    /// es decir cada nodo solo tiene dos hijos y cada hijo solo tiene un padre y un hermano
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TBinTree<T>
    {
        /// <summary>
        /// Delegado que almacena m�todos que no devuelven nada y que reciben como par�metro
        /// un elemento de la colecci�n y una variable de referencia del tipo especificado
        /// </summary>
        /// <typeparam name="D">
        /// Par�metro de tipo que recibe el tipo del par�metro de referencia
        /// </typeparam>
        /// <param name="Ref">
        /// Par�metro que recibe una variable de referencia usada como otro valor de retorno
        /// </param>
        public delegate void TDFuntionAction<D>(T pElement, ref D Ref);

        /// <summary>
        /// Delegado que almacena m�todos que devuelven un bool y que reciben como par�metro
        /// un elemento de la colecci�n y una variable de referencia del tipo especificado
        /// </summary>
        /// <typeparam name="D">
        /// Par�metro de tipo que recibe el tipo del par�metro de referencia
        /// </typeparam>
        /// <param name="Ref">
        /// Par�metro que recibe una variable de referencia usada como otro valor de retorno
        /// </param>
        /// <returns>
        /// Valor que devuelve true si el elemento cumple con la condici�n o falso si no
        /// </returns>
        public delegate bool TDFuntionCondition<D>(T pElement, ref D Ref);

        protected TBinTreeNode<T> aRoot;

//Constructor======================================
        public TBinTree() 
        {
            aRoot = default(TBinTreeNode<T>);
        }

//Propiedades======================================
        /// <summary>
        /// Propiedad de lectura que devuelve true si el �rbol es vacio y falso si no
        /// </summary>
        public bool Empty 
        {
            get { return aRoot == null; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura que asigna o devuelve el nodo raiz del �rbol
        /// </summary>
        public TBinTreeNode<T> Root 
        {
            get { return aRoot; }
            set { aRoot = value; }
        }

//M�todos=======================================================================
        /// <summary>
        /// M�todo que inserta un nodo hijo en la posici�n que se le pase como par�metro
        /// al nodo padre
        /// </summary>
        /// <param name="pFather">
        /// Par�metro por el que se pasa el nodo padre
        /// </param>
        /// <param name="pSon">
        /// Par�metro por el que se pasa el nodo hijo
        /// </param>
        /// <param name="pPos">
        /// Par�metro por el que se pasa una letra (L o R)indicando la posici�n
        /// </param>
        public virtual bool InsertNode<D>(D pFather, T pSon, char pPos,TDFuntionCondition<D> pCondition) 
        {
            TBinTreeNode<T> Son = new TBinTreeNode<T>(pSon);
            TBinTreeNode<T> Father=null;
            
            if (!Empty)
            {
                Father=PreOrderFirstThat<D>(Root,pCondition,ref pFather);
                if (Father != null)
                {
                    switch (pPos)
                    {
                        case 'L':
                            {
                                Son.Left = Father.Left;
                                Father.Left = Son;
                                return true;
                            }
                        case 'R':
                            {
                                Son.Right = Father.Right;
                                Father.Right = Son;
                                return true;
                            }
                    }
                }
                else
                    return false;
            }
            
            return false;
        } 

        /// <summary>
        /// M�todo que devuelve el primer nodo que cumpla con la condici�n pasada como par�metro haciendo
        /// la b�squeda en recorrido Preorden
        /// </summary>
        /// <typeparam name="D"></typeparam>
        /// <param name="pNode"></param>
        /// <param name="pAction">
        /// Par�metro por el que se pasa el m�todo que realiza la comparaci�n seg�n su condici�n
        /// </param>
        /// <param name="Ref">
        /// Par�metro opcional por el que se pasa una variable como referencia 
        /// </param>
        public TBinTreeNode<T> PreOrderFirstThat<D>(TBinTreeNode<T> pNode,TDFuntionCondition<D> pCondition,ref D Ref) 
        {
            if (pNode != null)
            {
                if (pCondition(pNode.Information, ref Ref)) return pNode;
                return PreOrderFirstThat<D>(pNode.Left, pCondition, ref Ref) != null ?
                    PreOrderFirstThat<D>(pNode.Left, pCondition, ref Ref) :
                    PreOrderFirstThat<D>(pNode.Right, pCondition, ref Ref);
            }
            else
                return null;
        }

        /// <summary>
        /// M�todo que recorre en Preorden realizando la acci�n que se le pasa como par�metro
        /// </summary>
        /// <typeparam name="D"></typeparam>
        /// <param name="pNode"></param>
        /// <param name="pAction"></param>
        /// <param name="Ref"></param>
        public void PreOrderForEach<D>(TBinTreeNode<T> pNode,TDFuntionAction<D> pAction,ref D Ref) 
        {
           if(pNode!=null)
           {
               pAction(pNode.Information, ref Ref);
               PreOrderForEach<D>(pNode.Left, pAction, ref Ref);
               PreOrderForEach<D>(pNode.Right, pAction, ref Ref);
           }
        
        }

        /// <summary>
        /// M�todo que recorre en orden sim�trico realizando la acci�n que se le pasa como par�metro
        /// </summary>
        /// <typeparam name="D"></typeparam>
        /// <param name="pNode"></param>
        /// <param name="pAction">
        /// Par�metro por el que se pasa la acci�n ha realizar
        /// </param>
        /// <param name="Ref">
        /// Par�metro opcional por el que se pasa una variable como referencia 
        /// </param>
        public void SymetricForEach<D>(TBinTreeNode<T> pNode,TDFuntionAction<D> pAction,ref D Ref) 
        {
            if (pNode!=null)
            {
                SymetricForEach<D>(pNode.Left, pAction, ref Ref);
                pAction(pNode.Information, ref Ref);
                SymetricForEach<D>(pNode.Right, pAction, ref Ref);
            }           
        }

        public void PosOrderForEach<D>(TBinTreeNode<T> pNode,TDFuntionAction<D> pAction,ref D Ref)
        {
            if (pNode != null) 
            {
                PosOrderForEach<D>(pNode.Left, pAction, ref Ref);
                PosOrderForEach<D>(pNode.Right, pAction, ref Ref); 
                pAction(pNode.Information, ref Ref);
            }
        }

        public void Clear() 
        {
            aRoot = default(TBinTreeNode<T>);
        }
       
    }
}
