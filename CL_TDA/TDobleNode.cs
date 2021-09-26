using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Library_TDA
{
    /// <summary>
    /// Clase genérica que implementa los nodos doblemente enlazados que forman una colección
    /// de elementos de cualquier tipo y con cantidad solo limitada por la capacidad de la máquina
    /// </summary>
    /// <typeparam name="T">
    /// Es el parámetro por el cual se le pasa el tipo de datos que almacenará la lista a la que 
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
