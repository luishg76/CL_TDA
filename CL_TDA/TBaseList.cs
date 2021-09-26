using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Library_TDA
{
    /// <summary>
    /// Clase gen�rica abstracta que sirve de base para la implementaci�n
    /// de clases que formen una colecci�n de elementos de cualquier tipo de forma din�mica
    /// </summary>
    /// <typeparam name="T">
    /// Par�metro que permite establecer el tipo de dato que almacenar� la colecci�n
    /// </typeparam>
    public abstract class TBaseList<T>
    {
        /// <summary>
        /// Delegado gen�rico que almacena m�todos que no devuelven ning�n valor y que reciben como
        /// par�metro un elemento de la lista y una referencia del tipo especificado
        /// </summary>
        /// <typeparam name="D">
        /// Par�metro que permite establecer el tipo de dato que tendr� el par�metro Ref
        /// </typeparam>
        /// <param name="Element">
        /// Par�metro por el cual se pasa el elemento de la colecci�n sobre el que se quiere 
        /// realizar la acci�n
        /// </param>
        /// <param name="Ref">
        /// Par�metro de referencia por el que se le pasa un elemento opcional de retorno 
        /// </param>
        public delegate void TDFuntionAction<D>(T Element, ref D Ref);

        /// <summary>
        /// Delegado gen�rico que almacena m�todos que devuelven como valor de retorno un bool
        /// </summary>
        /// <typeparam name="D">
        /// Par�metro que permite establecer el tipo de dato que tendr� el par�metro Ref
        /// </typeparam>
        /// <param name="Element">
        /// Par�metro por el cual se pasa el elemento de la colecci�n que se quiere 
        /// evaluar en la condici�n
        /// </param>
        /// <param name="Ref">
        /// Par�metro de referencia por el que se le pasa un elemento opcional de retorno 
        /// </param>
        /// <returns>
        /// Retorna true si el elemento pasado como par�metro cumple la condici�n, en caso contrario
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
        /// Propiedad de solo lectura que devuelve la cantidad de elementos de la colecci�n
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

//M�todos===============================================
        public abstract void Insert(T Element);

        public abstract int IndexOf(T Element);
              
//�ndice================================================
        
        public abstract T this[int Ind]
        {
            set;
            get;
        }
   }
}
