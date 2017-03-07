#region "Author"
/****************************************************************************************
 * Solution     : CUSC His Framework
 * Project code : APP1105
 * Author       : Dương Nguyễn Phú Cường
 * Company      : Cusc Software
 * Version      : 1.0.0.1
 * Created date : 29/03/2013
 ***************************************************************************************/
#endregion


namespace CuscLibrary.DataTypes
{
    /// <summary>
    /// 	An internal implementation of the IConverter&lt;T&gt; interface
    /// </summary>
    /// <typeparam name = "T"></typeparam>
    class Converter<T> : IConverter<T>
    {
        /// <summary>
        /// 	Initializes a new instance of the <see cref = "Converter&lt;T&gt;" /> class.
        /// </summary>
        /// <param name = "value">The value.</param>
        public Converter(T value)
        {
            Value = value;
        }
        #region IConverter<T> Members

        /// <summary>
        /// 	Gets the internal value to be converted.
        /// </summary>
        /// <value>The value.</value>
        public T Value { get; protected set; }

        #endregion
    }
}