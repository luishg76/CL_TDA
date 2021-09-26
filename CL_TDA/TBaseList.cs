using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Library_TDA
{
    /// <summary>
    /// Clase genérica abstracta que sirve de base para la implementación
    /// de clases que formen una colección de elementos de cualquier tipo de forma dinámica
    /// </summary>
    /// <typeparam name="T">
    /// Parámetro que permite establecer el tipo de dato que almacenará la colección
    /// </typeparam>
    public abstract class TBaseList<T>
    {
        /// <summary>
        /// Delegado genérico que almacena métodos que no devuelven ningún valor y que reciben como
        /// parámetro un elemento de la lista y una referencia del tipo especificado
        /// </summary>
        /// <typeparam name="D">
        /// Parámetro que permite establecer el tipo de dato que tendrá el parámetro Ref
        /// </typeparam>
        /// <param name="Element">
        /// Parámetro por el cual se pasa el elemento de la colección sobre el que se quiere 
        /// realizar la acción
        /// </param>
        /// <param name="Ref">
        /// Parámetro de referencia por el que se le pasa un elemento opcional de retorno 
        /// </param>
        public delegate void TDFuntionAction<D>(T Element, ref D Ref);

        /// <summary>
        /// Delegado genérico que almacena métodos que devuelven como valor de retorno un bool
        /// </summary>
        /// <typeparam name="D">
        /// Parámetro que permite establecer el tipo de dato que tendrá el parámetro Ref
        /// </typeparam>
        /// <param name="Element">
        /// Parámetro por el cual se pasa el elemento de la colección que se quiere 
        /// evaluar en la condición
        /// </param>
        /// <param name="Ref">
        /// Parámetro de referencia por el que se le pasa un elemento opcional de retorno 
        /// </param>
        /// <returns>
        /// Retorna true si el elemento pasado como parámetro cumple la condición, en caso contrario
        /// retorna false
        /// </returns>
        public delegate bool TDFuntionCondition<D>(T Element, ref D Ref);

        protected int aLength;
        
//Constructor==========================================
        public TBaseList() 
        {
            aLength = 0;            
        }

//Propiedades==========================================
        /// <summary>
        /// Propiedad de solo lectura que devuelve la cantidad de elementos de la colección
        /// </summary>
        public int Length 
        {
            get { return aLength; }
        }

        /// <summary>
        /// Propiedad de solo lectura que devuelve si es vacia o no 
        /// </summary>
        public bool Empty 
        {
            get { return Length == 0; }
        }

//Métodos===============================================
        public abstract void Insert(T Element);

        public abstract int IndexOf(T Element);
              
//Índice================================================
        
        public abstract T this[int Ind]
        {
            set;
            get;
        }
   }
}
