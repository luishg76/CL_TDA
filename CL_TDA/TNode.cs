using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Library_TDA
{
    /// <summary>
    /// Clase gen�rica que implementa los nodos que forman una Lista de elementos 
    /// de cualquier tipo y con cantidad limitada solo por la capacidad de la m�quina.
    /// </summary>
    /// <typeparam name="T">
    /// Es el par�metro por el cual se le pasa el tipo de datos 
    /// que almacenar� la lista a la que pertenezca el nodo
    /// </typeparam>
     public class TNode<T>
    {
        T aInf;
        TNode<T> aNext;

//Constructor=========================================
         
         public TNode(T pInf)
        {
            aInf = pInf;
            aNext = null;            
        }

//Propiedades==========================================
        /// <summary>
        /// Es la propiedad de lectura y escritura que asigna o muestra la informaci�n contenida en este nodo
        /// </summary>
         public T Information 
        {
            set { aInf = value; }
            get { return aInf; }
        }
        /// <summary>
        /// Es la propiedad de lectura y escritura que asigna o muestra el nodo siguiente al actual
        /// </summary>
        public TNode<T> Next 
        {
            set { aNext = value; }
            get { return aNext; }
        }
    }
}
