using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Library_TDA
{
    /// <summary>
    /// Clase gen�rica que implementa los nodos doblemente enlazados que forman una colecci�n
    /// de elementos de cualquier tipo y con cantidad solo limitada por la capacidad de la m�quina
    /// </summary>
    /// <typeparam name="T">
    /// Es el par�metro por el cual se le pasa el tipo de datos que almacenar� la lista a la que 
    /// pertenezca el nodo
    /// </typeparam>
    public class TDobleNode<T>:TNode<T>
    {
        TDobleNode<T> aPrev;       

//constructor========================================================
        public TDobleNode(T Inf):base(Inf)
        {
            aPrev = null;                       
        }

//Propiedades===========================================================
        /// <summary>
        /// Propiedad de lectura y escritura que asigna o muestra el nodo anterior al actual
        /// </summary>
        public TDobleNode<T> Prev 
        {
            set { aPrev = value; }
            get { return aPrev; }
        }       
    }
}
